using System.ComponentModel.DataAnnotations;

using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public abstract class FileInfo : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FileName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string FileExtension { get; set; }

        public string FileSystemUrlPath { get; set; }
    }
}
