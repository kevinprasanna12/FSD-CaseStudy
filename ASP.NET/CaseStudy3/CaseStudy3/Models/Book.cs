using System.ComponentModel.DataAnnotations;

namespace CaseStudy3.Models
{
    public class Book
    {
        [Required(ErrorMessage = "ISBN is required")]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "Book Name is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Book Name must be 1 to 20 characters")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Author Name must be 1 to 50 characters")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Published Date is required")]
        [ValidPublishedDate(ErrorMessage = "Date cannot be in the future")]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Book URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string BookUrl { get; set; }
    }

    public class ValidPublishedDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            return date <= DateTime.Now;
        }
    }
}

