using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.ConsoleAppHttpClientExample
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogArthur { get; set; }

        public string? BlogContent { get; set; }

    }

}
