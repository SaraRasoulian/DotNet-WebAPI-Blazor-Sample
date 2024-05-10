using Application.Students.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Students.Handlers.CommandHandlers;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    public DeleteStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var toDelete = await _studentRepository.GetById(request.StudentId);
        if (toDelete is null) throw new ArgumentException("Student not found");

        _studentRepository.Delete(toDelete);
        await _studentRepository.SaveChanges();
    }
}
