using System;
using System.IO;
using Json.Net;
using System.Collections;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NLog.Web;

public class Repo : IRepo
{
    private string nlogFile = Directory.GetCurrentDirectory() + "\\nlog.config";
     
    public void listMovies()
    {
        var userLog = NLog.Web.NLogBuilder.ConfigureNLog(nlogFile).GetCurrentClassLogger();
        
        userLog.Info("Listing movies");
        int count = 0;
        using (var db = new MovieController())
        {
            foreach (var movie in db.Movies)
            {
                count++;
                System.Console.WriteLine(movie.movieId + " " + movie.title + " " + movie.genres);
                System.Console.WriteLine("");
            }
            System.Console.WriteLine(count + " Movies returned");

        }
    }
    
    public void addMovie(string Title, string Genres, IMovie newMovie)
    {
        var userLog = NLog.Web.NLogBuilder.ConfigureNLog(nlogFile).GetCurrentClassLogger();
        
        userLog.Info("adding movie" + Title);

        System.Console.WriteLine("");

        using (var db = new MovieController())
        {
            var movie = new Movie()
            {
                title = Title,
                genres = Genres
            };
            db.Movies.Add(movie);
            db.SaveChanges();
        }
    }


    public void searchMovies(string searchTxt){
        var userLog = NLog.Web.NLogBuilder.ConfigureNLog(nlogFile).GetCurrentClassLogger();
        
        userLog.Info("searching movies with \"" + searchTxt + "\"");

        int count = 0;
        using (var db = new MovieController())
        {
            foreach (var movie in db.Movies)
            {
                if((movie.title.ToLower().IndexOf(searchTxt) > -1) ^ (movie.genres.ToLower().IndexOf(searchTxt) > -1)){
                    count++;
                    System.Console.WriteLine(movie.movieId + " " + movie.title + " " + movie.genres);
                    System.Console.WriteLine("");
                }
            }
            System.Console.WriteLine(count + " Movies returned with \"" + searchTxt + "\"");

        }
    }


    public void updateRecord(string id){
        
        var userLog = NLog.Web.NLogBuilder.ConfigureNLog(nlogFile).GetCurrentClassLogger();
        
        userLog.Info("updating record: " + id);

        using (var db = new MovieController()){
            var update = db.Movies.Where(m => m.movieId+"" == id).First();
            System.Console.WriteLine("Enter new title: ");
            update.title = Console.ReadLine();
            System.Console.WriteLine("Enter new Genres");
            string response = "";
            string genre = "";
            do{
                    System.Console.WriteLine("Genre: ");
                    genre = genre + "|" + Console.ReadLine();
                    System.Console.WriteLine("Would you like to add another genre?: (y/n)");
                    response = Console.ReadLine();
            
            }while(response == "y");
            update.genres = genre;
            db.SaveChanges();
        }
    }


    public void deleteRecord(string id){
        var userLog = NLog.Web.NLogBuilder.ConfigureNLog(nlogFile).GetCurrentClassLogger();
        
        userLog.Info("Deleted movie: " + id);

        using (var db = new MovieController()){
            var delRecord = db.Movies.Where(m => m.movieId+"" == id).First();
            db.Movies.Remove(delRecord);
            db.SaveChanges();
        }
        
    }

    public void addUser(string name, string occupation){
        var userLog = NLog.Web.NLogBuilder.ConfigureNLog(nlogFile).GetCurrentClassLogger();
        
        userLog.Info("adding user: " + name); 

        using (var db = new MovieController()){
            var user = new User()
            {
                Name = name,
                Occupation = occupation
            };
            db.Users.Add(user);
            db.SaveChanges();
            

            listUsers();
        }
        System.Console.WriteLine("");
    }

    public void listUsers(){
        var userLog = NLog.Web.NLogBuilder.ConfigureNLog(nlogFile).GetCurrentClassLogger();
        
        userLog.Info("Listing Users"); 
        int count = 0;
        using (var db = new MovieController())
        {
            System.Console.WriteLine("Current Users:");
            foreach (var user in db.Users)
            {
                count++;
                System.Console.WriteLine(user.userId + " " + user.Name + " " + user.Occupation);
                System.Console.WriteLine("");
            }
            System.Console.WriteLine(count + " Users returned");

        }
    }
}