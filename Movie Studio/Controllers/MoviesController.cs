using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Studio.ApplicationServices;
using static Movie_Studio.DTO.MovieDTOs;

namespace Movie_Studio.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController : ControllerBase
    {
        private MovieApplicationService movieAppService;

        public MoviesController(MovieApplicationService movieAppService)
        {
            this.movieAppService = movieAppService;
        }

        [HttpPost]
        public ActionResult CreateMetadata(CreateMetadataCommand command)
        {
            movieAppService.CreateMetadata(command);
            return Ok();
        }

        [HttpGet("{movieId}")]
        public ActionResult<MetadataDto> GetMetadata(int movieId)
        {
            GetMetadataQuery query = new GetMetadataQuery { MovieId = movieId };
            MetadataDto metadata = movieAppService.GetMetadata(query);
            if (metadata == null)
            {
                return NotFound();
            }
            return metadata;
        }

        [HttpGet("stats")]
        public ActionResult<List<MovieStatsDto>> GetMoviesStats()
        {
            List<MovieStatsDto> movieStatsList = movieAppService.GetMoviesStats();
            return movieStatsList;
        }
    }
}
