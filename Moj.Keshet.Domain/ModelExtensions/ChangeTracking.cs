namespace Moj.Keshet.Domain.ModelExtensions
{
    public enum TrackedState
    {
        Unchanged,
        Added,
        Deleted,
        Modified,
    }

    public interface IObjectWithChangeTracker
    {
        ObjectChangeTracker ChangeTracker { get; set; }
    }

    public class ObjectChangeTracker
    {
        public TrackedState State { get; set; }

        public ObjectChangeTracker()
        {
            State = TrackedState.Added;
        }

        public override string ToString()
        {
            return string.Format("TrackedState: {0}", State);
        }
    }

    /// 
    //[Flags]
    //public enum ObjectState
    //{
    //    Unchanged = 0x1,
    //    Added = 0x2,
    //    Modified = 0x4,
    //    Deleted = 0x8
    //}

    //public interface IObjectStateTrackerBase
    //{
    //    ObjectState State { get; set; }
    //}

    //public interface IObjectStateTracker : IObjectStateTrackerBase
    //{
    //    int ID { get; }
    //}
}
