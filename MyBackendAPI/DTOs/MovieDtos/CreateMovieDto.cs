﻿using MyBackendAPI.Models;

namespace MyBackendAPI.DTOs.MovieDtos
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public int AgeRating { get; set; }
        public int Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Trailer { get; set; }
    }
}
