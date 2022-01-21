using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTMusicAPI
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        [MaxLength(200)]
        public string AlbumName { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [MaxLength(200)]
        public string? ImageUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        [DataType("decimal(10 ,2)")]
        public int Price { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(200)]
        public string? SampleUrl { get; set; }

    }
}