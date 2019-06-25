using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MovieApp.Model
{
    public class Movie
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string BoxOffice { get; set; }
    }

    
}
