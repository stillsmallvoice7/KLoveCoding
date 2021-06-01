using KLoveCoding.DAL.Common;

namespace KLoveCoding.DAL.Models
{
    public partial class Favorite : BaseEntity
    {
        public int Id { get; set; }        
        public string VerseText { get; set; }        
        public string ImageLink { get; set; }
        public string VerseApiId { get; set; }
        public bool IsActive { get; set; }
    }
}
