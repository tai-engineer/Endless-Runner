using System;
using Common.Variables;
using UnityEngine;

namespace EndlessRunner.Characters
{
    [Serializable]
    public class Transition
    {
        public BaseStateSO to;
        public Condition condition;
    }
    
    [Serializable]
    public class Condition
    {
        [SerializeField] BoolVariableSO variable;

        public bool IsMet => variable.Value;
    }
}