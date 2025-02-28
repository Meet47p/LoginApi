using LoginApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Add this for logging

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;
    private static List<Login> logins = new List<Login>()
    {
        new Login{Id=1, Username="admin", Password="admin", Email="admin@123", Mobile=1234567890},
        new Login{Id=2, Username="user", Password="user", Email="user@123", Mobile=1234567890}
    };

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Login>> GetAllLogins()
    {
        _logger.LogInformation("Fetching all logins.");
        return Ok(logins);
    }

    [HttpGet("{id}", Name = "GetLogin")]
    public ActionResult<Login> GetLogin(int id)
    {
        _logger.LogInformation("Fetching login with ID {LoginId}.", id);
        var login = logins.Find(x => x.Id == id);
        if (login == null)
        {
            _logger.LogWarning("Login with ID {LoginId} not found.", id);
            return NotFound();
        }
        return Ok(login);
    }

    [HttpPost]
    public ActionResult<Login> CreateLogin([FromBody] Login login)
    {
        _logger.LogInformation("Creating a new login for {Username}.", login.Username);
        logins.Add(login);
        return CreatedAtRoute("GetLogin", new { id = login.Id }, login);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLogin(int id)
    {
        _logger.LogInformation("Deleting login with ID {LoginId}.", id);
        var login = logins.Find(x => x.Id == id);
        if (login == null)
        {
            _logger.LogWarning("Login with ID {LoginId} not found for deletion.", id);
            return NotFound();
        }
        logins.Remove(login);
        _logger.LogInformation("Login with ID {LoginId} successfully deleted.", id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateLogin(int id, [FromBody] Login login)
    {
        _logger.LogInformation("Updating login with ID {LoginId}.", id);
        var existingLogin = logins.Find(x => x.Id == id);
        if (existingLogin == null)
        {
            _logger.LogWarning("Login with ID {LoginId} not found for update.", id);
            return NotFound();
        }
        existingLogin.Username = login.Username;
        existingLogin.Password = login.Password;
        existingLogin.Email = login.Email;
        existingLogin.Mobile = login.Mobile;
        _logger.LogInformation("Login with ID {LoginId} successfully updated.", id);
        return NoContent();
    }
}

    

