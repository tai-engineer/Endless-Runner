using UnityEngine;
using UnityEngine.Events;

namespace Common.Variables
{
    public class GenericVariableSO<T> : ScriptableObject
    {
        [SerializeField] T defaultValue;
        [SerializeField] T runtimeValue;
        [SerializeField] bool isReadonly;
        [SerializeField] bool resetOnPlay;
        
        public UnityEvent<T> OnValueChanged;
        public T Value
        {
            get => isReadonly? defaultValue : runtimeValue;
            set
            {
                if (isReadonly) 
                    return;
                
                if (!Equals(runtimeValue, value))
                {
                    runtimeValue = value;
                    OnValueChanged?.Invoke(value);
                }
            }
        }
        
        void OnEnable()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying && resetOnPlay)
            {
                runtimeValue = defaultValue;
            }
#endif
        }
    }
}