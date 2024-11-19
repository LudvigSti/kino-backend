namespace MyBackendAPI.DTOs
{
    public class CreateScreeningDto
    {
        public int movieId { get; set; }
        public int hallId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
