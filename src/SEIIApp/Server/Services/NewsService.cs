using AutoMapper;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services
{
    public class NewsService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public NewsService (DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<News> GetQueryableForNews()
        {
            return DatabaseContext.News;
        }

        /// <summary>
        /// Returns all news.
        /// </summary>
        /// <returns></returns>
        public News[] GetAllNews()
        {
            return GetQueryableForNews().ToArray();
        }

        /// <summary>
        /// Returns a news with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News GetNewsWithId(int id)
        {
            return GetQueryableForNews().Where(news => news.NewsId == id).FirstOrDefault();
        }

        /// <summary>
        /// Adds a news.
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public News AddNews(News news)
        {
            DatabaseContext.News.Add(news);
            DatabaseContext.SaveChanges();
            return news;
        }

        /// <summary>
        /// Updates a news.
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public News UpdateNews(News news)
        {
            var exsistingNews = GetNewsWithId(news.NewsId);
            Mapper.Map(news, exsistingNews);

            DatabaseContext.News.Update(exsistingNews);
            DatabaseContext.SaveChanges();
            return exsistingNews;
        }

        /// <summary>
        /// Removes a news.
        /// </summary>
        /// <param name="news"></param>
        public void RemoveNews(News news)
        {
            DatabaseContext.News.Remove(news);
            DatabaseContext.SaveChanges();
        }

    }
}
