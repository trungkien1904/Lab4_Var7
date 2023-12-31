using Lab2_Var7.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Repository;

public interface IMusicCatalogRepository
{
    Task<int> AddMusic(Music? music);
    Task<int> DeleteMusic(Music? music);
    Task<IEnumerable<Music>> SearchMusic(string? request);
    Task<IEnumerable<Music>> GetAllMusics();
}
