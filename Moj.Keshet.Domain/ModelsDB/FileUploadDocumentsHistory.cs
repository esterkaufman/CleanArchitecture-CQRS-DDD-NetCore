using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class FileUploadDocumentsHistory
    {
        public long FupDocumentID { get; set; }
        public long FupRequestID { get; set; }
        public Guid Guid { get; set; }
        public string DocumentName { get; set; }
        public string Extension { get; set; }
        public byte FupFileStatusTypeID { get; set; }
        public int DocumentTypeID { get; set; }
        public bool IsForDistribution { get; set; }
        public string DocumentTitle { get; set; }
        public DateTime? FumsAddTime { get; set; }
        public DateTime? FumsResponseTime { get; set; }
        public string FumsObject { get; set; }
        public string MojID { get; set; }
        public long? FileSize { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual FileUploadFileStatusTypes FupFileStatusType { get; set; }
        public virtual FileUploadRequests FupRequest { get; set; }
    }
}
