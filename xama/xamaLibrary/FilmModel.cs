using System;
using System.Collections.Generic;
using System.Text;

namespace xamaLibrary
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public DateTime DatePremier { get; set; }
        public string Starring { get; set; }
    }
}
