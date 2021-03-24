using System;
using System.Collections.Generic;

namespace IS413_Assignment_9.Models.ViewModels
{
    public class MovieListViewModel
    {
        public MovieListViewModel()
        {
        }

        public IEnumerable<Movie> Movies { get; set; }

        public int? DeleteMovieId { get; set; }
    }
}
