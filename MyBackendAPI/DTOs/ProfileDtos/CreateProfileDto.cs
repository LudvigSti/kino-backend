namespace MyBackendAPI.DTOs.ProfileDtos
{
    public class CreateProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Icon { get; set; }
        public int Points { get; set; }
    }
}
