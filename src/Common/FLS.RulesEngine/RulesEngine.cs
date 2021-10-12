﻿using System.Collections.Generic;

namespace FLS.RulesEngine
{
    public static class RulesEngine
    {
        public static T ApplyRules<T>(this T obj, List<IRule<T>> rules) where T : class
        {
            foreach (var rule in rules)
            {
                obj.ApplyRule(rule);

                if (rule.RuleApplied && rule.StopRuleEngineWhenRuleApplied)
                {
                    break;
                }
            }
            return obj;
        }

        public static T ApplyRule<T>(this T obj, IRule<T> rule) where T : class
        {
            rule.ClearConditions();
            rule.Initialize(obj);

            if (rule.IsValid())
            {
                rule.Apply(obj);
            }
            else
            {
                rule.ElseApply(obj);
            }

            return obj;
        }
    }
}
