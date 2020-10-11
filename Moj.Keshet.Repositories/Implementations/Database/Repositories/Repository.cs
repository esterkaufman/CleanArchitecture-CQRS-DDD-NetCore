using AutoMapper;
using Moj.Keshet.Repositories.Interfaces;

namespace Moj.Keshet.Repositories.Implementations.Database.Repositories
{
    internal partial class Repository : IRepository
    {
        #region Fields
        private readonly IMapper _mapper;
        private KeshetEntities _db;
        private readonly Moj.Core.Rest.Common.Logging.ILogger _logger;


        #endregion Fields

        #region ctor

        public Repository(KeshetEntities db, Core.Rest.Common.Logging.ILogger logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion ctor

        #region IDispose

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
            ListItemCacheClear();
        }

        #endregion IDispose
        
    }
}
