using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace EndlessRunner.Characters
{
    public class Character : MonoBehaviour
    {
    #region References
        public Animator animator;
    #endregion
        [Header( "State Machine" )]
        [SerializeField, Required] BaseStateSO initialState;
        StateMachine stateMachine;

        void Awake()
        {
            stateMachine = new StateMachine(this);
            animator = GetComponent<Animator>();
        }

        void Start()
        {
            stateMachine.Start(initialState);
        }
        void Update()
        {
            stateMachine.Update();
        }
    }
}