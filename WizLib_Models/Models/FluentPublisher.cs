using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WizLib_Models.Models
{
    public class FluentPublisher
    {
        public int Publisher_Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<FluentBook> FluentBooks { get; set; }
    }
}
