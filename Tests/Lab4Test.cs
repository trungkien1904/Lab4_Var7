using Lab2_Var7.Application.Services;
using Lab2_Var7.Domain.Models;
using Lab2_Var7.Domain.Repository;
using Lab2_Var7.Infrastructure.SQLiteDatabase;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Controllers;
using WebService.Repository;
using Xunit;

namespace Tests;

public class Lab4Test
{
    private MusicContext musicContext;
    private Mock<IMusicCatalogRepository> musicCatalogRepository;
    private MusicCatalogController musicCatalogController;
    public Lab4Test()
    {
        musicContext = new MusicContext();
        musicCatalogRepository = new Mock<IMusicCatalogRepository>();
        musicCatalogController = new MusicCatalogController(musicCatalogRepository.Object);
    }

    [Fact]
    public async void TestAddMusic()
    {
        var music = new Music("ABC", "ABSSSS");
        await musicCatalogController.AddMusic(music);

        musicCatalogRepository.Verify(m => m.AddMusic(music), Times.Once);
    }

    [Fact]
    public async void TestRemoveMusic()
    {
        var music = new Music("ABC", "ABSSSS");
        await musicCatalogController.DeleteMusic(music);

        musicCatalogRepository.Verify(m => m.DeleteMusic(music), Times.Once);
    }

    [Fact]
    public async void TestSearchMusic()
    {
        string request = "ABC";
        await musicCatalogController.SearchMusic(request);

        musicCatalogRepository.Verify(m => m.SearchMusic(request), Times.Once);
    }
}
