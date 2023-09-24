﻿namespace WebMVC.Models.DTO
{
    public class PostRequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
    }
}
