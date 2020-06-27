namespace WizLib_Models.Models
{
    public class FluentBookAuthor
    {
        public int Book_Id { get; set; }

        public int Author_Id { get; set; }

        public FluentBook FluentBook { get; set; }
        public FluentAuthor FluentAuthor { get; set; }
    }
}
