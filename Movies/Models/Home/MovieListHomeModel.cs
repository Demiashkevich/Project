using Movies.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MovieListHomeModel
    {
        public MovieListHomeModel() 
        {
            ItemsHome = new Collection<MovieHoverModel>();

            DataList dataReader = new DataList();
            dataReader.Connection("Select ID_Movies, Title, TimePublish, Poster From Movie");

            for(int i = 0; i < 8; i++)
            {                
                ItemsHome.Add(dataReader.GetMovieHoverModel());
            }

            dataReader.Dispose();
        }

        
        public Collection<MovieHoverModel> ItemsHome { get; set; }
        
    }
}