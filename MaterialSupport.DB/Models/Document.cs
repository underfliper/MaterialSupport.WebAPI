using System.Collections.Generic;

namespace MaterialSupport.DB.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public List<ApplicationsDocuments> Applications { get; set; }
    }
}
