using System;
using System.Collections;
using Newtonsoft.Json;
using System.IO;
using Json.Net;
public class Search : ISearch{

    //!!!!!!!!!!!
    //Note This file is from one of the previous iterations of the Movies assignment,  This has to current functionality
    //!!!!!!!!!!!

    private string[] files = {"movies.json", "shows.csv", "videos.csv"};
    private string[] mediaType = {"Movie: ", "Shows: ", "Video: "};
    private ArrayList matches = new ArrayList();
    public void SearchFor(string searchValue){
        int counter = 0;
        using (var reader = new StreamReader("movies.json"))
        {
            while(!reader.EndOfStream){
                var line = reader.ReadLine(); 
                        
                Movie m = JsonConvert.DeserializeObject<Movie>(@line);
                String title = m.title;
                string genres = m.genres;

                if((title.ToLower().IndexOf(searchValue) > -1) ^ (genres.ToLower().IndexOf(searchValue) > -1)){
                    matches.Add("Movie: " + m.movieId + " || " + m.title + " || " + genres);
                    counter++;
                }
                
            }                                                                    
        }
        for(int i = 1; i < 3; i++){
            using (StreamReader reader = new StreamReader(files[i]))
            {
                var line = reader.ReadLine();
            
                Console.WriteLine("Start");
                while(!reader.EndOfStream){
                    
                    var media = line.Split(",");
                    String title = media[1];
                    string genres = media[media.Length-1];
                    string entry = "" + mediaType[i];

                    if((title.ToLower().IndexOf(searchValue) > -1) ^ (genres.ToLower().IndexOf(searchValue) > -1)){
                        entry = entry + media[0];
                        for(int m = 1; m < media.Length; m++){
                            entry = entry + " || " + media[m];
                        }
                        matches.Add(entry);
                        counter++;
                    }
                    line = reader.ReadLine();
                }  
            }
        }
        System.Console.WriteLine("Search Results: (" + counter + ") for \"" + searchValue + "\"");
        printMatches();
    }
    public void printMatches(){
        foreach (string match in matches)
        {
            System.Console.WriteLine(match);
        }
        matches.Clear();
    }
}