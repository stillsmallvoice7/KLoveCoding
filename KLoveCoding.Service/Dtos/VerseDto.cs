using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KLoveCoding.Service.Dtos
{
    public class VerseDto
    {
        [Display(Name = "Verse Text")]
        public string VerseText { get; set; }
        [Display(Name = "Image")]
        public string ImageLink { get; set; }
        public DateTime VerseDate { get; set; }
        public string VideoLink { get; set; }
        public string ReferenceLink { get; set; }
        public string VerseNumbers { get; set; }
        public string Chapter { get; set; }
        public string Book { get; set; }
        public string ReferenceText { get; set; }
        public string BibleReferenceLink { get; set; }
        public string FacebookShareUrl { get; set; }
        public string TwitterShareUrl { get; set; }
        public string PinterestShareUrl { get; set; }
        public bool IsValid { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
    }
}
