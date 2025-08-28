using System.ComponentModel.DataAnnotations;
 
 namespace RepoDemo.Api.Models
 {
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [Required, StringLength(100)]
        public string Name { get; set; }


        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
         
         public int Stock { get; set; }
         
     }
 }