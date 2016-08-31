using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Xamarin.Forms.BaiduMaps
{
    internal abstract class BaseItemImpl<TItem, TMap, TNative>
        where TItem : BaseItem
        where TMap : class
        where TNative : class
    {
        public TMap NativeMap { get; internal set; }
        public Map Map { get; private set; }

        protected abstract IList<TItem> GetItems(Map map);
        protected abstract TNative CreateNativeItem(TItem item);
        protected abstract void UpdateNativeItem(TItem item);
        protected abstract void RemoveNativeItem(TItem item);
        protected abstract void RemoveNativeItems(IList<TItem> items);

        internal virtual void Register(Map map, TMap nativeMap)
        {
            if (null == nativeMap || null == map) {
                return;
            }

            NativeMap = nativeMap;
            Map = map;
            ((INotifyCollectionChanged)GetItems(map)).CollectionChanged += OnCollectionChanged;
        }

        internal virtual void Unregister(Map map)
        {
            if (null == map || null == GetItems(map)) {
                return;
            }

            ((INotifyCollectionChanged)GetItems(map)).CollectionChanged -= OnCollectionChanged;
        }

        protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddItems(e.NewItems);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    RemoveItems(e.OldItems);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    RemoveItems(e.OldItems);
                    AddItems(e.NewItems);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    ResetItems();
                    break;

                case NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }

        private readonly IList<TItem> copiedItems = new List<TItem>();
        protected void AddItems(IList newItems)
        {
            if (null == NativeMap) {
                return;
            }

            foreach (TItem item in newItems) {
                item.PropertyChanged += OnItemPropertyChanged;

                if (null != CreateNativeItem(item)) {
                    copiedItems.Add(item);
                }
            }
        }

        protected void RemoveItems(IList oldItems)
        {
            if (null == NativeMap) {
                return;
            }

            foreach (TItem item in oldItems) {
                item.PropertyChanged -= OnItemPropertyChanged;
                RemoveNativeItem(item);
                copiedItems.Remove(item);
            }
        }

        protected void ResetItems()
        {
            foreach (TItem item in copiedItems) {
                item.PropertyChanged -= OnItemPropertyChanged;
            }

            RemoveNativeItems(copiedItems);
            copiedItems.Clear();
        }

        internal void NotifyReset()
        {
            OnCollectionChanged(GetItems(Map), new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        internal void NotifyUpdate(TItem item)
        {
            UpdateNativeItem(item);
        }

        internal abstract void OnMapPropertyChanged(PropertyChangedEventArgs e);

        protected abstract void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e);
    }
}

