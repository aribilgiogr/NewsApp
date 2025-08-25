using System;
using System.Collections.Generic;

namespace Core.Concretes.DTOs
{
    public class ArticlesListItem
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishDate { get; set; }
        public CategoryMenuItem CategoryInfo { get; set; }
        public IEnumerable<string> Tags { get; set; } = new HashSet<string>();
    }
}
