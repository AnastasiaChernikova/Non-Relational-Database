using Kunst.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ViewModels
{
    public class ArtistViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Nationality { get; set; }

        public DateTime Birthdate { get; set; }

        public string ArtMovement { get; set; }

        public string Website { get; set; }

        public string HashPassword { get; set; }

        public List<Follower> Followers { get; set; }
    }
}
