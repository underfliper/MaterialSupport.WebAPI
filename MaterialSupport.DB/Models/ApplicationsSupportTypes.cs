using System.ComponentModel.DataAnnotations.Schema;

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
