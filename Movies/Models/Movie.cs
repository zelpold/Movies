using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата релиза")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }
        
        [Display(Name = "Цена")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name ="Рейтинг")]
        public string? Rating { get; set; }
        
        public ICollection<UsersId>? UsersId{ get; set; }
        


    }


    public class UsersId
    {
        public Guid Id { get; set; }
        public ICollection<Movie>? Movies{ get; set;}

        public UsersId()
        {
            Movies = new List<Movie>();
        }
    }
}
