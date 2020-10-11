namespace Moj.Keshet.Domain.Interfaces
{
    public interface IListItem
    {

        int Id { get; }
        string Name { get; }
        public int ParentId { get; }
        bool IsActive { get; }

    }
}
