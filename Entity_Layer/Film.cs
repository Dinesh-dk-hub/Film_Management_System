using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Layer
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int OriginalLanguageId { get; set; }
        public DateTime RentalDuration { get; set; }
        public int Length { get; set; }
        public int ReplacementCost { get; set; }
        public int Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public int ActorId { get; set; }
        public int CategoryId { get; set; }
    }
}
