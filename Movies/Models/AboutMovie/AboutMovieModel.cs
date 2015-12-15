using Movies.Models.AboutMovie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class AboutMovieModel 
    {
        public AboutMovieModel ()
        {
           
        }
        public string Article { get; set; }
        public string Director { get; set; }
        public string Writers { get; set; }        
        public string RunTime { get; set; }
    }
}