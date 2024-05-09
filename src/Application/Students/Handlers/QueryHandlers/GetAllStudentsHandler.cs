using Application.ResponseModels;
using Application.Students.Queries;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Students.Handlers.QueryHandlers;

public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IList<StudentResponse>>
{
    private readonly IStudentRepository _studentRepository;
    public GetAllStudentsHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<IList<StudentResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var result = await _studentRepository.GetAll();
        return result.Adapt<IList<StudentResponse>>();
    }
}