﻿using System;
using Blog.Common.Entities;
using Blog.Process.Interfaces;
using HtmlAgilityPack;
using ScrapySharp.Network;

namespace Blog.Process
{
    public abstract class BlogProcessBase : IBlogProcess
    {
        private ScrapingBrowser _scrapyBrowser;

        public BlogProcessBase()
        {
            _scrapyBrowser = new ScrapingBrowser();
        }

        public abstract Catalog ParseCatalog(string catalogUrl);

        public abstract Article ParseArticle(string articleUrl);

        #region Protected

        protected HtmlNode GetHtmlNodeByUrl(string catalogUrl)
        {
            var html1 = _scrapyBrowser.DownloadString(new Uri(catalogUrl));
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html1);
            var html = htmlDocument.DocumentNode;
            return html;
        }

        #endregion Protected
    }
}