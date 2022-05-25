using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MaterialSupport.Core.Dto
{
    public class ApplicationFormDto
    {
        public List<CategoryDto> Categories { get; set; }

        public IFormFileCollection Documents { get; set; }
    }
}
