using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class FileUploadFileStatusTypes
    {
        public FileUploadFileStatusTypes()
        {
            FileUploadDocuments = new HashSet<FileUploadDocuments>();
            FileUploadDocumentsHistory = new HashSet<FileUploadDocumentsHistory>();
        }

        public byte FupFileStatusTypeID { get; set; }
        public string FupFileStatusTypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FileUploadDocuments> FileUploadDocuments { get; set; }
        public virtual ICollection<FileUploadDocumentsHistory> FileUploadDocumentsHistory { get; set; }
    }
}
