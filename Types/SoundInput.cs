using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using ManagedBass;
using ManagedBass.Wasapi;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b72d968b_0045_408d_a2f9_5c739c692a66
{
    public class SoundInput : Instance<SoundInput>
    {
        [Output(Guid = "B3EFDF25-4692-456D-AA48-563CFB0B9DEB", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<List<float>> FftBuffer = new Slot<List<float>>();

        [Output(Guid = "b438986f-6ef9-40d5-8a2c-b00c01578ebc", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<float> Result = new Slot<float>();

        [Output(Guid = "D7D2A87C-4231-4F8B-904F-6E5F5D01B1D8", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<float> AvailableData = new Slot<float>();

        public SoundInput()
        {
            Result.UpdateAction = Update;
            FftBuffer.UpdateAction = Update;
            AvailableData.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            if (_analyzer == null)
                _analyzer = new Analyzer();
 
            //_analyzer.TimerUpdateEventHandler();

            _analyzer.SetDeviceIndex((int)Input1.GetValue(context));
            FftBuffer.Value = _analyzer.FftBuffer.ToList();
            AvailableData.Value = _analyzer.AvailableData;
        }

        private static Analyzer _analyzer;

        protected override void Dispose(bool disposing)
        {
            _analyzer.Dispose();
        }

        [Input(Guid = "e8a10146-ef7f-459c-a1f8-eef621a2c522")]
        public readonly InputSlot<float> Input1 = new InputSlot<float>();
    }

    /// <summary>
    /// This is based on https://www.codeproject.com/Articles/797537/
    /// Audio Spectrum by @webmaster442
    /// </summary>
    internal class Analyzer : IDisposable
    {
        public Analyzer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(1000/120f);
            _timer.Tick += TimerUpdateEventHandler;
            
            // ReSharper disable once RedundantDelegateCreation
            _wasapiProcedure = new WasapiProcedure(Process); // capture to avoid freeing by GC
            _initialized = false;
            Init();
        }

        public void Dispose()
        {
            Log.Debug("Disposing Sound analyser");
            _timer.Tick -= TimerUpdateEventHandler;
            Free();
        }

        
        /// <summary>
        /// This property returns the length of the available data.
        /// This might be useful for eventually discover the reason for
        /// the frequent connection problems to sound provides like streaming from Firefox 
        /// </summary>
        public float AvailableData { get; private set; }

        public void SetDeviceIndex(int index)
        {
            if (index == _deviceIndex)
                return;

            _deviceIndex = index;
            _initialized = false;
            SetEnableWasapi(true);
        }

        private void SetEnableWasapi(bool enable)
        {
            if (!enable)
            {
                BassWasapi.Stop();
                //BassWasapi.Free();
                _timer.Stop();
                _timer.IsEnabled = false;
                return;
            }

            if (!_initialized)
            {
                var str = _deviceList[_deviceIndex % _deviceList.Count];
                var array = str.Split(' ');
                _wasapiDeviceIndex = Convert.ToInt32(array[0]);
                Log.Debug($"Initializing WASAPI for {str}... #{_wasapiDeviceIndex}");
                if (!BassWasapi.Init(_wasapiDeviceIndex, 
                                     Frequency: 0, 
                                     Channels: 0,
                                     //Flags: WasapiInitFlags.Buffer | WasapiInitFlags.Exclusive,
                                     Flags: WasapiInitFlags.Buffer,
                                     Buffer: 1,//0.0041f/2, // was 1
                                     Period: 1, //0.0041f/2,
                                     Procedure: _wasapiProcedure, 
                                     User: IntPtr.Zero))
                {
                    Log.Error("Can't initialize WASAPI:" + Bass.LastError);
                    return;
                }

                _initialized = true;
            }

            BassWasapi.Start();
            System.Threading.Thread.Sleep(100);
            _timer.IsEnabled = true;
            _timer.Start();
            
        }

        private void Init()
        {
            InitBass();
            SetEnableWasapi(true);
        }

        private void InitBass()
        {
            for (var i = 0; i < BassWasapi.DeviceCount; i++)
            {
                var device = BassWasapi.GetDeviceInfo(i);
                if (device.IsEnabled && device.IsLoopback)
                {
                    _deviceList.Add(string.Format($"{i} - {device.Name}"));
                }
            }

            Bass.Configure(Configuration.UpdateThreads, false);

            var result = Bass.Init(Device: 0, Frequency: 44100, Flags: DeviceInitFlags.Default, Win: IntPtr.Zero);
            if (result)
            {
                Log.Debug("Successfully initialized BASS.Init()");
            }

            if (!result)
            {
                Log.Error("Bass initialization failed:" + Bass.LastError);
            }
        }

        public void TimerUpdateEventHandler(object sender, EventArgs eventArgs)
        {
            BassWasapi.GetData(null, (int)DataFlags.Available);
            
            // Note: The DataFlags seems to be offset by one (e.g. FFT256 only fills 128 entries)
            const int get256FftValues = (int)DataFlags.FFT512; 
            
            // Get FFT data. Return value is -1 on error
            var result = BassWasapi.GetData(FftBuffer, get256FftValues);
            if (result < 0)
            {
                Log.Debug("No new Data");
                return;
            }
            
            var level = BassWasapi.GetLevel();

            // Required, because some programs hang the output. If the output hangs for a 75ms
            // this piece of code re initializes the output so it doesn't make a glitched sound for long.
            if (level == _lastLevel && level > 0)
            {
                //Log.Debug(" not changed");
                if (_hangCounter++ > 10)
                {
                    Log.Warning("Looks like sound got lost. Trying to restart.");
                    _hangCounter = 0;
                    Free();
            
                    InitBass();
                    _initialized = false;
                    SetEnableWasapi(true);
                }

                return;
            }

            _lastLevel = level;
            _hangCounter = 0;
        }

        /// <summary>
        /// WASAPI callback, required for continuous recording
        /// </summary>
        private static int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }
        
        private static void Free()
        {
            BassWasapi.Free();
            Bass.Free();
        }

        private int _deviceIndex;
        private int _lastLevel;
        private readonly DispatcherTimer _timer = new DispatcherTimer(); // Timer that refreshes the display
        
        
        public readonly float[] FftBuffer =  new float[FftSize];

        private readonly WasapiProcedure _wasapiProcedure;
        private int _hangCounter;
        private const int FftSize = 256;

        private readonly List<string> _deviceList = new List<string>();
        private bool _initialized;
        private int _wasapiDeviceIndex;
    }
}