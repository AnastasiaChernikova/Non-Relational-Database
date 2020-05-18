﻿using MVC.Core.Entities;
using System;
using System.Collections.Generic;

namespace MVC.ViewModels
{
    public class PostViewModel
    {
        public string Id { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorName { get; set; }

        public string AuthorNickname { get; set; }

        public string AuthorAvatar { get; set; }

        public DateTime Time { get; set; }

        public string Text { get; set; }

        public int Views{ get; set; }

        public List<Reactions> Reactions { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
