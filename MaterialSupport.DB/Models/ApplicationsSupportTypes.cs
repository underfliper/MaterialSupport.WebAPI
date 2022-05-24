using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSupport.DB.Models
{
    public class ApplicationsSupportTypes
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [ForeignKey("SupportTypeId")]
        public SupportType SupportType { get; set; }
    }
}
