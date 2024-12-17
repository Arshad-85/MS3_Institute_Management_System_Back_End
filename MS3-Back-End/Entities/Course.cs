﻿using System.ComponentModel.DataAnnotations;

namespace MS3_Back_End.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public CourseLevel Level { get; set; }
        public decimal CourseFee { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Prerequisites { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid CourseCategoryId { get; set; }

        //Reference
        public CourseCategory? CourseCategory { get; set; }
        public ICollection<CourseSchedule>? CourseSchedules { get; set; }
        public ICollection<Feedbacks>? Feedbacks { get; set; }
        public ICollection<Assessment>? Assessment { get; set; } = new List<Assessment>();

    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,   
        Advanced = 3,
    }
}
