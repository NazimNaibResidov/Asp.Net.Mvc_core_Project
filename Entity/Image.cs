using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string BigPath { get; set; }
        public string MidelPath { get; set; }
        public string SmallPath { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
