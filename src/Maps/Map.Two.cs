// Copyright (c) Ben A Adams. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Ben.Collections
{
    internal abstract partial class Map<TKey, TValue>
    {
        // Instance with two key/value pairs.
        private sealed class TwoElementKeyedMap : Map<TKey, TValue>
        {
            private readonly TKey _key1, _key2;
            private TValue _value1, _value2;

            public override int Count => 2;

            public TwoElementKeyedMap(TKey key1, TValue value1, TKey key2, TValue value2)
            {
                _key1 = key1; _value1 = value1;
                _key2 = key2; _value2 = value2;
            }

            public override Map<TKey, TValue> Set(TKey key, TValue value)
            {
                // If the key matches one already contained in this map  then update the value
                if (Comparer.Equals(key, _key1))
                {
                    _value1 = value;
                }
                else if (Comparer.Equals(key, _key2))
                {
                    _value2 = value;
                }
                else
                {
                    // Otherwise create a three-element map with the additional key/value.
                    return new ThreeElementKeyedMap(_key1, _value1, _key2, _value2, key, value);
                }

                return this;
            }

            public override bool TryGetValue(TKey key, out TValue value)
            {
                if (Comparer.Equals(key, _key1))
                {
                    value = _value1;
                    return true;
                }
                else if (Comparer.Equals(key, _key2))
                {
                    value = _value2;
                    return true;
                }
                else
                {
                    value = default(TValue);
                    return false;
                }
            }

            public override Map<TKey, TValue> TryRemove(TKey key, out bool success)
            {
                // If the key exists in this map, remove it by downgrading to a one-element map without the key. 
                if (Comparer.Equals(key, _key1))
                {
                    success = true;
                    return new OneElementKeyedMap(_key2, _value2);
                }
                else if (Comparer.Equals(key, _key2))
                {
                    success = true;
                    return new OneElementKeyedMap(_key1, _value1);
                }
                else
                {
                    // Otherwise, there's nothing to add or remove, so just return this map.
                    success = false;
                    return this;
                }
            }

            public override bool TryGetNext(ref int index, out KeyValuePair<TKey, TValue> value)
            {
                index++;
                if (index == 0)
                {
                    value = new KeyValuePair<TKey, TValue>(_key1, _value1);
                }
                else if (index == 1)
                {
                    value = new KeyValuePair<TKey, TValue>(_key2, _value2);
                }
                else
                {
                    value = default(KeyValuePair<TKey, TValue>);
                    return false;
                }

                return true;
            }

            public override ICollection<TKey> Keys => new[] { _key1, _key2 };
            public override ICollection<TValue> Values => new[] { _value1, _value2 };
        }
    }
}
