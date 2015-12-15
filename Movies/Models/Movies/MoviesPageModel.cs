using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MoviesPageModel
    {
        public MoviesPageModel(string genre) 
        {            
            MovieListModel = new MovieListModel(genre);            
        }
        public MoviesPageModel()
        {
            MovieListModel = new MovieListModel();    
        }
        public MovieListModel MovieListModel { get; set; }        
    }
}