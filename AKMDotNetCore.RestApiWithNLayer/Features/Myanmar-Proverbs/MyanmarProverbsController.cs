using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AKMDotNetCore.RestApiWithNLayer.Features.Myanmar_Proverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : ControllerBase
{

    private async Task<ProverbModel> GetDataAsync()
    {
        var jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarProverbs.json");
        var model = JsonConvert.DeserializeObject<ProverbModel>(jsonStr);

        return model!;
    }

    [HttpGet]

    public async Task<IActionResult> ReadTitles()
    {
        var model = await GetDataAsync();
        return Ok(model.Tbl_MMProverbsTitle);
    }

    [HttpGet("{title}")]

    public async Task<IActionResult> ReadProverbs(string title)
    {
        var model = await GetDataAsync();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == title);
        if (item is null) return NotFound("NO Data found");

        var titleId = item.TitleId;
        List<Tbl_Mmproverbs> list = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId).ToList();
        return Ok(list);
    }

    [HttpGet("new/{title}")]

    public async Task<IActionResult> ReadProverbsNew(string title)
    {
        var model = await GetDataAsync();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == title);
        if (item is null) return NotFound("no data found");

        var titleId = item.TitleId;
        List<Tbl_Mmproverbs_New> list = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId).Select(x => new Tbl_Mmproverbs_New { 
            TitleId = x.TitleId ,
            ProverbId = x.ProverbId , 
            ProverbName = x.ProverbName}).ToList();

        return Ok(list);
    }

    [HttpGet("{titleId}/{proverbId}")]
         
    public async Task<IActionResult> ReadProverb(int titleId , int proverbId)
    {
        var model = await GetDataAsync();

        var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);
        if (item is null) return NotFound("data not found");

        return Ok(item);
    }

}


public class ProverbModel
{
    public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
}

public class Tbl_Mmproverbstitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class Tbl_Mmproverbs
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}

public class Tbl_Mmproverbs_New
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
}