using Application.Students.Commands;
using Application.ResponseModels;
using Domain.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Students.Handlers.CommandHandlers;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, StudentResponse>
{
    private readonly IStudentRepository _studentRepository;
    public UpdateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<StudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetById(request.Id);
        if (student is null) throw new Exception("Student Not Found");

        Student toUpdate = request.Adapt<Student>();

        var result = _studentRepository.Update(toUpdate);
        await _studentRepository.SaveChanges();
        return result.Adapt<StudentResponse>();
    }
}
