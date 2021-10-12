namespace FLS.RulesEngine.Conditions
{
    internal class IsTrue : ICondition
    {
        private readonly bool _actual;

        public IsTrue(bool actual)
        {
            _actual = actual;
        }

        public bool IsSatisfied()
        {
            return _actual == true;
        }

        public override string ToString()
        {
            return $"({_actual} is true ==> {IsSatisfied()})";
        }
    }
}
