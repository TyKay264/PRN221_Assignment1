﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface INewsArticleRepository
    {
        List<NewsArticle> getNewsArticles();


        void SaveNewsArticle(NewsArticle newsArticle);


        void UpdateNewsArticle(NewsArticle newsArticle);


        void DeleteNewsArticle(NewsArticle newsArticle);


        NewsArticle GetNewsArticlesById(string id);
        List<NewsArticle> GetNewsArticlesByWriterId(int writerId);


    }
}
