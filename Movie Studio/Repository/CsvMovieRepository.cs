using Movie_Studio.Entities;
using System.Formats.Asn1;
using System.Globalization;
using System;
using CsvHelper;

namespace Movie_Studio.Repository
{
    public class CsvMovieRepository : IMovieRepository
    {
        private string csvFilePath;
        public CsvMovieRepository(string csvFilePath)
        {
            this.csvFilePath = csvFilePath;
        }
        public List<Movie> GetAll()
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var movies = csv.GetRecords<Movie>();
                return movies.ToList();
            }

        }

        public Movie GetById(int movieId)
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var movie = csv.GetRecords<Movie>().FirstOrDefault(m => m.MovieId == movieId);
                return movie;
            }
        }

        public void Save(Movie movie)
        {
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Movie>();
                csv.WriteRecord(movie);
                csv.NextRecord();
            }
        }
    }
}
