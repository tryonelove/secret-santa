using MediatR;
using SecretSanta.Backend.Foundation.UserServices.Models;

namespace SecretSanta.Backend.Foundation.UserServices.Queries;

public class GetByIdQuery : IRequest<UserDto>
{
    public int Id { get; }

    public GetByIdQuery(int id)
    {
        Id = id;
    }
}