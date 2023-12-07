using Movie_Studio.Entities;
using Movie_Studio.Repository;
using static Movie_Studio.DTO.MovieDTOs;
using static Movie_Studio.Entities.Movie;

namespace Movie_Studio.ApplicationServices
{
    public class MovieApplicationService
    {
        private IMovieRepository movieRepository;

        public MovieApplicationService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public void CreateMetadata(CreateMetadataCommand command)
        {
            Movie movie = movieRepository.GetById(command.MovieId);
            Metadata newMetadata = new Metadata
            {
                Language = command.Language,
                DurationInSeconds = command.DurationInSeconds
            };
            movie.AddMetadata(newMetadata);
            movieRepository.Save(movie);
        }

        public MetadataDto GetMetadata(GetMetadataQuery query)
        {
            Movie movie = movieRepository.GetById(query.MovieId);
            Metadata latestMetadata = movie.GetLatestMetadata();
            return new MetadataDto
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Language = latestMetadata.Language,
                // Set other metadata attributes
            };
        }

        public List<MovieStatsDto> GetMoviesStats()
        {
            List<Movie> movies = movieRepository.GetAll();
            List<MovieStatsDto> movieStatsList = new List<MovieStatsDto>();
            foreach (Movie movie in movies)
            {
                MovieStatsDto movieStats = new MovieStatsDto
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title,
                    AverageWatchDurationS = movie.GetWatchDurationInSeconds(),
                };
                movieStatsList.Add(movieStats);
            }
            return movieStatsList;
        }
    }

}
