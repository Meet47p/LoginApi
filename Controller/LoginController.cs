using LoginApi.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class LoginController : ControllerBase
{
    private List<Login> logins = new List<Login>(){
        new Login{Id=1,Username="admin",Password="admin",Email="admin@123",Mobile=1234567890},
        new Login{Id=2,Username="user",Password="user",Email="user@123",Mobile=1234567890},
        new Login{Id=3,Username="user1",Password="user1",Email="user1@123",Mobile=1234567890},
        new Login{Id=4,Username="user2",Password="user2",Email="user2@123",Mobile=1234567890},
        new Login{Id=5,Username="user3",Password="user3",Email="user3@123",Mobile=1234567890},
        new Login{Id=6,Username="user4",Password="user4",Email="user4@123",Mobile=1234567890},
        new Login{Id=7,Username="user5",Password="user5",Email="user5@123",Mobile=1234567890},
        new Login{Id=8,Username="user6",Password="user6",Email="user6@123",Mobile=1234567890},
        new Login{Id=9,Username="user7",Password="user7",Email="user7@123",Mobile=1234567890},
        new Login{Id=10,Username="user8",Password="user8",Email="user8@123",Mobile=1234567890},

    };

    [HttpGet]
    public ActionResult<List<Login>> GetAllLogins()
    {
        return Ok(logins);
    }

    [HttpGet("{id}")]
    public ActionResult<Login> GetLogin(int id)
    {
        var login = logins.Find(x => x.Id == id);
        if (login == null)
        {
            return NotFound();
        }
        return Ok(login);
    }
    [HttpPost]
    public ActionResult<Login> AddLogin(Login login)
    {
        logins.Add(login);
        return CreatedAtAction(nameof(GetLogin), new { id = login.Id }, login);
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteLogin(int id)
    {
        var login = logins.Find(x => x.Id == id);
        if (login == null)
        {
            return NotFound();
        }
        logins.Remove(login);
        return NoContent();
    }
    [HttpPut("{id}")]
    public ActionResult<Login> UpdateLogin(int id, Login login) {
        var existingLogin = logins.Find(x => x.Id == id);
        if (existingLogin == null)
        {
            return NotFound();
        }
        existingLogin.Username = login.Username;
        existingLogin.Password = login.Password;
        existingLogin.Email = login.Email;
        existingLogin.Mobile = login.Mobile;
        return Ok(existingLogin);       
    }
    

 

}
    

