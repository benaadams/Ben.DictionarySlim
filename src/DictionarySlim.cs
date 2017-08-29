// Copyright (c) Ben A Adams. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Ben.Collections
{
    public partial class DictionarySlim<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Map<TKey, TValue> _map = Map<TKey, TValue>.Empty;
        private IEqualityComparer<TKey> _comparer;

        public DictionarySlim() : this(null) { }

        public DictionarySlim(IEqualityComparer<TKey> comparer)
        {
            // TODO: Propagate 
            _comparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        public TValue this[TKey key]
        {
            get => _map.TryGetValue(key, out var value) ? value : throw new KeyNotFoundException();
            set => _map = _map.Set(key, value);
        }

        public ICollection<TKey> Keys => _map.Keys;

        public ICollection<TValue> Values => _map.Values;

        public int Count => _map.Count;

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear() => _map = Map<TKey, TValue>.Empty;

        public bool ContainsKey(TKey key) => _map.TryGetValue(key, out _);

        public bool TryGetValue(TKey key, out TValue value) => _map.TryGetValue(key, out value);

        public bool Remove(TKey key)
        {
            _map = _map.TryRemove(key, out var success);
            return success;
        }

        public Enumerator GetEnumerator() => new Enumerator(_map);

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => new Enumerator(_map);

        IEnumerator IEnumerable.GetEnumerator() => new Enumerator(_map);

        // TODO
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
    }
}