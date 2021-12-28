using MediatR;
using SecretSanta.Backend.Foundation.UserServices.Models;

namespace SecretSanta.Backend.Foundation.UserServices.Queries;

public class GetUsersQuery : IRequest<IReadOnlyCollection<UserDto>>
{

}