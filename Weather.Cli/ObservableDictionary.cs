using System.Collections;

namespace Weather.Cli
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue> where TKey : notnull
    {
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private void Restore(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }
  
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            item.Value.Save(Convert.ToString(item.Key));
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return File.Exists(item.Key.ToString());
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public int Count => throw new NullReferenceException();
        public bool IsReadOnly => false;
        
        
        /// <summary>
        /// Save bin file
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            return File.Exists(key.ToString());
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load or save binary file
        /// </summary>
        /// <param name="key"></param>
        public TValue this[TKey key]
        {
            get => Storage.Load<TValue>(key.ToString());
            set => value.Save(key.ToString());
        }

        public ICollection<TKey> Keys => throw new NotImplementedException();
        public ICollection<TValue> Values => throw new NotImplementedException();
    }
}