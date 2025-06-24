using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner
{
    public abstract class BaseState
    {
        public string name;
        protected Character character;
        HashSet<Transition> transitions = new HashSet<Transition>();
        
        protected BaseState(Character character)
        {
            this.character = character;
        }
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
        
        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }
        
        public void RemoveTransition(Transition transition)
        {
            transitions.Remove(transition);
        }

        public bool GetTransition(out Transition transition)
        {
            foreach (var t in transitions)
            {
                if (t.Condition.IsMet)
                {
                    transition = t;
                    return true;
                }
            }
            transition = default;
            return false;
        }
    }
}