using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSupport.DB.Models
{
    public class ApplicationsDocuments
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
    }
}
