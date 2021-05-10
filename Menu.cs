using System;
public class Menu : IMenu{
    public void displayMenu(IRepo repo, IMovie movie, ISearch search){


        String userResponse;
        do{
            System.Console.WriteLine("[1] List Movies");
            System.Console.WriteLine("[2] Add Movies");
            System.Console.WriteLine("[3] Search");
            System.Console.WriteLine("[4] Update Record");
            System.Console.WriteLine("[5] Delete Record");
            System.Console.WriteLine("[6] Add User");
            System.Console.WriteLine("[7] List Users");
            userResponse = Console.ReadLine();
            if(userResponse == "1"){
                repo.listMovies();
            }
            else if(userResponse == "2"){
                System.Console.WriteLine("Title: ");
                string title = Console.ReadLine();
                string genre = "";
                string response = "y";
                do{
                    System.Console.WriteLine("Genre: ");
                    genre = genre + "|" + Console.ReadLine();
                    System.Console.WriteLine("Would you like to add another genre?: (y/n)");
                    response = Console.ReadLine();
                
                }while(response == "y");
            
                repo.addMovie(title, genre, movie);
            }
            else if(userResponse == "3"){
                System.Console.WriteLine("Search: ");
                String searchStr = Console.ReadLine();
                repo.searchMovies(searchStr);
            }
            else if(userResponse == "4"){
                repo.listMovies();
                System.Console.WriteLine("Movie ID of desired record: ");
                String id = Console.ReadLine();
                repo.updateRecord(id);
            }
            else if(userResponse == "5"){
                repo.listMovies();
                System.Console.WriteLine("Enter Id of movie to be removed: ");
                String id = Console.ReadLine();
                repo.deleteRecord(id);
            }
            else if(userResponse == "6"){
                System.Console.WriteLine("Enter name of new user: ");
                String name = Console.ReadLine();

                System.Console.WriteLine("Enter occupation of new user: ");
                String occupation = Console.ReadLine();
                repo.addUser(name, occupation);
            }
            else if(userResponse == "7"){
                repo.listUsers();
            }
            else{
                
            }
        }while(userResponse == "1" 
        || userResponse == "2" 
        || userResponse == "3" 
        || userResponse == "4" 
        || userResponse == "5"
        || userResponse == "6" 
        || userResponse == "7");
        
        
    }
}