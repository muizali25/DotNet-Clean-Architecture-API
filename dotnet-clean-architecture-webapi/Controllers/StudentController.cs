using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using Services.Services;

namespace BasicCleanArchitecture.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
   
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDTO>> GetById(int id)
    {
        var student = await _studentService.GetStudent(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }
   
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAll()
    {
        var students = await _studentService.GetStudents();
        return Ok(students);
    }
   
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentDTO form)
    {
        await _studentService.AddStudent(form);
        return NoContent();
    }
   
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDTO form)
    {
        if (form.ID != id)
            return BadRequest("Student ID mismatch.");

        await _studentService.UpdateStudent(form);
        return NoContent();
    }
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentService.DeleteStudent(id);
        return NoContent();
    }
}

