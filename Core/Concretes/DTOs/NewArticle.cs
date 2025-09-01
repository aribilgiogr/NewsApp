using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    // DTO ve ViewModel bir arada tanımlandı.
    public class NewArticle
    {
        [Display(Name = "Başlık")]
        [Required]
        [MinLength(10), MaxLength(150)]
        public string Title { get; set; }

        [Display(Name = "Alt Başlık")]
        [Required]
        [MinLength(50), MaxLength(250)]
        public string SubTitle { get; set; }

        [Display(Name = "Kapak Görseli")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string CoverImage { get; set; }

        [Display(Name = "İçerik")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string HtmlContent { get; set; }

        [Display(Name = "Kategori")]
        [Required]
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
