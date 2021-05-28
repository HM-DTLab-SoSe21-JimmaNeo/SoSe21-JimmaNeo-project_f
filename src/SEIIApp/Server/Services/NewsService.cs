using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public News[] GetAllNews()
        {
            return GetQueryableForNews().ToArray();
        }

        public News GetNewsWithId(int id)
        {
            return GetQueryableForNews().Where(news => news.NewsId == id).FirstOrDefault();
        }

        public News AddNews(News news)
        {
            DatabaseContext.News.Add(news);
            DatabaseContext.SaveChanges();
            return news;
        }

        public News UpdateNews(News news)
        {
            var exsistingNews = GetNewsWithId(news.NewsId);
            Mapper.Map(news, exsistingNews);

            DatabaseContext.News.Update(exsistingNews);
            DatabaseContext.SaveChanges();
            return exsistingNews;
        }


        public void RemoveNews(News news)
        {
            DatabaseContext.News.Remove(news);
            DatabaseContext.SaveChanges();
        }

    }
}
