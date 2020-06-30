using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DevTeamCommunicationTool.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public virtual List<Message> MessagesSent { get; set; } = new List<Message>();
        public virtual List<Message> MessagesRecieved { get; set; } = new List<Message>();
    }
}
