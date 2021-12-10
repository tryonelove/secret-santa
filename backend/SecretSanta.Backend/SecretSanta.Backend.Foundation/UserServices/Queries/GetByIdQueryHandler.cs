using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Backend.DataAccess;
using SecretSanta.Backend.Foundation.UserServices.Models;

namespace SecretSanta.Backend.Foundation.UserServices.Queries;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, UserDto>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dataContext;


    public GetByIdQueryHandler(IMapper mapper, ApplicationDbContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }


    public async Task<UserDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (user is null)
        {
            return null;
        }

        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}