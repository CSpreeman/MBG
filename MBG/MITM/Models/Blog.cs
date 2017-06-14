using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITM.Models
{
    public class Blog
    {

        public int Id { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageLocation { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}