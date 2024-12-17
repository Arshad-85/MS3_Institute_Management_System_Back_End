﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS3_Back_End.DTOs.RequestDTOs.Ènrollment;
using MS3_Back_End.DTOs.ResponseDTOs.Enrollment;
using MS3_Back_End.IService;
using MS3_Back_End.Service;

namespace MS3_Back_End.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollementService _enrollmentService;
        public EnrollmentController(IEnrollementService enrollement)
        {
            _enrollmentService = enrollement;
        }

        [HttpPost]
        public async Task<ActionResult<EnrollmentResponseDTO>> AddEnrollment(EnrollmentRequestDTO enrollmentReq)
        {
            try
            {
                var enrollment = await _enrollmentService.AddEnrollment(enrollmentReq);
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Enrollment/{id}")]
        public async Task<ActionResult<EnrollmentResponseDTO>> GetEnrollmentById(Guid id)
        {
            try
            {
                var enrollment = await _enrollmentService.GetEnrollmentId(id);
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Enrollments/{StudentId}")]
        public async Task<ActionResult<ICollection<EnrollmentResponseDTO>>> GetEnrollmentsByStudentId(Guid StudentId)
        {
            try
            {
                var enrollments = await _enrollmentService.GetEnrollmentsByStudentId(StudentId);
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Enrollments")]
        public async Task<ActionResult<ICollection<EnrollmentResponseDTO>>> GetAllEnrollments()
        {
            try
            {
                var enrollments = await _enrollmentService.GetAllEnrollements();
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEnrollment(Guid id)
        {
            try
            {
                var result = await _enrollmentService.DeleteEnrollment(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
