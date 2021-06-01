using System;
using System.Collections.Generic;
using System.Text;

namespace KLoveCoding.Service.Dtos
{
    public class VerseResultRootDto
    {
        public List<VerseDto> Verses { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool HasMorePages { get; set; }
        public object Id { get; set; }
        public object Url { get; set; }
    }
}
