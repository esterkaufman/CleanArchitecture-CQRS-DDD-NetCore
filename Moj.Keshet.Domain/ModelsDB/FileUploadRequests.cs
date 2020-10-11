using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class FileUploadRequests
    {
        public FileUploadRequests()
        {
            FileUploadDocuments = new HashSet<FileUploadDocuments>();
            FileUploadDocumentsHistory = new HashSet<FileUploadDocumentsHistory>();
        }

        public long FupRequestID { get; set; }
        public int EntityID { get; set; }
        public long EntityInstanceID { get; set; }
        public long? ParentInstanceID { get; set; }
        public string FupRequestObject { get; set; }
        public string SenderIdNumber { get; set; }
        public bool? IsPending { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<FileUploadDocuments> FileUploadDocuments { get; set; }
        public virtual ICollection<FileUploadDocumentsHistory> FileUploadDocumentsHistory { get; set; }
    }
}
