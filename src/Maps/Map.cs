// Copyright (c) Ben A Adams. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Ben.Collections
{
    internal abstract partial class Map<TKey, TValue>
    {
        private static readonly EqualityComparer<TKey> Comparer = EqualityComparer<TKey>.Default;

        public static Map<TKey, TValue> Empty { get; } = new EmptyMap();

        public abstract int Count { get; }

        public abstract Map<TKey, TValue> Set(TKey key, TValue value);

        public abstract Map<TKey, TValue> TryRemove(TKey key, out bool success);

        public abstract bool TryGetValue(TKey key, out TValue value);

        public virtual DictionarySlim<TKey, TValue>.Enumerator GetEnumerator() => new DictionarySlim<TKey, TValue>.Enumerator(this);

        public abstract bool TryGetNext(ref int index, out KeyValuePair<TKey, TValue> value);

        public abstract ICollection<TKey> Keys { get; }

        public abstract ICollection<TValue> Values { get; }
    }
}
