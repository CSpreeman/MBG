using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITM.Models
{
    public class Comment
    {

        public int ID { get; set; }

        public int BlogId { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public int? ParentCommentId { get; set; }

    }
}