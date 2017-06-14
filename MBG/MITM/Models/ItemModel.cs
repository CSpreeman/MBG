using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITM.Models
{
    public class ItemModel<T> : Blog
    {
        public T Item { get; set; }   
    }
}