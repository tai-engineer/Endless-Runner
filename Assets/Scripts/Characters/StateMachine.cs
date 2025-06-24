using UnityEngine;

namespace EndlessRunner
{
    public class StateMachine
    {
        public BaseState CurrentState { get; private set; }
        public void Update()
        {
            if (CurrentState.GetTransition(out var transition))
            {
                TransitionToState(transition.To);
            }
            CurrentState.OnUpdate();
        }
        public void Start(BaseState initialState)
        {
            SetState(initialState);
        }

        /// <summary>
        /// Assigns new state to current state
        /// </summary>
        /// <param name="newState"></param>
        void SetState(BaseState newState)
        {
            if (newState == null)
            {
                Debug.LogError("State cannot be null");
                return;
            }
            CurrentState = newState;
            Debug.Log("State changed to " + CurrentState.GetType().Name);
            CurrentState.OnEnter();
        }

        /// <summary>
        /// Transitions the state machine to a new state.
        /// </summary>
        /// <param name="newState">
        /// The new state to transition to. Must be a valid instance of a state different from the current state.
        /// </param>
        /// <remarks>
        /// The method calls <c>OnExit</c> on the current state before changing to the new state
        /// and then calls <c>OnEnter</c> on the new state. If <paramref name="newState"/> is null
        /// or identical to the current state, the method does nothing to prevent unnecessary transitions.
        /// </remarks>
        void TransitionToState(BaseState newState)
        {
            if (newState == null || CurrentState == newState)
                return;
            CurrentState.OnExit();
            SetState(newState);
        }
    }
}
