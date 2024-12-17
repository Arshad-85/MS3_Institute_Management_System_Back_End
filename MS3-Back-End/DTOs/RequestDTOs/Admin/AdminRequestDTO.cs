﻿using MS3_Back_End.Entities;

namespace MS3_Back_End.DTOs.RequestDTOs.Admin
{
    public class AdminRequestDTO
    {
        public AdminRole Role { get; set; }
        public string Nic { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public enum AdminRole
    {
        Administrator = 1,
        Instructor = 2,
    }
}
