﻿using System.Collections.Generic;

namespace MaterialSupport.DB.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ApplicationsCategories> Applications { get; set; }
    }
}
