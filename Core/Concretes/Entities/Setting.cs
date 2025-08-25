using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.Entities
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
