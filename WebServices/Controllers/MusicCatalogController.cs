using Lab2_Var7.Domain.Models;
using Lab2_Var7.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers;

[Route("api/musics")]
[ApiController]
public class MusicController : ControllerBase
{
    private readonly IMusicRepository musicRepository;
    public MusicController(IMusicRepository musicRepository)
    {
        this.musicRepository = musicRepository;
    }

    // POST: api/music/add
    [HttpPost("add")]
    public async Task<IActionResult> AddMusic([FromBody] Music music)
    {
        int result = await musicRepository.AddMusic(music);
        switch (result)
        {
            case -1:
                return BadRequest();
            case 0:
                return Problem();
            case 1:
                return Ok();
            default:
                return RedirectToAction(nameof(AddMusic));
        }
    }


    // POST: api/music/delete
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteMusic([FromBody] Music music)
    {
        int result = await musicRepository.DeleteMusic(music);
        switch (result)
        {
            case -1:
                return BadRequest();
            case 0:
                return Problem();
            case 1:
                return Ok();
            default:
                return RedirectToAction(nameof(DeleteMusic));
        }
    }

    // GET: api/music/search?query=[query]
    [HttpGet("search")]
    public async Task<IEnumerable<Music>> SearchMusic([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return await musicRepository.GetAllMusics();
        }

        return await musicRepository.SearchMusic(query);
    }
}
