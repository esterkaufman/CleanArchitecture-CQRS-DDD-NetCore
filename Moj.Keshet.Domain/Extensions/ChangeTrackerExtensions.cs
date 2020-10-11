using Moj.Keshet.Domain.ModelExtensions;
using System;


namespace Moj.Keshet.Domain.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void AsDeleted<T>(this T trackingItem) where T : ObjectChangeTracker
        {
            trackingItem.State = TrackedState.Deleted;
        }

        public static void AsAdded<T>(this T trackingItem) where T : ObjectChangeTracker
        {
            trackingItem.State = TrackedState.Added;
        }

        public static void AsModified<T>(this T trackingItem) where T : ObjectChangeTracker
        {
            trackingItem.State = TrackedState.Modified;
        }

        public static void AsUnchanged<T>(this T trackingItem) where T : ObjectChangeTracker
        {
            trackingItem.State = TrackedState.Unchanged;
        }
    }
    public static class ObjectWithChangeTrackerExtensions
    {
        public static T MarkAsDeleted<T>(this T trackingItem) where T : IObjectWithChangeTracker
        {
            if (trackingItem == null) throw new ArgumentNullException("trackingItem");

            trackingItem.ChangeTracker.AsDeleted();
            return trackingItem;
        }

        public static T MarkAsAdded<T>(this T trackingItem) where T : IObjectWithChangeTracker
        {
            if (trackingItem == null) throw new ArgumentNullException("trackingItem");

            trackingItem.ChangeTracker.AsAdded();
            return trackingItem;
        }

        public static T MarkAsModified<T>(this T trackingItem) where T : IObjectWithChangeTracker
        {
            if (trackingItem == null) throw new ArgumentNullException("trackingItem");

            trackingItem.ChangeTracker.AsModified();
            return trackingItem;
        }

        public static T MarkAsUnchanged<T>(this T trackingItem) where T : IObjectWithChangeTracker
        {
            if (trackingItem == null) throw new ArgumentNullException("trackingItem");

            trackingItem.ChangeTracker.AsUnchanged();
            return trackingItem;
        }
    }
}
