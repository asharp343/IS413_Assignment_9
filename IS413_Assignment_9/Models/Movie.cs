using System;
using System.ComponentModel.DataAnnotations;

namespace IS413_Assignment_9.Models
{
    public class Movie
    {
        public Movie()
        {
        }

        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Maximum 25 characters")]
        public string? Note { get; set; }
    }
}
