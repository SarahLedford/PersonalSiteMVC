using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PersonalSiteMVC.UI.MVC;

namespace PersonalSiteMVC.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="* Name is required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "* Please enter a valid email address")]
        [Required(ErrorMessage = "* Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Subject is required")]
        public string Subject { get; set; }

        [UIHint("MultilineText")]
        [Required(ErrorMessage = "* Message is required")]
        public string Message { get; set; }


    }//end class
}//end namespace