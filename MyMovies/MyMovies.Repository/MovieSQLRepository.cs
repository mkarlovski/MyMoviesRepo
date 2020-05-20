using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.Repository
{
   public class MovieSQLRepository : IMovieRepository
    {
        public void Add(Movie movie)
        {
            using(var cnn= new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true"))
            {
                cnn.Open();
                var query = @"insert into Movies1(Title, ImageURL,Description,Cast)   
                    values(@Title,@ImageURL,@Description,@Cast)";  //so prvoto @ mu davame moznost da se pisuva vo povekje redovi
                var cmd = new SqlCommand(query,cnn);
                //SQL injection protection
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ImageURL", movie.ImageURL);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@Cast", movie.Cast);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Movie> GetAll()
        {
            var result = new List<Movie>();

            using (var cnn= new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true"))   // konekcija so lokalna baza i windows auth ;so using se otvora nova kolekcija i koga ke zavrsi odma ja zatvara i nemora cnn.Close()
            {
                cnn.Open();  //so ova pravime konekcija do bazata
                /* cnn.Close();*/ //na kraj mora da ja zatvorime konekcijata  dokolku ne koristime using()

                var cmd = new SqlCommand("select * from Movies1", cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie();
                    movie.ID = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.ImageURL = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Cast = reader.GetString(4);

                    result.Add(movie);
                }
                return result;
            }
        }

        public Movie GetById(int id)
        {
            Movie result = null;

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true"))   // konekcija so lokalna baza i windows auth ;so using se otvora nova kolekcija i koga ke zavrsi odma ja zatvara i nemora cnn.Close()
            {
                cnn.Open();  //so ova pravime konekcija do bazata
                /* cnn.Close();*/ //na kraj mora da ja zatvorime konekcijata  dokolku ne koristime using()

                var cmd = new SqlCommand($"select * from Movies1 where id={id}", cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movie();
                    result.ID = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.ImageURL = reader.GetString(2);
                    result.Description = reader.GetString(3);
                    result.Cast = reader.GetString(4);
                
                }
                return result;
            }
        }
    }
}
