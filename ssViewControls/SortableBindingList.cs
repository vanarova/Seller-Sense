using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;

public class SortableBindingList<T> : BindingList<T>
{
    // reference to the list provided at the time of instantiation
    private List<T> _originalList;
    private ListSortDirection? _sortDirection;
    private PropertyDescriptor _sortProperty;

    protected override bool IsSortedCore => _sortDirection != null;
    protected override bool SupportsSortingCore => true;
    protected override ListSortDirection SortDirectionCore => _sortDirection ?? ListSortDirection.Ascending;
    protected override PropertyDescriptor SortPropertyCore => _sortProperty;

    public SortableBindingList()
    {
        _originalList = new List<T>();
    }

    public SortableBindingList(List<T> list)
    {
        _originalList = list;
        ResetItems(_originalList);
    }

    public void Sort(PropertyDescriptor property, ListSortDirection direction) => this.ApplySortCore(property, direction);

    protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
    {
        _sortProperty = property;
        _sortDirection = direction;

        if (!(Items is List<T> items))
            return;

        items.Sort((left, right) =>
        {
            var compareRes = Compare(left == null ? null : _sortProperty.GetValue(left),
                                        right == null ? null : _sortProperty.GetValue(right));
            if (_sortDirection == ListSortDirection.Descending)
                return -compareRes;
            return compareRes;
        });

        ResetBindings();
    }

    private static int Compare(object lhs, object rhs)
    {
        if (lhs == null)
            return rhs == null ? 0 : -1;
        if (rhs == null)
            return 1;
        if (lhs is IComparable comparable)
            return comparable.CompareTo(rhs);
        return lhs.Equals(rhs) ? 0 : string.Compare(lhs.ToString(), rhs.ToString(), StringComparison.Ordinal);
    }

    protected override void RemoveSortCore()
    {
        _sortDirection = null;
        ResetItems(_originalList);
    }

    private void ResetItems(List<T> items)
    {
        base.ClearItems();

        for (var i = 0; i < items.Count; i++)
        {
            base.InsertItem(i, items[i]);
        }
    }

    protected override void OnListChanged(ListChangedEventArgs e)
    {
        _originalList = Items.ToList();
    }
}