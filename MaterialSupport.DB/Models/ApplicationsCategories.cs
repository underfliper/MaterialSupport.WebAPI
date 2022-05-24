using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialSupport.DB.Models
{
    public class ApplicationsCategories
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
