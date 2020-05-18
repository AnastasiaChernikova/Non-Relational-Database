using MVC.Core.Entities;
using System.Collections.Generic;

namespace MVC.ViewModels
{
    public class ArtistViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Followers> Followers { get; set; }
        public string Avatar { get; set; }
    }
}
