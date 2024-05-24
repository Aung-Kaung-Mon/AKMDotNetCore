using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Formats.Asn1;



namespace AKMDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {

       private async Task<LatHtaukBayDin> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonStr);

            return model!;
        }

        [HttpGet("questions")]

        public async Task<IActionResult> GetQuestions()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }

        [HttpGet("numberList")]

        public async Task<IActionResult> GetNumberList()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }

        [HttpGet("{questionNo}/{answerNo}")]

        public async Task<IActionResult> GetAnswerResult(int questionNo , int answerNo)
        {
            var model = await GetDataAsync();
            var answerResult = model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == answerNo);

            return Ok(answerResult);
        }
    }

    public class LatHtaukBayDin
    {
        public Question[] questions { get; set; }
        public Answer[] answers { get; set; }
        public string[] numberList { get; set; }
    }

    public class Question
    {
        public int questionNo { get; set; }
        public string questionName { get; set; }
    }

    public class Answer
    {
        public int questionNo { get; set; }
        public int answerNo { get; set; }
        public string answerResult { get; set; }
    }

}
