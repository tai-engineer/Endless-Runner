using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner.Characters
{
    public abstract class BaseStateSO : ScriptableObject
    {
        public new string name;
        [SerializeField] List<Transition> transitions = null;

        public virtual void OnEnter(Character character) { }
        public virtual void OnExit(Character character) { }
        public virtual void OnUpdate(Character character) { }

        public bool GetTransition(out Transition transition)
        {
            transition = null;
            if (transitions.Count == 0)
            {
                Debug.LogError("No transitions assigned for state: " + name);
                return false;
            }

            foreach (var t in transitions)
            {
                if (t.condition.IsMet)
                {
                    transition = t;
                    return true;
                }
            }
            return false;
        }
    }
}