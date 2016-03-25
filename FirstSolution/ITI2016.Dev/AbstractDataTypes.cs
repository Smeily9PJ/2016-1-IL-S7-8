using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI2016.Dev
{

    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }

    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
    }

    public interface IReadOnlyList<T> : IReadOnlyCollection<T>
    {
        T this[int i] { get; }
    }

    public interface IList<T> : IReadOnlyList<T>
    {
        new T this[int i] { get; set; }

        void Add( T e );

        void InsertAt( int i, T e );

        void RemoveAt( int i );

        void Clear();
    }

    public interface ISet<T> : IReadOnlyCollection<T>
    {
        void Add( T e );

        bool Contains( T e );

        void Remove( T e );
    }

    public struct KeyValuePair<TKey, TValue>
    {
        public readonly TKey Key;
        public readonly TValue Value;

        public KeyValuePair(TKey Key, TValue Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }

    public interface IDictionary<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>
    {
        IEnumerable<TKey> Keys { get; }
        
        IEnumerable<TValue> Values { get; }

        bool ContainsKey(TKey key);

        bool ContainsValue(TValue value);

        bool Remove(TKey key);

        /// <summary>
        /// Gets or setss the value associated to the given key.
        /// When ggetting, the key MUST exist otherwise a <see cref="KeyNotFoundException"/> is thrown
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The associated value</returns>
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Adds a key/value pair. The key MUST NOT exsit otherwise an exception is thrown
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The associated value</param>
        void Add(TKey key, TValue value);
    }

    public interface IEnumerator<T>
    {
        bool MoveNext();

        T Current { get; }
    }

    public interface IEnumeratorJava<T>
    {
        bool HasNext();

        T GetNext();

    }



}
