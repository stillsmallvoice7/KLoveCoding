using KLoveCoding.Service.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace KLoveCoding.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Number Of Verses")]
        [Required(ErrorMessage = "Please enter the number of verses")]
        public int? NumberOfVerses { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Please seelct the start date")]
        public DateTime? StartDate { get; set; }
        public VerseResultRootDto VerseResultRootDto { get; set; }
    }
}
