using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Movies.Models.AboutMovie
{
    public class GenreModel
    {
        public GenreModel()
        {
            Genre = new Collection<string>();
        }
        public Collection<string> Genre { get; set; }
    }
}