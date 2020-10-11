using Moj.Keshet.Services.Interfaces;

namespace Moj.Keshet.Repositories.Interfaces
{
    public interface IRepository :
        IBaseRepository,        
        IProcessesRepository,
        IContactsRepository {
    }
}
