using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Model
{
    public class Speaker
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public List<Speaker> GetSpeakers() {

            List<Speaker> speakers = new List<Speaker>() {
                new Speaker(){Name="person1",Topic="topic1" , Image="https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg",Description="description 1"},
                new Speaker(){Name="person2",Topic="topic2" , Image="http://ia.media-imdb.com/images/M/MV5BMjAxNTQ5NzQyMV5BMl5BanBnXkFtZTcwMjE0MTYyMg@@._V1_SX300.jpg",Description="description 2"},
                new Speaker(){Name="person3",Topic="topic3" , Image="http://ia.media-imdb.com/images/M/MV5BMTIwNjE0NTAxM15BMl5BanBnXkFtZTcwMzE0MTgyMQ@@._V1_SX300.jpg",Description="description 3"},
                new Speaker(){Name="person4",Topic="topic4" , Image="http://ia.media-imdb.com/images/M/MV5BMTIwNjE0NTAxM15BMl5BanBnXkFtZTcwMzE0MTgyMQ@@._V1_SX300.jpg",Description="description 4"}
            };
            return speakers;
        }

    }
}
