using Movies.Database;
using Movies.Models.AboutMovie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class AboutMoviePageModel
    {       
        public AboutMoviePageModel(AboutMovieModel aboutMovieModel, SliderModel sliderModel, GenreModel genreModel)
        {
            AboutMovieModel = aboutMovieModel;
            GenreModel = genreModel;
            SliderModel = sliderModel;
            
        }
       
        public AboutMovieModel AboutMovieModel { get; set; }
        public SliderModel SliderModel { get; set; }
        public GenreModel GenreModel { get; set; }
    }
}