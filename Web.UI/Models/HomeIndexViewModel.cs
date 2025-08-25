using Core.Concretes.DTOs;
using System.Collections.Generic;

namespace Web.UI.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ArticlesListItem> LatestArticles { get; set; } = new HashSet<ArticlesListItem>();
        public IEnumerable<CategoryMenuItem> Categories { get; set; } = new HashSet<CategoryMenuItem>();
    }
}