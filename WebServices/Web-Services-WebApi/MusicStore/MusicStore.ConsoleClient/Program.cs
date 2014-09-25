namespace MusicStore.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using MusicStore.Data;
    using MusicStore.Data.Migrations;
    using MusicStore.Data.Repositories;
    using MusicStore.Models;

    class Program
    {
        private static async void PrintAlbums(HttpClient client)
        {
            var response = client.GetStringAsync("api/albums/getalbums").Result;
            var convertJSON = JsonConvert.SerializeObject(response);

            Console.WriteLine(convertJSON);
        }

        static async void CreateAlbum(HttpClient httpClient, Album album)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(album));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            try
            {
                var response = httpClient.PostAsync("api/albums/postalbum", postContent);

                var status = response.Status;
                Console.WriteLine("Album created!");
                PrintAlbums(httpClient);
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating album");
            }
        }

        static async void DeleteAlbum(HttpClient httpClient, int id)
        {
            try
            {
                var response = httpClient.DeleteAsync("api/albums/deletealbum/" + id);

                var status = response.AsyncState;
                Console.WriteLine("Album deleted!");
                PrintAlbums(httpClient);
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating album");
            }
        }

        static async void ChangeAlbum(HttpClient httpClient, Album album)
        {
            HttpContent putContent = new StringContent(JsonConvert.SerializeObject(album));
            putContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            // var deserialize = JsonConvert.DeserializeObject<Album>(putContent.ReadAsStringAsync().Result);

           var response = httpClient.PutAsync("api/albums/putalbum/" + album.Id, putContent);

                var status = response.AsyncState;
                Console.WriteLine("Album changed!");
                PrintAlbums(httpClient);
            
            

        }

        static void Main()
        {
            string baseUrl = "http://localhost:23664/";
            HttpClient client = new HttpClient
               {
                   BaseAddress = new Uri(baseUrl)
               };

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicStoreDbContext, Configuration>());

            MusicStoreData db = new MusicStoreData();

            Album album = new Album()
            {
                Title = "Most New Album",
                Producer = "Gincheto",
                Year = 2014
            };

            PrintAlbums(client);

            CreateAlbum(client, album);

            DeleteAlbum(client, 3);

            Album changeAlbum = new Album()
            {
                Id = 1,
                Title = "The very best Album",
                Producer = "Drisko",
                Year = 2014
            };

            ChangeAlbum(client, changeAlbum);

            //Console.WriteLine(response.Content);
            //    IQueryable<Album> re = db.Albums.All().Select(x => new Album
            //        {
            //            Title = x.Title,
            //            Artists = x.Artists,
            //            Producer = x.Producer,
            //            Id = x.Id,
            //            Year = x.Year
            //        });

            //    SerializationType serialization = SerializationType.Json;
            //    MusicItem musicItem = MusicItem.Artist;
            //    CrudOperation crud = CrudOperation.GetAll;
            //    Console.WriteLine(re);
            //    bool execute = true;

            //    while (execute)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("This is client for Music database.");
            //        Console.WriteLine("Make your choice:");
            //        Console.WriteLine("For choosing serialization (json/xml) press '1' current is {0}", serialization);
            //        Console.WriteLine("For choosing item for editing (Artist/Album/Song) press '2' current is {0}", musicItem);
            //        Console.WriteLine("For choosing crud operation (GetAll/Get/Add/Remove/Edit) press '3' current is {0}", crud);
            //        Console.WriteLine("For executing operation ({0} over {1} with {2} serialization) press '4'", crud, musicItem, serialization);
            //        Console.WriteLine("For exit press 'x' current is {0}", crud);
            //        char userChoice = Console.ReadKey().KeyChar;

            //        switch (userChoice)
            //        {
            //            case '1':
            //                serialization = SetSerialization();
            //                break;
            //            case '2':
            //                musicItem = SetMusicItem();
            //                break;
            //            case '3':
            //                crud = SetCrudOperation(musicItem);
            //                break;
            //            case '4':
            //                Console.WriteLine();
            //                //ExecudeCommand(serialization, musicItem, crud);
            //                Thread.Sleep(3000);
            //                break;
            //            case 'x':
            //            case 'X':
            //                execute = false;
            //                break;
            //            default:
            //                Console.WriteLine("Not a valid choise, chose 1/2/3/4/x");
            //                break;
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //private static SerializationType SetSerialization()
            //{
            //    Console.WriteLine("Make ypur choice:");
            //    Console.WriteLine("For using json serialization press '1'");
            //    Console.WriteLine("For using xml serialization press '2'");
            //    char userChoice = Console.ReadKey().KeyChar;

            //    switch (userChoice)
            //    {
            //        case '1':
            //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //            return SerializationType.Json;
            //        case '2':
            //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            //            return SerializationType.Xml;
            //        default:
            //            Console.WriteLine("Not a valid choise, chosen json");
            //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //            return SerializationType.Json;
            //    }
            //}

            //private static MusicItem SetMusicItem()
            //{
            //    Console.WriteLine("Make ypur choice:");
            //    Console.WriteLine("For operating with artists press '1'");
            //    Console.WriteLine("For operating with albums press '2'");
            //    Console.WriteLine("For operating with songs press '3'");

            //    while (true)
            //    {
            //        char userChoice = Console.ReadKey().KeyChar;
            //        switch (userChoice)
            //        {
            //            case '1':
            //                return MusicItem.Artist;
            //            case '2':
            //                return MusicItem.Album;
            //            case '3':
            //                return MusicItem.Song;
            //            default:
            //                Console.WriteLine("Not a valid choise, chose from 1/2/3");
            //                break;
            //        }
            //    }
            //}

            //private static CrudOperation SetCrudOperation(MusicItem musicItem)
            //{
            //    Console.WriteLine("Make ypur choice:");
            //    Console.WriteLine("For get all {0} press '1'", musicItem.ToString());
            //    Console.WriteLine("For get {0} by id press '2'", musicItem.ToString());
            //    Console.WriteLine("For add new {0} press '3'", musicItem.ToString());
            //    Console.WriteLine("For remove {0} press '4'", musicItem.ToString());
            //    Console.WriteLine("For edit {0} by id press '5'", musicItem.ToString());

            //    while (true)
            //    {
            //        char userChoice = Console.ReadKey().KeyChar;
            //        switch (userChoice)
            //        {
            //            case '1':
            //                return CrudOperation.GetAll;
            //            case '2':
            //                return CrudOperation.Get;
            //            case '3':
            //                return CrudOperation.Add;
            //            case '4':
            //                return CrudOperation.Remove;
            //            case '5':
            //                return CrudOperation.Edit;
            //            default:
            //                Console.WriteLine("Not a valid choise, chose from 1/2/3/4/5");
            //                break;
            //        }
            //    }
        }

        //private static void ExecudeCommand(SerializationType serialization, MusicItem musicItem, CrudOperation crud)
        //{
        //    if (musicItem == MusicItem.Artist)
        //    {
        //        int artistId;
        //        switch (crud)
        //        {
        //            case CrudOperation.GetAll:
        //                GetAllArtists();
        //                break;
        //            case CrudOperation.Get:
        //                Console.WriteLine("Enter artist id");
        //                artistId = int.Parse(Console.ReadLine());
        //                GetArtist(artistId);
        //                break;
        //            case CrudOperation.Add:
        //                Artist artist = CreateOrUpdateArtist();
        //                AddArtist(serialization, artist);
        //                break;
        //            case CrudOperation.Remove:
        //                Console.WriteLine("Enter artist id");
        //                artistId = int.Parse(Console.ReadLine());
        //                RemoveArtist(artistId);
        //                break;
        //            case CrudOperation.Edit:
        //                Console.WriteLine("Enter artist id");
        //                artistId = int.Parse(Console.ReadLine());
        //                Artist newArtist = CreateOrUpdateArtist();
        //                newArtist.Id = artistId;
        //                EditArtist(serialization, newArtist);
        //                break;
        //        }
        //    }
        //    else if (musicItem == MusicItem.Album)
        //    {
        //        int albumId;
        //        switch (crud)
        //        {
        //            case CrudOperation.GetAll:
        //                GetAllAlbums();
        //                break;
        //            case CrudOperation.Get:
        //                Console.WriteLine("Enter album id");
        //                albumId = int.Parse(Console.ReadLine());
        //                GetAlbum(albumId);
        //                break;
        //            case CrudOperation.Add:
        //                Album album = CreateOrUpdateAlbum(new Album());
        //                AddAlbum(serialization, album);
        //                break;
        //            case CrudOperation.Remove:
        //                Console.WriteLine("Enter album id");
        //                albumId = int.Parse(Console.ReadLine());
        //                RemoveAlbum(albumId);
        //                break;
        //            case CrudOperation.Edit:
        //                Console.WriteLine("Enter album id");
        //                albumId = int.Parse(Console.ReadLine());
        //                Album oldAlbum = GetAlbum(albumId);
        //                Album newAlbum = CreateOrUpdateAlbum(oldAlbum);
        //                newAlbum.Id = albumId;
        //                EditAlbum(serialization, newAlbum);
        //                break;
        //        }
        //    }
        //    else if (musicItem == MusicItem.Song)
        //    {
        //        int songId;
        //        switch (crud)
        //        {
        //            case CrudOperation.GetAll:
        //                GetAllSongs();
        //                break;
        //            case CrudOperation.Get:
        //                Console.WriteLine("Enter song id");
        //                songId = int.Parse(Console.ReadLine());
        //                GetSong(songId);
        //                break;
        //            case CrudOperation.Add:
        //                Song song = CreateOrUpdateSong(new Song());
        //                AddSong(serialization, song);
        //                break;
        //            case CrudOperation.Remove:
        //                Console.WriteLine("Enter song id");
        //                songId = int.Parse(Console.ReadLine());
        //                RemoveSong(songId);
        //                break;
        //            case CrudOperation.Edit:
        //                Console.WriteLine("Enter song id");
        //                songId = int.Parse(Console.ReadLine());
        //                Song oldSong = GetSong(songId);
        //                Song newSong = CreateOrUpdateSong(oldSong);
        //                newSong.Id = songId;
        //                EditSong(serialization, newSong);
        //                break;
        //        }
        //    }
        //}

        //private static Song CreateOrUpdateSong(Song song)
        //{
        //    Console.WriteLine("Enter title: ");
        //    string title = Console.ReadLine();
        //    if (title != "")
        //    {
        //        song.Title = title;
        //    }

        //    Console.WriteLine("Enter ganre(optional): ");
        //    string ganre = Console.ReadLine();
        //    if (ganre != "")
        //    {
        //        song.Genre = ganre;
        //    }

        //    Console.WriteLine("Enter creating year(optional): ");
        //    string year = Console.ReadLine(); ;
        //    if (year != "")
        //    {
        //        song.Year = int.Parse(year);
        //    }

        //    Console.WriteLine("Enter existing artist name for song: ");
        //    string name = Console.ReadLine();
        //    MusicStoreData db = new MusicStoreData();
        //    Artist artist = db.Artist.All().Where(x => x.FirstName == name).FirstOrDefault();

        //    if (artist != null)
        //    {
        //        song.Artist = artist;
        //        song.ArtistId = artist.Id;
        //    }
        //    else
        //    {
        //        if (name != "")
        //        {
        //            Console.WriteLine("No artist with this name exist!");
        //        }
        //    }

        //    return song;
        //}

        //private static void EditSong(SerializationType serialization, Song newSong)
        //{
        //    HttpResponseMessage response;
        //    //switch (serialization)
        //    //{
        //    //    case SerializationType.Xml:
        //    //        response = client.PutAsync("api/song/" + newSong.Id, newSong).Result;
        //    //        break;
        //    //    default:
        //    //        response = client.PutAsJsonAsync("api/song/" + newSong.SongId, newSong).Result;
        //    //        break;
        //    //}

        //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //}

        //private static void RemoveSong(int songId)
        //{
        //    var response = client.DeleteAsync("api/song/" + songId).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Song deleted successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //}

        //private static void AddSong(SerializationType serialization, Song newsong)
        //{
        //    HttpResponseMessage response;
        //    //switch (serialization)
        //    //{
        //    //    case SerializationType.Xml:
        //    //        response = client.PostAsXmlAsync("api/song", newsong).Result;
        //    //        break;
        //    //    default:
        //    //        response = client.PostAsJsonAsync("api/song", newsong).Result;
        //    //        break;
        //    //}

        //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //}

        //private static Song GetSong(int songId)
        //{
        //    HttpResponseMessage response = client.GetAsync("api/song/" + songId).Result;
        //    Song song = new Song();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        //song = response.Content.ReadAsAsync<Song>().Result;
        //        Console.WriteLine("{0,4} {1,-20} {2} - {3} artist: {4}", song.SongId, song.Title, song.Ganre, song.CreatingYear, song.Artist.Name);
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //    return song;
        //}

        //private static void GetAllSongs()
        //{
        //    HttpResponseMessage response = client.GetAsync("api/song").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        //var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
        //        //foreach (var song in songs)
        //        //{
        //        //    Console.WriteLine("{0,4} {1,-20} {2} - {3} artist: {4}", song.SongId, song.Title, song.Ganre, song.CreatingYear, song.Artist.Name);
        //        //}
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //}

        //private static Album CreateOrUpdateAlbum(Album album)
        //{
        //    Console.WriteLine("Enter title: ");
        //    string title = Console.ReadLine();
        //    if (title != "")
        //    {
        //        album.Title = title;
        //    }

        //    Console.WriteLine("Enter producer(optional): ");
        //    string producer = Console.ReadLine();
        //    if (producer != "")
        //    {
        //        album.Producer = producer;
        //    }

        //    Console.WriteLine("Enter release date(optional): ");
        //    DateTime? date = null;
        //    try
        //    {
        //        //date = DateTime.Parse(Console.ReadLine());
        //        //album.Year = date;
        //    }
        //    catch (FormatException ex)
        //    {

        //    }

        //    Console.WriteLine("Enter existing artist name for album (optional): ");
        //    string name = Console.ReadLine();
        //    MusicStoreData db = new MusicStoreData();
        //    Artist artist = db.Artist.All().Where(x => x.FirstName == name).FirstOrDefault();

        //    if (artist != null)
        //    {
        //        album.Artists.Add(artist);
        //    }
        //    else
        //    {
        //        if (name != "")
        //        {
        //            Console.WriteLine("No artist with this name exist!");
        //        }
        //    }

        //    return album;
        //}

        //private static void EditAlbum(SerializationType serialization, Album newAlbum)
        //{
        //    HttpResponseMessage response;
        //    switch (serialization)
        //    {
        //        case SerializationType.Xml:
        //            response = client.PutAsXmlAsync("api/album/" + newAlbum.AlbumId, newAlbum).Result;
        //            break;
        //        default:
        //            response = client.PutAsJsonAsync("api/album/" + newAlbum.AlbumId, newAlbum).Result;
        //            break;
        //    }

        //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //}

        //private static void RemoveAlbum(int albumId)
        //{
        //    var response = client.DeleteAsync("api/album/" + albumId).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Album deleted successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //}

        //private static void AddAlbum(SerializationType serialization, Album newalbum)
        //{
        //    HttpResponseMessage response;
        //    switch (serialization)
        //    {
        //        case SerializationType.Xml:
        //            response = client.PostAsXmlAsync("api/album", newalbum).Result;
        //            break;
        //        default:
        //            response = client.PostAsJsonAsync("api/album", newalbum).Result;
        //            break;
        //    }

        //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //}

        //private static Album GetAlbum(int albumId)
        //{
        //    HttpResponseMessage response = client.GetAsync("api/album/" + albumId).Result;
        //    Album album = new Album();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        album = response.Content.ReadAsAsync<Album>().Result;
        //        Console.WriteLine("{0,4} {1,-20} {2} - {3} artists: {4}", album.AlbumId, album.Title, album.Producer, album.ReleaseDate,
        //            string.Join(", ", album.Artists.Select(x => x.Name).ToList()));
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //    return album;
        //}

        //private static void GetAllAlbums()
        //{
        //    HttpResponseMessage response = client.GetAsync("api/album").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
        //        foreach (var a in albums)
        //        {
        //            Console.WriteLine("{0,4} {1,-20} {2} - {3} artists: {4}", a.AlbumId, a.Title, a.Producer, a.ReleaseDate,
        //             string.Join(", ", a.Artists.Select(x => x.Name).ToList()));
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //}

        //private static Artist CreateOrUpdateArtist()
        //{
        //    Console.WriteLine("Enter name: ");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter country(optional): ");
        //    string country = Console.ReadLine();
        //    if (country == "")
        //    {
        //        country = null;
        //    }
        //    Console.WriteLine("Enter birth date(optional): ");
        //    DateTime? date = null;
        //    try
        //    {
        //        date = DateTime.Parse(Console.ReadLine());
        //    }
        //    catch (FormatException ex)
        //    {

        //    }

        //    Artist newArtist = new Artist
        //    {
        //        Name = name,
        //        Country = country,
        //        BirthDate = date
        //    };

        //    return newArtist;
        //}

        //private static void EditArtist(SerializationType serialization, Artist newartist)
        //{
        //    HttpResponseMessage response;
        //    switch (serialization)
        //    {
        //        case SerializationType.Xml:
        //            response = client.PutAsXmlAsync("api/artist/" + newartist.ArtistId, newartist).Result;
        //            break;
        //        default:
        //            response = client.PutAsJsonAsync("api/artist/" + newartist.ArtistId, newartist).Result;
        //            break;
        //    }

        //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //}

        //private static void RemoveArtist(int artistId)
        //{
        //    var response = client.DeleteAsync("api/artist/" + artistId).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Artist deleted successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //}

        //private static void AddArtist(SerializationType serialization, Artist newartist)
        //{
        //    HttpResponseMessage response;
        //    switch (serialization)
        //    {
        //        case SerializationType.Xml:
        //            response = client.PostAsXmlAsync("api/artist", newartist).Result;
        //            break;
        //        default:
        //            response = client.PostAsJsonAsync("api/artist", newartist).Result;
        //            break;
        //    }

        //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //}

        //private static void GetArtist(int artistId)
        //{
        //    HttpResponseMessage response = client.GetAsync("api/artist/" + artistId).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var artist = response.Content.ReadAsAsync<Artist>().Result;
        //        Console.WriteLine("{0,4} {1,-20} {2} - {3}", artist.ArtistId, artist.Name, artist.Country, artist.BirthDate);
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //}

        private static void GetAllArtists()
        {
            //HttpResponseMessage response = client.GetAsync("api/artists").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var artists = response.Content.ReadAsStringAsync<IEnumerable<Artist>>().Result;
            //    foreach (var a in artists)
            //    {
            //        Console.WriteLine("{0,4} {1,-20} {2} - {3}", a.ArtistId, a.Name, a.Country, a.BirthDate);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}
        }
    }
}
