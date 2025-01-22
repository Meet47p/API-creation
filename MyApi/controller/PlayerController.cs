using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    public static List<Players> players = new List<Players>()
    {
        new Players { Id = 1, Name = "Rohit Sharma", Age = 25 },
        new Players { Id = 2, Name = "vIRAT Kholi", Age = 30 },
        new Players { Id = 3, Name = "ms Dhoni", Age = 35 },
        new Players { Id = 4, Name = "Suresh Raina", Age = 40 } 
        
};
[HttpGet]
public ActionResult<List<Players>> GetAllPlayers()
{
    return Ok(players);
}
[HttpGet("{id}")]
public ActionResult<Players> GetPlayerById(int id)
{
    var player = players.Find(p => p.Id == id);
    if (player == null)
    {
        return NotFound();
    }
    return Ok(player);
}
[HttpPost]
public ActionResult<Players> CreatePlayer(Players player)
{
    players.Add(player);
    return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
}

[HttpPut("{id}")]
public ActionResult UpdatePlayer(int id, Players player)
{
    var existingPlayer = players.Find(p => p.Id == id);
    if (existingPlayer == null)
    {
        return NotFound();
    }
    existingPlayer.Name = player.Name;
    existingPlayer.Age = player.Age;
    return NoContent();
}

[HttpDelete("{id}")]
public ActionResult DeletePlayer(int id)
{
    var existingPlayer = players.Find(p => p.Id == id);
    if (existingPlayer == null)
    {
        return NotFound();
    }
    players.Remove(existingPlayer);
    return NoContent();
 }
}