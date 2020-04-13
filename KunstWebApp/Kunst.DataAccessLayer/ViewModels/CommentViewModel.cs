using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ViewModels
{
    public class CommentViewModel
    {
        public string Id { get; set; }

        public string AuthorNickname { get; set; }

        public DateTime Time { get; set; }

        public string Message { get; set; }
    }
}
