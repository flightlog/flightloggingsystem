﻿using System.Collections.Generic;
using System.Linq;

namespace FLS.RulesEngine.Conditions
{
    internal class Contains<T> : ICondition
    {
        private readonly ICollection<T> _collection;
        private readonly T _key;

        public Contains(ICollection<T> collection, T key)
        {
            _collection = collection;
            _key = key;
        }

        public bool IsSatisfied()
        {
            return _collection != null && _collection.Contains(_key);
        }

        public override string ToString()
        {
            if (_collection == null) return "(collection: NULL)";

            return $"(collection: '{string.Join(",", _collection.Select(x => x))}' CONTAINS key: {_key} ==> {IsSatisfied()})";
        }
    }
}
