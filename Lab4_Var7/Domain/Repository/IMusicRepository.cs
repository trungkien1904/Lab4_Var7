using Lab2_Var7.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var7.Domain.Repository;

public interface IMusicRepository
{
    Task<int> AddMusic(Music? music);
    Task<int> DeleteMusic(Music? music);
    Task<IEnumerable<Music>> SearchMusic(string? request);
    Task<IEnumerable<Music>> GetAllMusics();
}