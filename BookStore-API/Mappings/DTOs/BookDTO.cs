﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_API.Mappings.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string File { get; set; }

        public int? AuthorId { get; set; }
        public virtual AuthorDTO Author { get; set; }
    }

    public class BookCreateDTO
    {
        [Required]
        public string Title { get; set; }
        public int? Year { get; set; }
        [Required]
        public string Isbn { get; set; }
        [StringLength(500)]
        public string Summary { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public string File { get; set; }

        [Required]
        public int? AuthorId { get; set; }
    }

    public class BookUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        [StringLength(500)]
        public string Summary { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public string File { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int? AuthorId { get; set; }
    }
}
