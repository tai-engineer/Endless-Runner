using UnityEngine;

namespace EndlessRunner.Characters
{
    public class StateMachine
    {
        public BaseStateSO CurrentState { get; private set; }
    
        Character character;
        public StateMachine(Character character) => this.character = character;
        public void Start(BaseStateSO initialState)
        {
            Debug.Log($"State Machine started\n Initial State: {initialState.name}");
            SetState(initialState);
        }
        public void Update()
        {
            if (CurrentState == null)
            {
                Debug.LogError("State Machine is not initialized.");
                return;
            }
            if (CurrentState.GetTransition(out var transition))
            {
                TransitionToState(transition.to);
            }
            CurrentState.OnUpdate(character);
        }

        /// <summary>
        /// Assigns new state to current state
        /// </summary>
        /// <param name="newState"></param>
        void SetState(BaseStateSO newState)
        {
            if (newState == null)
            {
                Debug.LogError("State cannot be null");
                return;
            }
            CurrentState = newState;
            CurrentState.OnEnter(character);
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
        void TransitionToState(BaseStateSO newState)
        {
            if (newState == null || CurrentState == newState)
                return;
            CurrentState.OnExit(character);
            SetState(newState);
            Debug.Log("State changed to " + CurrentState.GetType().Name);
        }
    }
}
