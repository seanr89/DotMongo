using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;
using MongoAPI.Services;

namespace MongoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly EventService _eventService;
    private readonly ILogger<EventController> _logger;
    public EventController(EventService eventService, ILogger<EventController> logger)
    {
        this._eventService = eventService;
        this._logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetAll()
    {
        var data = await _eventService.GetAllAsync();
        return Ok(data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetById(Guid id)
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="evnt"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(Event evnt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        await _eventService.CreateAsync(evnt);
        return Ok(evnt);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, Event updatedEvent)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var queriedRecord = await _eventService.GetByIdAsync(id);
        if(queriedRecord == null)
        {
            return NotFound();
        }
        await _eventService.UpdateAsync(id, updatedEvent);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var rec = await _eventService.GetByIdAsync(id);
        if (rec == null)
        {
            return NotFound();
        }

        await _eventService.DeleteAsync(id);

        return NoContent();
    }
}