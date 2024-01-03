using Lab2_Var7.Domain.Repository;
using Lab2_Var7.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var7.Infrastructure.SQLiteDatabase.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMusicCatalogContext(this IServiceCollection services)
    {
        string DbPath = Directory.GetCurrentDirectory() + "\\Database\\music.db";
        Console.WriteLine(DbPath);
        services.AddDbContext<MusicContext>(op => op.UseSqlite($"Data Source={DbPath}"));

        services.AddScoped<IMusicRepository, SqlMusicRepository>();

        return services;
    }
}
