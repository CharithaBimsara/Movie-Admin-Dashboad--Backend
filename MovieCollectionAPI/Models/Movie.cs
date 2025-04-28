using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MovieCollectionAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public bool Watched { get; set; }
    }
}
