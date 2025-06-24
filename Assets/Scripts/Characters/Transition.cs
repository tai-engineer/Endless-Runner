using System;

namespace EndlessRunner
{
    public struct Transition
    {
        public BaseState To { get; }
        public Condition Condition { get; }

        public Transition(BaseState to, Condition condition)
        {
            To = to;
            Condition = condition;           
        }
    }
    
    public struct Condition
    {
        readonly Func<bool> func;

        public Condition(Func<bool> func)
        {
            this.func = func;
        }

        public bool IsMet => func() == true;
    }
}