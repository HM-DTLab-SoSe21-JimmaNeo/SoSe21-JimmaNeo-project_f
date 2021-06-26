using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private NewsService NewsService { get; set; }

        private IMapper Mapper { get; set; }

        public NewsController(NewsService newsService, IMapper mapper)
        {
            this.NewsService = newsService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns all news.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<NewsDTO[]> GetAllNews()
        {
            var allNews = NewsService.GetAllNews();
            var mappedResult = Mapper.Map<NewsDTO[]>(allNews);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Adds or updates a news.
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<NewsDTO> AddOrUpdateNews([FromBody] NewsDTO news)
        {
            if (ModelState.IsValid)
            {
                var mappedNews = Mapper.Map<News>(news);

                if (mappedNews.NewsId == 0)
                {
                    mappedNews = NewsService.AddNews(mappedNews);
                }
                else
                {
                    mappedNews = NewsService.UpdateNews(mappedNews);
                }

                var mappedNewsDTO = Mapper.Map<NewsDTO>(mappedNews);
                return Ok(mappedNewsDTO);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a news. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteNews([FromRoute] int id)
        {
            var news = NewsService.GetNewsWithId(id);
            if (news == null) return StatusCode(StatusCodes.Status404NotFound);

            NewsService.RemoveNews(news);
            return Ok();
        }


    }
}
