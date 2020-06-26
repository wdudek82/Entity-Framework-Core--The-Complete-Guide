using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLib_Models.Models
{
    public class FluentAuthor
    {
        public int Author_Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string Location { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
