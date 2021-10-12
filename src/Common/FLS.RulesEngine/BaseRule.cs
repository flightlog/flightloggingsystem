using System.Collections.Generic;
using System.Linq;

namespace FLS.RulesEngine
{
    /// <summary>
    /// Base rule class for rule handling
    /// <see cref="https://richardtasker.co.uk/2014/01/19/a-simple-rule-engine/#.XNx3iI4zZaQ"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRule<T> : IRule<T>
    {
        protected BaseRule()
        {
            Conditions = new List<ICondition>();
        }

        public IList<ICondition> Conditions { get; set; }

        public void ClearConditions()
        {
            Conditions.Clear();
            RuleApplied = false;
        }

        public virtual bool IsValid()
        {
            return Conditions.All(x => x.IsSatisfied());
        }

        public abstract void Initialize(T obj);

        public virtual T Apply(T obj)
        {
            RuleApplied = true;
            return obj;
        }

        public virtual T ElseApply(T obj)
        {
            return obj;
        }

        public bool RuleApplied { get; protected set; }

        public bool StopRuleEngineWhenRuleApplied { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}, Nr of Conditions={Conditions.Count}, RuleApplied={RuleApplied}, StopRuleEngineWhenRuleApplied={StopRuleEngineWhenRuleApplied}";
        }
    }
}

