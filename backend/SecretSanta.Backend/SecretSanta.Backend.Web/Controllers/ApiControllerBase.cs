using Microsoft.AspNetCore.Mvc;

namespace SecretSanta.Backend.Web.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public abstract class ApiControllerBase : ControllerBase
{

}