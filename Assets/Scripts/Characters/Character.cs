using System;
using UnityEngine;

namespace EndlessRunner
{
    public class Character : MonoBehaviour
    {
        readonly StateMachine stateMachine = new StateMachine();
        public BaseState initialState;

        BaseState _runState, _jumpState;
        void Start()
        {
            _runState = new RunState(this);
            _jumpState = new JumpState(this);
            
            AddTransition(_runState, _jumpState, () => Input.GetKeyDown(KeyCode.A));
            AddTransition(_jumpState, _runState, () => Input.GetKeyDown(KeyCode.D));
            
            initialState = _runState;
            stateMachine.Start(initialState);
        }

        void AddTransition(BaseState from, BaseState to, Func<bool> func)
        {
            from.AddTransition(new Transition(to, new Condition(func)));
        }
        void Update()
        {
            stateMachine.Update();
        }
    }
}