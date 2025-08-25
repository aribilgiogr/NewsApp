using Core.Abstracts.BaseModels;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; } = new HashSet<Article>();
    }
}
