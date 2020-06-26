using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLib_Models.Models
{
    public class FluentBook
    {
        public int Book_Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public double Price { get; set; }
    }
}
