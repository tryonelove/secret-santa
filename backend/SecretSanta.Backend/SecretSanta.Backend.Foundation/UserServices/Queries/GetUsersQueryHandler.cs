using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Backend.DataAccess;
using SecretSanta.Backend.Foundation.UserServices.Models;

namespace SecretSanta.Backend.Foundation.UserServices.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IReadOnlyCollection<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dataContext;


    public GetUsersQueryHandler(IMapper mapper, ApplicationDbContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }


    public async Task<IReadOnlyCollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _dataContext.Users.ToListAsync(cancellationToken);

        var usersDto = _mapper.Map<ICollection<UserDto>>(users);

        return usersDto.ToArray();
    }
}