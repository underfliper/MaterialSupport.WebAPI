using MaterialSupport.DB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaterialSupport.Core.Dto
{
    public class ApplicationViewDto
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Group { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Status Status { get; set; }

        public List<ApplicationsCategoriesDto> Categories { get; set; }

        public List<ApplicationsSupportTypesDto> SupportTypes { get; set; }

        public List<ApplicationsDocumentsDto> Documents { get; set; }
    }
}
