namespace Movie_Studio.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }



        private List<Metadata> metadata = new List<Metadata>();

        public void AddMetadata(Metadata newMetadata)
        {
            metadata.Add(newMetadata);
        }

        public Metadata GetLatestMetadata()
        {
            return metadata.LastOrDefault();
        }

        public int GetWatchDurationInSeconds()
        {
            int totalDuration = 0;
            foreach (Metadata metadataItem in metadata)
            {
                totalDuration += metadataItem.DurationInSeconds;
            }
            return totalDuration;
        }
    }
    public class Metadata
    {
        public string Language { get; set; }
        public int DurationInSeconds { get; set; }

    }
}
