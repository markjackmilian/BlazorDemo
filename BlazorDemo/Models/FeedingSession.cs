using System;
using System.ComponentModel.DataAnnotations;
using BlazorDemo.Enums;
using FormGenerator.Core;
using FormGenerator.Models;

namespace BlazorDemo.Models
{
    public class FeedingSession
    {
        public FeedingSession()
        {

        }

        [Display(Name = "Kind of food")]
        public FoodKind KindOfFood { get; set; }

        [Display(Name = "Note")]
        [MinLength(5)]
        public string Note { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Display(Name = "Throwing up")]
        public bool ThrowingUp { get; set; }

        [Display(Name = "Throwing up dict")]
        public ValueReferences<FoodKind> ThrowingUpDict { get; set; } = new ValueReferences<FoodKind>();

        [Display(Name = "Color")]
        public FgColor Color { get; set; }
    }
}
