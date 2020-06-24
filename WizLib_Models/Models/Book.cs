using System.ComponentModel.DataAnnotations;

namespace WizLib_Models.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
