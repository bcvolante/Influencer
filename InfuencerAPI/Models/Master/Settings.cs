﻿namespace InfuencerAPI.Models.Master
{
    public class Settings
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public bool IsManageable { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
