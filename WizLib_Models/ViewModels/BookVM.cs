using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizLib_Models.Models;

namespace WizLib_Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }

    }
}
