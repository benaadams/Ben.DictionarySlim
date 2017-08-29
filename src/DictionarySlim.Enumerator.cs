// Copyright (c) Ben A Adams. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Ben.Collections
{
    public partial class DictionarySlim<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            Map<TKey, TValue> _map;
            int index;
            KeyValuePair<TKey, TValue> _current;

            internal Enumerator(Map<TKey, TValue> map)
            {
                _map = map;
                index = -1;
                _current = default(KeyValuePair<TKey, TValue>);
            }

            public KeyValuePair<TKey, TValue> Current => _current;

            public bool MoveNext() => _map.TryGetNext(ref index, out _current);

            public void Dispose()
            {
            }

            object IEnumerator.Current => _current;

            void IEnumerator.Reset() => throw new NotSupportedException();
        }
    }
}