using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    
    public class IndexPageModel
    {
        public IndexPageModel(){
            MovieListHomeModel = new MovieListHomeModel();
        }
        public MovieListHomeModel MovieListHomeModel { get; set; }

    }
}