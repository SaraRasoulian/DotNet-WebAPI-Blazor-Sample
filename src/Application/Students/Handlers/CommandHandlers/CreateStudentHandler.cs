using Application.Students.Commands;
using Application.ResponseModels;
using Domain.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Students.Handlers.CommandHandlers;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentResponse>
{
    private readonly IStudentRepository _studentRepository;
    public CreateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        Student toAdd = request.Adapt<Student>();
        var result = await _studentRepository.Add(toAdd);
        await _studentRepository.SaveChanges();

        return result.Adapt<StudentResponse>();
    }
}
