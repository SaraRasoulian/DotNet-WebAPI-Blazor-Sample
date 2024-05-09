using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Students.Queries;
using Application.ResponseModels;
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
}
