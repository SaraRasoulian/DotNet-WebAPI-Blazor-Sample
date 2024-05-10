using Application.ResponseModels;
using MediatR;

namespace Application.Students.Commands;

public record DeleteStudentCommand(long StudentId) : IRequest;