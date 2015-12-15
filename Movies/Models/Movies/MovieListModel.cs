using Movies.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MovieListModel
    {
        public MovieListModel() 
        { 
            ItemsMovie = new Collection<MovieHoverModel>();

            DataList dataList = new DataList();
            dataList.Connection("Select Count (*) From Movie ");
            var num = dataList.GetNumberMovie();
            dataList.Dispose();

            dataList.Connection("Select ID_Movies, Title, TimePublish, Poster From Movie");
            
            for(int i = 0; i < num; i++)
            {
                ItemsMovie.Add(dataList.GetMovieHoverModel());
            }
            dataList.Dispose();
        }

        public MovieListModel(string genre)
        {
            ItemsMovie = new Collection<MovieHoverModel>();

            DataList dataList = new DataList();
            dataList.ConnectionWithParametrs("Select Count (*) From ID_Movie_Genre Join Genre On ID_Movie_Genre.ID_Genre = Genre.ID_Genre Where Genre.Name = @genre", genre);
            var num = dataList.GetNumberMovie();
            dataList.Dispose();

            dataList.ConnectionWithParametrs("Select ID_Movies, Title, TimePublish, Poster, Genre.Name From ID_Movie_Genre Join Movie On ID_Movie_Genre.ID_Movie = Movie.ID_Movies  Join Genre On ID_Movie_Genre.ID_Genre = Genre.ID_Genre Where Genre.Name = @genre", genre);

            for (int i = 0; i < num; i++)
            {
                ItemsMovie.Add(dataList.GetMovieHoverModel());
            }
            dataList.Dispose();
        }

        public Collection<MovieHoverModel> ItemsMovie { get; set; }
    }
}