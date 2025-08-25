using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
