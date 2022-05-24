using System.Collections.Generic;

namespace MaterialSupport.DB.Models
{
    public class SupportType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ApplicationsSupportTypes> Applications { get; set; }
    }
}
