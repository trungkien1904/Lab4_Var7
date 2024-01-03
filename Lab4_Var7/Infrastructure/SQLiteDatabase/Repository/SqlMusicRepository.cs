using Lab2_Var7.Domain.Models;
using Lab2_Var7.Domain.Repository;
using Lab2_Var7.Infrastructure.SQLiteDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var7.Infrastructure.Repository;

public class SqlMusicRepository : IMusicRepository
{
    private readonly MusicContext musicContext;
    public SqlMusicRepository(MusicContext musicContext)
    {
        this.musicContext = musicContext;
    }

    public async Task<int> AddMusic(Music? music)
    {
        if (music == null) return -1;

        await musicContext.AddAsync(music);
        return await musicContext.SaveChangesAsync();
    }

    public async Task<int> DeleteMusic(Music? music)
    {
        if (music == null) return -1;
        Music? deletedMusic = musicContext.MusicDatabase.Where(m => m.ArtistName == music.ArtistName && m.Title == music.Title).ToList().FirstOrDefault();
        if (deletedMusic != null)
        {
            musicContext.Remove(deletedMusic);
        }
        return await musicContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Music>> GetAllMusics()
    {
        return await musicContext.MusicDatabase.ToListAsync();
    }

    public async Task<IEnumerable<Music>> SearchMusic(string? request)
    {
        return await musicContext.MusicDatabase.Where(music => music.ArtistName == request || music.Title == request).ToListAsync();
    }
}