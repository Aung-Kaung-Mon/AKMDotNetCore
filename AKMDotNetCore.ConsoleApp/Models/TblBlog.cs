using System;
using System.Collections.Generic;

namespace AKMDotNetCore.ConsoleApp.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogArthur { get; set; } = null!;

    public string BlogContent { get; set; } = null!;
}
