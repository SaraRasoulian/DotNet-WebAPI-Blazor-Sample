using Application.Students.Commands;
using Application.Students.Queries;
using Application.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using MediatR;

namespace WebAPI.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllStudentsQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{studentId:long}")]
    public async Task<IActionResult> Get(long studentId)
    {
        var query = new GetStudentByIdQuery(studentId);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateStudentRequest request)
    {
        var command = request.Adapt<CreateStudentCommand>();
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{studentId:long}")]
    public async Task<IActionResult> Put(long studentId, [FromBody] UpdateStudentRequest request)
    {
        var command = request.Adapt<UpdateStudentCommand>();
        if (studentId != command.Id) return BadRequest();
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{studentId:long}")]
    public async Task<IActionResult> Delete(long studentId)
    {
        var command = new DeleteStudentCommand(studentId);
        await _mediator.Send(command);
        return Ok();
    }
}
