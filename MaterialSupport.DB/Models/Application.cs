using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialSupport.DB.Models
{
    public class Application
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Status Status { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public List<ApplicationsCategories> Categories { get; set; }

        public List<ApplicationsSupportTypes> SupportTypes { get; set; }

        public List<ApplicationsDocuments> Documents { get; set; }
    }

    public enum Status
    {
        RequiringConsideration,
        PendingConfirmation,
        Approved,
        Denied
    }
}
