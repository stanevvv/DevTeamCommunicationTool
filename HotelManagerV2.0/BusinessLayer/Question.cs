using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Question
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string QuestionAsked { get; set; }

        public QuestionSender Sender { get; set; }
    }
}
