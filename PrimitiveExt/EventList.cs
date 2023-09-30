using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveExt
{
    /// <summary>
    /// This extends C# List type, adds events to list, item added and remove event
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventList<T> : IList<T>
    {
        private readonly List<T> _list;

        public EventList()
        {
            _list = new List<T>();
        }

        public EventList(IEnumerable<T> collection)
        {
            _list = new List<T>(collection);
        }

        public EventList(int capacity)
        {
            _list = new List<T>(capacity);
        }

        public event EventHandler<EventListArgs<T>> ItemAdded;
        public event EventHandler<EventListArgs<T>> ItemRemoved;
        public event EventHandler ListCleared;

        public int FindIndex(Predicate<T> item)
        {
            return _list.FindIndex(item);
        }

        private void RaiseEvent(EventHandler<EventListArgs<T>> eventHandler, T item, int index)
        {
            var eh = eventHandler;
            eh?.Invoke(this, new EventListArgs<T>(item, index));
        }

        private void RaiseEvent(EventHandler eventHandler)
        {
            var eh = eventHandler;
            eh?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            var index = _list.Count;
            _list.Add(item);
            RaiseEvent(ItemAdded, item, index);
        }

        public void Clear()
        {
            for (var index = 0; index < _list.Count; index++)
            {
                var item = _list[index];
                RaiseEvent(ItemRemoved, item, index);
            }

            _list.Clear();
            RaiseEvent(ListCleared);
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            var index = _list.IndexOf(item);

            if (_list.Remove(item))
            {
                RaiseEvent(ItemRemoved, item, index);
                return true;
            }

            return false;
        }

        public int Count => _list.Count;
        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            RaiseEvent(ItemRemoved, item, index);
        }

        public void RemoveAt(int index)
        {
            var item = _list[index];
            _list.RemoveAt(index);
            RaiseEvent(ItemRemoved, item, index);
        }

        public T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }
    }

    public class EventListArgs<T> : EventArgs
    {
        public EventListArgs(T item, int index)
        {
            Item = item;
            Index = index;
        }

        public T Item { get; }
        public int Index { get; }
    }
}
