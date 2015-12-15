using Movies.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Movies.Database
{
    public class DataList
    {
        SqlDataReader reader;
        SqlCommand command;
        SqlConnection connection;

        public void Connection(string sqlCommand)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);            
            connection.Open();
            command = new SqlCommand(sqlCommand);                
            command.Connection = connection;            
            reader = command.ExecuteReader();
        }

        

        public MovieHoverModel GetMovieHoverModel() 
        {
            MovieHoverModel MovieHoverModel = null;            
                                    
            if (reader.Read())
            {
                MovieHoverModel = new MovieHoverModel();
                MovieHoverModel.ID_Movie = Int32.Parse(reader["ID_Movies"].ToString());
                MovieHoverModel.Name = reader["Title"].ToString();
                MovieHoverModel.Data = DateTime.Parse(reader["TimePublish"].ToString());
                MovieHoverModel.MovieUrl = reader["Poster"].ToString();                
            }            
               
            return MovieHoverModel;
        }

        public int GetNumberMovie()
        {
            reader.Read();          
            return reader.GetInt32(0);
        }       

        public void Dispose()
        {
            reader.Dispose();
            command.Dispose();
            connection.Dispose();            
        }

        public void ConnectionWithParametrs(string sqlCommand, string genre)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();
            command = new SqlCommand(sqlCommand);
            command.Connection = connection;
            command.Parameters.Add("genre", genre);
            reader = command.ExecuteReader();
        }
        
    }

     
}
