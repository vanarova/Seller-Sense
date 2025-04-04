﻿using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;

public class SortableBindingList<T> : BindingList<T>
{
    private bool isSortedValue;
    ListSortDirection sortDirectionValue;
    PropertyDescriptor sortPropertyValue;

    public SortableBindingList()
    {
    }

    public SortableBindingList(IList<T> list)
    {
        foreach (object o in list)
        {
            this.Add((T)o);
        }
    }

    protected override void ApplySortCore(PropertyDescriptor prop,
        ListSortDirection direction)
    {
        Type interfaceType = prop.PropertyType.GetInterface("IComparable");

        if (interfaceType == null && prop.PropertyType.IsValueType)
        {
            Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

            if (underlyingType != null)
            {
                interfaceType = underlyingType.GetInterface("IComparable");
            }
        }

        if (interfaceType != null)
        {
            sortPropertyValue = prop;
            sortDirectionValue = direction;

            IEnumerable<T> query = base.Items;

            if (direction == ListSortDirection.Ascending)
            {
                query = query.OrderBy(i => prop.GetValue(i));
            }
            else
            {
                query = query.OrderByDescending(i => prop.GetValue(i));
            }

            int newIndex = 0;
            foreach (object item in query)
            {
                this.Items[newIndex] = (T)item;
                newIndex++;
            }

            isSortedValue = true;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        else
        {
            throw new NotSupportedException("Cannot sort by " + prop.Name +
                ". This" + prop.PropertyType.ToString() +
                " does not implement IComparable");
        }
    }

    protected override PropertyDescriptor SortPropertyCore
    {
        get { return sortPropertyValue; }
    }

    protected override ListSortDirection SortDirectionCore
    {
        get { return sortDirectionValue; }
    }

    protected override bool SupportsSortingCore
    {
        get { return true; }
    }

    protected override bool IsSortedCore
    {
        get { return isSortedValue; }
    }
}