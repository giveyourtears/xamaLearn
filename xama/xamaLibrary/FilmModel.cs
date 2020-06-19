using System;
using System.Collections.Generic;
using System.Text;

namespace xamaLibrary
{
    public class FilmModel
    {
        public int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int Duration { get; set; }
        string Genre { get; set; }
        DateTime DatePremier { get; set; }
        string Starring { get; set; }
    }
}
