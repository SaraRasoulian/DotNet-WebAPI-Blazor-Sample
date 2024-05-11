using Application.ResponseModels;
using MediatR;

namespace Application.Students.Queries;

public record GetStudentByIdQuery(long StudentId) : IRequest<StudentResponse>;