using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class Image : IDbModel
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Extension { get; set; }
    }
}
