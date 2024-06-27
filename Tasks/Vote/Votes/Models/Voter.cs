using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Votes.Models
{
    public class Voter
    {
        [Required(ErrorMessage = "please enter  name")]
        public string Name { get; set; }
        [Key]
        [ValidateNever]
        public int Id { get; set; }
        
        public string Notes { get; set; }
        [Required(ErrorMessage = "please enter Job")]
        public string Job { get; set; }
        [Required(ErrorMessage = "please enter  Year Of Experience")]
        [Range(1, int.MaxValue, ErrorMessage = @" not less than 1")]
        public int YearOfExperience { get; set; }
        [Required(ErrorMessage = "please enter Age")]
        [Range(16, 60, ErrorMessage = @" must be between 16 & 60")]
        public int Age { get; set; }
        [Required(ErrorMessage = "please enter Salaries")]
        public double Salaries { get; set; }
        [Required(ErrorMessage = "Please enter the level of experience.")]
        public string Level { get; set; }
    }
}
