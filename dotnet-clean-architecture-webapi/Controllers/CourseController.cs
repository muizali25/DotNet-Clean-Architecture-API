using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using Services.Services;

namespace BasicCleanArchitecture.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    ICourseService _courseService;  
    public CourseController(ICourseService courseService )
    {
        _courseService = courseService;       
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseDTO form)
    {
        await _courseService.AddCourse(form);
        return NoContent();
    }  
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDTO form)
    {
        if (id != form.ID)
            return BadRequest("Course ID mismatch.");

        await _courseService.UpdateCourse(form);
        return NoContent();
    }
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _courseService.DeleteCourse(id);
        return NoContent();
    }

    [HttpGet("EnrollCourseWithTeacher")]
    public async Task EnrollCourseWithTeacher(int courseId, int teacherId)
    {
        await _courseService.EnrollCourseWithTeacher(courseId, teacherId);
    }

    [HttpGet("EnrollCourseWithStudent")]
    public async Task EnrollCourseWithStudent(int courseId, int studentId)
    {
        await _courseService.EnrollCourseWithStudent(courseId, studentId);
    }

    [HttpGet("GetCoursesByStudentId")]
    public async Task<IEnumerable<CourseDTO>> GetCoursesByStudentId(int studentId)
    {
        return await _courseService.GetCoursesByStudentId(studentId);
    }

    [HttpGet("GetCoursesByTeacherId")]
    public async Task<IEnumerable<CourseDTO>> GetCoursesByTeacherId(int teacherId)
    {
       return await _courseService.GetCoursesByTeacherId(teacherId);
    }
}
