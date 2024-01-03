
using Lab2_Var7.Domain.Repository;
using Lab2_Var7.Infrastructure.Repository;
using Lab2_Var7.Infrastructure.SQLiteDatabase;

public static class Program
{
    public static void Main(String[] args)
    {
        IMusicRepository musicRepository = new SqlMusicRepository(new MusicContext());
    }
}