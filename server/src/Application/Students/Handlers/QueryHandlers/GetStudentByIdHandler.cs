using Application.Students.Queries;
using Application.ResponseModels;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Students.Handlers.QueryHandlers;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentResponse>
{
    private readonly IStudentRepository _studentRepository;
    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<StudentResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _studentRepository.GetById(request.StudentId);
        return result.Adapt<StudentResponse>();
    }
}