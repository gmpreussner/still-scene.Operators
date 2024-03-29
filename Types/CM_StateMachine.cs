using System;
using System.Collections.Generic;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b0453fd5_e9c5_481a_aa6b_0040bd5c1318
{
    public class CM_StateMachine : Instance<CM_StateMachine>
    {
        [Output(Guid = "78a7a222-ef84-45cb-9732-eb29afc83c3d", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<float> SimulationProgress = new Slot<float>();

        // [Output(Guid = "21BB7697-6E6E-437D-922B-4B7356939D3D")]
        // public readonly Slot<float> ModeChangeTime = new Slot<float>();
        //
        // [Output(Guid = "BAE401A1-481F-4900-BFE6-292E73AA1C7B")]
        // public readonly Slot<int> SimulationYear = new Slot<int>();

        [Output(Guid = "BBE120E4-DD68-4301-A3F2-3C1CA7D345E5", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<string> RestCarbon = new Slot<string>();

        [Output(Guid = "8160A329-0A1A-4FDF-8E9D-D5E21CA95954", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<float> RestCarbonRatio = new Slot<float>();
        
        [Output(Guid = "A72A83F1-B36B-4653-8D1F-C0EBA3D03A0A", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<bool> IsSimulationRunning = new Slot<bool>();

        [Output(Guid = "BE19AE67-EDB8-402C-A218-C327AF886D81", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<float> Temperature = new Slot<float>();

        [Output(Guid = "08C995C9-B091-476C-8985-1C7EB64F451D", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<DateTime> Date = new Slot<DateTime>();

        public CM_StateMachine()
        {
            SimulationProgress.UpdateAction = Update;
            RestCarbon.UpdateAction = Update;
        }

        private static double RunTime => EvaluationContext.RunTimeInSecs;

        private void Update(EvaluationContext context)
        {
            _renewPower = RenewPower.GetValue(context);
            _renewHeating = RenewHeating.GetValue(context);
            _renewMobility = RenewMobility.GetValue(context);
            _simulationSpeed = SimulationSpeed.GetValue(context);
            var startPressed = TriggerSimulation.GetValue(context);

            switch (_state)
            {
                case States.Idle:
                    break;

                case States.ShowConfiguration:
                    break;

                case States.Simulating:
                {
                    //var progress = (float)((RunTime - _simulationStartTime) / currentSimulationMode.GetSimulationDuration()) * _simulationSpeed;
                    var complete = Progress >= 1;
                    if (complete)
                    {
                        _lastInteractionTime = RunTime;
                        SetState(States.SimulationComplete);
                    }

                    //SimulationProgress.Value = (float)Progress;
                    break;
                }

                case States.SimulationComplete:
                {
                    // Update result animation?
                    // Eventually switch to idle mode
                    break;
                }
            }

            if (_state != States.SimulationComplete)
            {
                RestCarbon.Value = GetRestCarbon();
                Temperature.Value = GetTemperature();
                RestCarbonRatio.Value = GetRestCarbonRatio();
                Date.Value = GetDate();
                SimulationProgress.Value = (float)Progress;
            }

            if (startPressed != _startPressed)
            {
                if (startPressed)
                {
                    SetState(States.Simulating);
                }

                _startPressed = startPressed;
            }

            var newSimMode = GetModeFromRenewalSetting();
            if (newSimMode != _simulationModeIndex)
            {
                SetState(States.ShowConfiguration);
                _simulationModeIndex = newSimMode;
            }

            if (_state != States.Simulating && _state != States.Idle)
            {
                if (RunTime - _lastInteractionTime > IdleTimeOut)
                    SetState(States.Idle);
            }

            IsSimulationRunning.Value = _state == States.Simulating;
        }

        private void SetState(States newState)
        {
            // if (newState == _state)
            //     return;

            Log.Debug($"Switch {_state} -> {newState}", SymbolChildId);

            switch (newState)
            {
                case States.Idle:
                    break;

                case States.Simulating:
                    _simulationStartTime = RunTime;
                    _lastInteractionTime = RunTime;
                    break;

                case States.ShowConfiguration:
                    _lastInteractionTime = RunTime;
                    SimulationProgress.Value = 0;
                    break;

                case States.SimulationComplete:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            _state = newState;
        }

        private int GetModeFromRenewalSetting()
        {
            return (_renewPower ? (1 << 0) : 0)
                   + (_renewHeating ? (1 << 1) : 0)
                   + (_renewMobility ? (1 << 2) : 0);
        }

        private string GetRestCarbon()
        {
            long rest = (long)MathUtils.Lerp(InitialRestCarbon, ActiveMode.RestCarbon, Progress);
            return $"{rest:0}";
        }
        
        private float GetRestCarbonRatio()
        {
            long rest = (long)MathUtils.Lerp(InitialRestCarbon, ActiveMode.RestCarbon, Progress);
            return (float)(rest / (double) InitialRestCarbon);
        }

        private float GetTemperature()
        {
            return  (float)MathUtils.Lerp(InitialTemp, ActiveMode.EndTemperature, Progress);
        }
        
        private DateTime GetDate()
        {
            var timeA = _initialDate;
            var timeB = ActiveMode.EndDate;
            var duration = timeB - timeA;
            return timeA + TimeSpan.FromHours(duration.TotalHours * Progress);
        }
        
        private double Progress
        {
            get
            {
                switch (_state)
                {
                    case States.Simulating:
                        return (RunTime - _simulationStartTime) / SelectedSimulationMode.GetSimulationDuration() * _simulationSpeed;
                    case States.SimulationComplete:
                        return 1;
                }

                var worstMode = _simulationModes[0];
                var waitDuration = DateTime.Now - _initialDate;
                var endDuration = worstMode.EndDate - _initialDate;
                return (waitDuration.TotalDays / endDuration.TotalDays);
            }
        }

        private SimulationMode SelectedSimulationMode => _simulationModes[_simulationModeIndex];

        private const double IdleTimeOut = 3 * 60;
        private const long InitialRestCarbon = 7430000000000;
        
        private readonly DateTime _initialDate = new DateTime(2021, 5, 12);
        private const float InitialTemp = 1.21f;

        private SimulationMode DefaultMode => _simulationModes[0];
        private SimulationMode ActiveMode => _state == States.Simulating || _state == States.SimulationComplete 
                                                 ? SelectedSimulationMode 
                                                 : DefaultMode;

        private States _state = States.Idle;
        private double _lastInteractionTime;
        private double _simulationStartTime;
        private bool _startPressed;
        private bool _renewPower;
        private bool _renewHeating;
        private bool _renewMobility;

        private int _simulationModeIndex;

        enum States
        {
            Idle,
            ShowConfiguration,
            Simulating,
            SimulationComplete,
        }

        private struct SimulationMode
        {
            public SimulationMode(int year, float endTemperature, long restCarbon)
            {
                Year = year;
                EndTemperature = endTemperature;
                RestCarbon = restCarbon;
                EndDate = new DateTime(year, 12, 30);
            }

            public readonly int Year;
            public float EndTemperature;
            public readonly long RestCarbon;
            public DateTime EndDate;

            public float GetSimulationDuration()
            {
                return (Year - 2021);
            }
        }

        private List<SimulationMode> _simulationModes = new List<SimulationMode>()
                                                            {
                                                                new SimulationMode(2125, 5f, 3381000000000),
                                                                new SimulationMode(2172, 5f, 3381000000000),
                                                                new SimulationMode(2173, 5f, 3381000000000),
                                                                new SimulationMode(2324, 5f, 3381000000000),
                                                                new SimulationMode(2174, 5f, 3381000000000),
                                                                new SimulationMode(2328, 5f, 3381000000000),
                                                                new SimulationMode(2335, 5f, 3381000000000),
                                                                new SimulationMode(2036, 1.7f, 6887000000000),
                                                            };

        [Input(Guid = "c766e021-8478-4507-859d-25badb679ff2")]
        public readonly InputSlot<float> Value = new InputSlot<float>();

        [Input(Guid = "3477E8BA-CB57-4007-85A5-FD1EFE1B578C")]
        public readonly InputSlot<bool> RenewPower = new InputSlot<bool>();

        [Input(Guid = "286AB912-8D04-466B-B5C8-4D673F7F97E1")]
        public readonly InputSlot<bool> RenewHeating = new InputSlot<bool>();

        [Input(Guid = "B212B24D-E6F2-481F-9DC6-42CBB4D9ADF6")]
        public readonly InputSlot<bool> RenewMobility = new InputSlot<bool>();

        [Input(Guid = "03C4CCC6-87AA-4F5B-B321-BE5A1CD6A3E8")]
        public readonly InputSlot<bool> TriggerSimulation = new InputSlot<bool>();

        [Input(Guid = "C82893BB-5106-4280-A2C0-03CAFC5112A1")]
        public readonly InputSlot<float> SimulationSpeed = new InputSlot<float>();

        private float _simulationSpeed;
    }
}