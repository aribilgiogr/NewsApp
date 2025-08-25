using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool Draft { get; set; } = true;
        // ?: Boş geçilebilen alanları belirtir.
        public DateTime? PublishDate { get; set; } = null;

        public string CoverImage { get; set; }
        public string HtmlContent { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}
