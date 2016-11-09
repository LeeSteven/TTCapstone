using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TurboTechCapstone.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        public string RecipeName { get; set; }
        [Required]
        public string Ingredients { get; set; }

        public string Description { get; set; }

    }
}