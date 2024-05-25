using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AKMDotNetCore.RestApiWithNLayer.Features.PickAPile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private async Task<PickAPile> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("Features/PickAPile/PickAPile.json");
            var model = JsonConvert.DeserializeObject<PickAPile>(jsonStr);

            return model!;
        }

        [HttpGet]

        public async Task<IActionResult> GetQuestions()
        {
            var model = await GetDataAsync();
            return Ok(model.Questions);
        }

        [HttpGet("{questionId}")]

        public async Task<IActionResult> GetAnswers(int questionId)
        {
            var model = await GetDataAsync();
            var item = model.Questions.FirstOrDefault(x => x.QuestionId == questionId);
            if( item is null ) return NotFound("no data found");

            int id = item.QuestionId;
            List<Answer> answerList = model.Answers.Where(x => x.QuestionId == id).ToList();
            return Ok(answerList);
        }

        [HttpGet("{questionId}/{answerId}")]

        public async Task<IActionResult> GetAnswer(int questionId, int answerId)
        {
            var model = await GetDataAsync();
            var item = model.Answers.FirstOrDefault(x => x.QuestionId == questionId && x.AnswerId == answerId);
            if (item is null) return NotFound("no data found");

            return Ok(item);
        }
    }


    public class PickAPile
    {
        public Question[] Questions { get; set; }
        public Answer[] Answers { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDesp { get; set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerImageUrl { get; set; }
        public string AnswerName { get; set; }
        public string AnswerDesp { get; set; }
        public int QuestionId { get; set; }
    }

}
