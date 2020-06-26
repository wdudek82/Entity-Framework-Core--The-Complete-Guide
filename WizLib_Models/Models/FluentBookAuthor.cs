using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLib_Models.Models
{
    public class FluentBookAuthor
    {
        public int Book_Id { get; set; }

        public int Author_Id { get; set; }
    }
}
