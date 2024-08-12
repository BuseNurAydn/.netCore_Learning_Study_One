using System.ComponentModel.DataAnnotations;

namespace Study_One.Models
{
    public class Todo : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //bire bir ilişki -  bir todo da bir category var
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
