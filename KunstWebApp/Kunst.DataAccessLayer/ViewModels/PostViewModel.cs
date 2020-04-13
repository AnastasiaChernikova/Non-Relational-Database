using Kunst.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ViewModels
{
    public class PostViewModel
    {
        public string Id { get; set; }

        public string AuthorNickname { get; set; }

        public DateTime Time { get; set; }

        public string ArtMovement { get; set; }

        public string Message { get; set; }

        public List<Reaction> Reactions { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
