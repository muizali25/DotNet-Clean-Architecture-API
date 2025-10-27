using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using Services.Services;

namespace BasicCleanArchitecture.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    ITeacherService _teacherService;
    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDTO>> GetById(int id)
    {
        var teacher =  await _teacherService.GetTeacher(id);

        if (teacher == null)
            return NotFound();
        
            return Ok(teacher);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAll()
    {
        var teachers = await _teacherService.GetTeachers();
        return Ok(teachers);
    }
    

    [HttpPost]
    public async Task Add(CreateTeacherDTO form)
    {
        await _teacherService.AddTeacher(form);
    }

    [HttpPut]
    public async Task Update(UpdateTeacherDTO form)
    {
        await _teacherService.UpdateTeacher(form);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _teacherService.DeleteTeacher(id);
    }   
}
