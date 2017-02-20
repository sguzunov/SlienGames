﻿using System.ComponentModel.DataAnnotations;

using SlienGames.Data.Models.Constants;

namespace SlienGames.Data.Models
{
    public class FileInfo 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.FileInfoFileNameMaxLength)]
        public string FileName { get; set; }

        [Required]
        [MinLength(ValidationConstants.FileInfoFileExtensionMinLength)]
        [MaxLength(ValidationConstants.FileInfoFileExtensionMaxLength)]
        public string FileExtension { get; set; }

        public string FileSystemUrlPath { get; set; }
    }
}
