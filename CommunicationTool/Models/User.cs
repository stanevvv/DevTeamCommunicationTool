using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class User : IdentityUser<int>
    {
        //[Key]
        //public int Id { get; set; }

        public List<Message> MessagesSent { get; set; }
    }
}
