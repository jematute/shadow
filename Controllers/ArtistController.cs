using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace shadow.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{

    private readonly ILogger<EmployeeController> _logger;

    public ArtistController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetArtists")]
    public IActionResult Artists() {
        ChinookContext ctx = new ChinookContext();

        var artists = ctx.Artists.ToList();
        return Ok(artists);
    }


}
