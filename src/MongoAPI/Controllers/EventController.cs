using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;
using MongoAPI.Services;

namespace MongoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly EventService _eventService;
    public EventController(EventService eventService)
    {
        this._eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetAll()
    {
        //throw new NotImplementedException();
        var data = await _eventService.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetById(string id)
    {
        var evnt = await _eventService.GetByIdAsync(id);
        if (evnt == null)
        {
            return NotFound();
        }

        // if (student.Courses.Count > 0)
        // {
        //     var tempList = new List<Course>();
        //     foreach (var courseId in student.Courses)
        //     {
        //         var course = await _courseService.GetByIdAsync(courseId);
        //         if (course != null)
        //             tempList.Add(course);
        //     }
        //     student.CourseList = tempList;
        // }

        return Ok(evnt);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Event evnt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        //throw new NotImplementedException();

        await _eventService.CreateAsync(evnt);
        return Ok(evnt);
    }

    [HttpPut]
    public async Task<IActionResult> Update(string id, Event updatedEvent)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        throw new NotImplementedException();

        // var queriedStudent = await _studentService.GetByIdAsync(id);
        // if(queriedStudent == null)
        // {
        //     return NotFound();
        // }

        // await _studentService.UpdateAsync(id, updatedStudent);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        // var student = await _studentService.GetByIdAsync(id);
        // if (student == null)
        // {
        //     return NotFound();
        // }

        // await _studentService.DeleteAsync(id);

        return NoContent();
    }
}