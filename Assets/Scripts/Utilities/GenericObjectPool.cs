﻿using System;
using System.Collections.Generic;

namespace NebulaNexus.Utilities
{
    /// <summary>
    /// Structure to hold Item and its state
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct PooledItem<T> where T : class
    {
        public T Item;
        public bool IsUsed;
    }

    /// <summary>
    /// Generic Pool Class
    /// </summary>
    /// <typeparam name="T">Generic Pooled Type</typeparam>
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledList = new();

        /// <summary>
        /// Method to get item from pooled list
        /// </summary>
        /// <returns>Generic Pooled Type</returns>
        public T GetItem()
        {
            if (pooledList.Count > 0)
            {
                PooledItem<T> pooledItem = pooledList.Find(item => !item.IsUsed);
                if (pooledItem.Item != null)
                {
                    return pooledItem.Item;
                }
            }
            return CreateNewItem();
        }

        /// <summary>
        /// If not available, create new pooled items
        /// </summary>
        /// <returns>Generic Pooled Type</returns>
        private T CreateNewItem()
        {
            PooledItem<T> pooledItem = new PooledItem<T>();
            pooledItem.Item = CreateItem();
            pooledItem.IsUsed = true;
            return pooledItem.Item;
        }

        /// <summary>
        /// To be overriden by child class, to create pooled item object
        /// </summary>
        /// <returns>Generic Pooled Type</returns>
        /// <exception cref="NotImplementedException"></exception>
        protected virtual T CreateItem()
        {
            throw new NotImplementedException("CreateItem() not used!");
        }
    }
}