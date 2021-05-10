using System;
using Microsoft.Extensions.DependencyInjection;



namespace RevisedMovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("Hello World!");
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IMenu, Menu>()
            .AddSingleton<IRepo, Repo>()
            .AddSingleton<IMovie, Movie>()
            .AddSingleton<ISearch, Search>()
            .BuildServiceProvider();
            var newMenu = serviceProvider.GetService<IMenu>();
            var repo = serviceProvider.GetService<IRepo>();
            var movie = serviceProvider.GetService<IMovie>();
            var search = serviceProvider.GetService<ISearch>();
            newMenu.displayMenu(repo, movie, search);



            
            
        }
    }
}
