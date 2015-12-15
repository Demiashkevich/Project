using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MovieHoverModel
    {
        public MovieHoverModel() {}
        public int ID_Movie { get; set; }
        public string MovieUrl { get; set; }
        public string Name { get; set; }
        public DateTime Data { get; set; }  
        
    }
}