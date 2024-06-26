﻿using System.Collections;
using System.Linq.Expressions;

namespace ButtonData;

public class EnhancedList<T>
{
    private List<T> _contents = new();
    public int Count => _contents.Count;

    public event EventHandler<DataEventArgs> ItemAdded;
    public event EventHandler<DataEventArgs> ItemRemoved;

    public void Add(T item)
    {
        _contents.Add(item);
        ItemAdded?.Invoke(this, new DataEventArgs(item));
    }

    public void RemoveAt(int index)
    {
        ItemRemoved?.Invoke(this, new DataEventArgs(_contents[index]));
        _contents.RemoveAt(index);
    }

    public void ForEach(Action<T> action) => _contents.ForEach(action);

    public T GetAt(int index) => _contents[index];
}