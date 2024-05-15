using System.Collections.Generic;

namespace NebulaNexus.Utilities
{
    /// <summary>
    /// Structure to hold Item and its state
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PooledItem<T> where T : class
    {
        public T Item;
        public bool IsUsed;
    }

    /// <summary>
    /// Generic Pool Class
    /// </summary>
    /// <typeparam name="T">Generic Pooled Type</typeparam>
    public abstract class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledList = new();

        /// <summary>
        /// Method to get item from pooled list
        /// </summary>
        /// <returns>Generic Pooled Type</returns>
        public T GetItem<U>() where U : T
        {
            if (pooledList.Count > 0)
            {
                PooledItem<T> pooledItem = pooledList.Find(item => !item.IsUsed && item.Item is U);
                if (pooledItem != null)
                {
                    pooledItem.IsUsed = true;
                    return pooledItem.Item;
                }
            }
            return CreateNewItem<U>();
        }

        /// <summary>
        /// If not available, create new pooled items
        /// </summary>
        /// <returns>Generic Pooled Type</returns>
        private T CreateNewItem<U>()
        {
            PooledItem<T> pooledItem = new();
            pooledItem.Item = CreateItem<U>();
            pooledItem.IsUsed = true;
            pooledList.Add(pooledItem);
            return pooledItem.Item;
        }

        /// <summary>
        /// To be overriden by child class, to create pooled item object
        /// </summary>
        /// <returns>Generic Pooled Type</returns>
        protected abstract T CreateItem<U>();

        /// <summary>
        /// Return the object to the list
        /// </summary>
        /// <param name="item">Generic Object Type</param>
        public void ReturnItem<U>(T item)
        {
            PooledItem<T> pooledItem = pooledList.Find(i => i.Item.Equals(item) && i.Item is U);
            pooledItem.IsUsed = false;
        }
    }
}