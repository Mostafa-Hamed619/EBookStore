namespace EBookStore.API.Models.Dto
{
    public class AddAuthorDto
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Bio { get; set; }

    }
}
