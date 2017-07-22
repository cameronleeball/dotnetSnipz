using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using dotnetSnipz.Models;
using System.Diagnostics.Contracts;

namespace dotnetSnipz.Controllers
{
    public class SnippetController : Controller
    {
        public IActionResult Index()
        {
            MongoDBContext dbContext = new MongoDBContext();

            List<Snippet> snippetList = dbContext.Snippets.Find(m => true).ToList();

            return View(snippetList);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var entity = dbContext.Snippets.Find(m => m.Id == id).FirstOrDefault();

            return View(entity);
        }

		[HttpGet]
		public IActionResult Detail(Guid id)
		{
			MongoDBContext dbContext = new MongoDBContext();
			var entity = dbContext.Snippets.Find(m => m.Id == id).FirstOrDefault();



			return View(entity);
		}

		[HttpGet]
		public IActionResult Search(string lang)
		{;
            MongoDBContext dbContext = new MongoDBContext();
            var resultsList = dbContext.Snippets.Find(m=> m.Lang == lang);

			return View(resultsList);
		}

		[HttpPost]
        public IActionResult Edit(Snippet entity)
        {
            MongoDBContext dbContext = new MongoDBContext();

            //you can use the UpdateOne to get higher performance if you need.
            dbContext.Snippets.ReplaceOne(m => m.Id == entity.Id, entity);

            return View(entity);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Snippet entity)
        {
            MongoDBContext dbContext = new MongoDBContext();

            entity.Id = Guid.NewGuid();

            dbContext.Snippets.InsertOne(entity);

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDBContext dbContext = new MongoDBContext();

            dbContext.Snippets.DeleteOne(m => m.Id == id);

            return Redirect("/");
        }
    }
}
