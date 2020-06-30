using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTeamCommunicationTool.Areas.Identity.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [Display(Name ="Send Date")]
        public DateTime SendDate { get; set; } = DateTime.Now;

        [Display(Name = "Sent By")]
        public virtual User SentBy { get; set; }
        public virtual User SentTo { get; set; }

        [NotMapped]
        public string RecieverEmail { get; set; }
    }
}
