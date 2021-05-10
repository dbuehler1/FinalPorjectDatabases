public interface IRepo{
    void listMovies();
   // int endingMovieID();
    void addMovie(string Title, string genres, IMovie movie);
    void searchMovies(string searchTxt);
    void updateRecord(string id);
    void deleteRecord(string id);
    void addUser(string name, string occupation);
    void listUsers();
}