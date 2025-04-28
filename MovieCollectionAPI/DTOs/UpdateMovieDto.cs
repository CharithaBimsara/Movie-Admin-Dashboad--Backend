using System.ComponentModel.DataAnnotations;

namespace MovieCollectionAPI.DTOs
{
    public class UpdateMovieDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [Range(1888, 2100)]
        public int ReleaseYear { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; } = string.Empty;

        [Range(0, 10)]
        public decimal Rating { get; set; }

        public bool Watched { get; set; }
    }
}
