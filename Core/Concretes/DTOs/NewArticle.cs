using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class NewArticle
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string CoverImage { get; set; }
        public string HtmlContent { get; set; }
        public int CategoryId { get; set; }
    }
    public class EditArticle
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string CoverImage { get; set; }
        public string HtmlContent { get; set; }
        public int CategoryId { get; set; }
    }
}
