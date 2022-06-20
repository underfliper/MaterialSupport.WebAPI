using MaterialSupport.DB.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MaterialSupport.Core.Dto
{
    public class ApplicationShortDto
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Status Status { get; set; }
    }
}
