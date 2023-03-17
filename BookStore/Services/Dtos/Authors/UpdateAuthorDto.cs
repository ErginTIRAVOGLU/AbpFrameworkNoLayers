using BookStore.Contens;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Services.Dtos.Authors
{
    public class UpdateAuthorDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirtDate { get; set; }

        public string ShortBio { get; set; }
    }
}
