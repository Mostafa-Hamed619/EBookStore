using Microsoft.Identity.Client;
using System.Globalization;

namespace EBookStore.API.Models.Dto
{
    public class GetAuthorDto
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Bio { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
