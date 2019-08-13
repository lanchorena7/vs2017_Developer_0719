using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChinookEntities db = new ChinookEntities())
            {
                db.Database.Log = sql => Console.WriteLine(sql);

                var albums = db.Album.ToList();
                var artists = db.Artist.ToList();

                albums.ForEach(x =>
                {
                    x.Artist = artists.FirstOrDefault(y => y.ArtistId.Equals(x.ArtistId));
                });
                albums.ForEach(x =>
                {
                    Console.WriteLine($"{x.Title} - {x.Artist.Name }");
                });
                Console.ReadKey();
            }
        }

        static void EagerLoading()
        {
            using (ChinookEntities db = new ChinookEntities())
            {
                db.Database.Log = sql => Console.WriteLine(sql);

                db.Artist
                    .Include("Album")
                    .Take(2)
                    .ToList().ForEach(artista =>
                    {
                        artista.Album.ToList().ForEach(album =>
                        {
                            Console.WriteLine($"{artista.Name} - {album.Title}");
                        });
                    });
            }
        }

    }
}
