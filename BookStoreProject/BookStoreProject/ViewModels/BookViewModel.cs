
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStoreProject.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [StringLength(150,ErrorMessage = "A maximum of 150 characters can be entered.")]
        [Required(ErrorMessage = "The book name field cannot be empty.")]
        [Remote(action:"HasBookName", controller:"Book")]
        public string? Name { get; set; }
        [StringLength(150, ErrorMessage = "A maximum of 150 characters can be entered.")]
        [Required(ErrorMessage = "The book author field cannot be empty.")]
        public string? Author { get; set; }
        
        [Range(0,2023,ErrorMessage = "Book year must be between 0 and 2023")]
        [Required(ErrorMessage = "The book year field cannot be empty.")]
        public int? Year { get; set; }
    }
}
