﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperiencePostCoreWebApp.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please Enter First Name e.g. John")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name e.g. Doe")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password should not be blank")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [DisplayName("Cell Number")]
        [Required(ErrorMessage = "Cell Number should not be blank")]

        public string CellNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        [DisplayName("Profile Picture")]
        [Required(ErrorMessage = "Profile Picture should not be blank")]
        public string ProfilePicture { get; set; } = "noImage.png";
        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }

    }
}
