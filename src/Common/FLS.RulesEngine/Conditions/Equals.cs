﻿namespace FLS.RulesEngine.Conditions
{
    internal class Equals<T> : ICondition
    {
        private readonly T _actual;
        private readonly T _threshold;

        public Equals(T actual, T threshold)
        {
            _threshold = threshold;
            _actual = actual;
        }

        public bool IsSatisfied()
        {
            return Equals(_actual, _threshold);
        }

        public override string ToString()
        {
            return $"({_actual} EQUALS {_threshold} ==> {IsSatisfied()})";
        }
    }
}
