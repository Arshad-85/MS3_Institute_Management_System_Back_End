﻿using MS3_Back_End.Entities;

namespace MS3_Back_End.IRepository
{
    public interface ICourseCategoryRepository
    {
        Task<CourseCategory> AddCategory(CourseCategory categoryReq);
        Task<CourseCategory> GetCourseCategoryById(Guid Id);
        Task<CourseCategory> UpdateCourseCategory(CourseCategory courseCategory);
        Task<List<CourseCategory>> GetAllGetCourseCategory();

    }
}



