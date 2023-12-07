namespace Movie_Studio.DTO
{
    public class MovieDTOs
    {
        public class CreateMetadataCommand
        {
            public int MovieId { get; set; }
            public string Language { get; set; }
            public int DurationInSeconds { get; set; }   
        }

        public class GetMetadataQuery
        {
            public int MovieId { get; set; }
        }

        public class MetadataDto
        {
            public int MovieId { get; set; }
            public string Title { get; set; }
            public string Language { get; set; }
        }

        public class MovieStatsDto
        {
            public int MovieId { get; set; }
            public string Title { get; set; }
            public int AverageWatchDurationS { get; set; }
        }
    }
}
