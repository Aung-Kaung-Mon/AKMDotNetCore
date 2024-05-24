using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.RestApiWithNLayer.Models;

[Table("Tbl_Blogs")]

public class BlogModel
{
    [Key]
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogArthur { get; set; }

    public string? BlogContent { get; set; }

}
