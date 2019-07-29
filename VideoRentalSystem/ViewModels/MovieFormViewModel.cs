using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalSystem.Models;

namespace VideoRentalSystem.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public bool New { get; set; }
    }
}