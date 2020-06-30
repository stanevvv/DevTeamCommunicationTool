using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("Messages")]
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IdentityUser Sender { get; set; }
    }
}
