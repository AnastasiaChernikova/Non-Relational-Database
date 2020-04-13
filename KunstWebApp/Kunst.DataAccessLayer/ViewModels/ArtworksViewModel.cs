using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ViewModels
{
    public class ArtworksViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string AuthorNickname { get; set; }

        public DateTime Date { get; set; }

        public string Style { get; set; }

        public string Genre { get; set; }

        public string Website { get; set; }
    }
}
