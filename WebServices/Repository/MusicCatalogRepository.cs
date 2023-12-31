using Lab2_Var7.Domain.Models;
using Lab2_Var7.Infrastructure.SQLiteDatabase;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebService.Repository;

public class MusicCatalogRepository : IMusicCatalogRepository
{
    private readonly MusicContext musicContext;
    public MusicCatalogRepository(MusicContext musicContext)
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

        musicContext.Remove(music);
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
