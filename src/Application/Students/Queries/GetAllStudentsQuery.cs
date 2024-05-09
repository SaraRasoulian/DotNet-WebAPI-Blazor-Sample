using Application.ResponseModels;
using MediatR;

namespace Application.Students.Queries;

public record GetAllStudentsQuery : IRequest<IList<StudentResponse>>;