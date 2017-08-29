// Copyright (c) Ben A Adams. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Ben.Collections
{
    internal abstract partial class Map<TKey, TValue>
    {
        // Instance without any key/value pairs. Used as a singleton.
        private sealed class EmptyMap : Map<TKey, TValue>
        {
            public override int Count => 0;

            public override Map<TKey, TValue> Set(TKey key, TValue value)
            {
                // Create a new one-element map to store the key/value pair
                return new OneElementKeyedMap(key, value);
            }

            public override bool TryGetValue(TKey key, out TValue value)
            {
                // Nothing here
                value = default(TValue);
                return false;
            }

            public override Map<TKey, TValue> TryRemove(TKey key, out bool success)
            {
                // Nothing to remove
                success = false;
                return this;
            }

            public override bool TryGetNext(ref int index, out KeyValuePair<TKey, TValue> value)
            {
                value = default(KeyValuePair<TKey, TValue>);
                return false;
            }

            public override ICollection<TKey> Keys => new TKey[0];

            public override ICollection<TValue> Values => new TValue[0];
        }
    }
}
