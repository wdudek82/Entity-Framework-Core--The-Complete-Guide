using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLib_Models.Models
{
    [Table("tb_Genre")]
    public class Genre
    {
        public int GenreId { get; set; }
        [Column("Name")]
        public string GenreName { get; set; }
        // public int DisplayOrder { get; set; }
    }
}
