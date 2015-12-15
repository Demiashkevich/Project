using Movies.Models;
using Movies.Models.AboutMovie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Movies.Database
{
    public class DataAboutMovie
    {
        public AboutMoviePageModel GetAboutMovieModel(int id)
        {
            AboutMovieModel aboutMovieModel = null;
            SliderModel sliderModel = null;            
            GenreModel  genreModel = null;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("Select Genre.Name, About, Director, Writers, RunTime, SliderOne, SliderTwo, SliderThree From ID_Movie_Genre Join Genre On ID_Movie_Genre.ID_Genre = Genre.ID_Genre Join Movie On ID_Movie_Genre.ID_Movie = Movie.ID_Movies Where ID_Movie_Genre.ID_Movie = @id"))
                {
                    command.Connection = connection;
                    command.Parameters.Add("id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        genreModel = new GenreModel();
                        
                        if (reader.Read())
                        {
                            sliderModel = new SliderModel();
                            sliderModel.SliderOne = reader["SliderOne"].ToString();
                            sliderModel.SliderTwo = reader["SliderTwo"].ToString();
                            sliderModel.SliderThree = reader["SliderThree"].ToString();
                            aboutMovieModel = new AboutMovieModel();
                            aboutMovieModel.Article = reader["About"].ToString();
                            aboutMovieModel.Director = reader["Director"].ToString();
                            aboutMovieModel.Writers = reader["Writers"].ToString();
                            aboutMovieModel.RunTime = reader["RunTime"].ToString();
                            genreModel.Genre.Add(reader["Name"].ToString());                            
                        }

                        while (reader.Read())
                        {
                            genreModel.Genre.Add(reader["Name"].ToString());
                        }
                    }
                }
            }           
            return new AboutMoviePageModel(aboutMovieModel, sliderModel, genreModel);
        }

    }
}