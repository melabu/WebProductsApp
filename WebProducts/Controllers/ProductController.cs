﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebProducts.Data;
using WebProducts.Models;

namespace WebProducts.Controllers
{
    public class ProductController : Controller
    {
        private ProductDbContext context = new ProductDbContext();

        public ActionResult Index(string category, string name)
        {
            int cat = string.IsNullOrEmpty(category) ? 0 : 2;
            int nam = string.IsNullOrEmpty(name) ? 0 : 1;
            int val = cat | nam;
            switch (val)
            {
                case 0:
                    return View(context.Products.ToList());
                case 1:
                    return View((from p in context.Products
                                 where p.ProductName == name
                                 select p).ToList<Product>());
                case 2:
                    return View((from p in context.Products
                                 where p.Category == category
                                 select p).ToList<Product>());
                case 3:
                    return View((from p in context.Products
                                 where p.Category == category && p.ProductName == name
                                 select p).ToList<Product>());
                default:
                    return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();
            return View("Create", product);
        }

        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", product);
        }

        public ActionResult Detail(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View("Detail", product);
        }

        public ActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View("Edit", product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", product);
        }

        public ActionResult Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View("Delete", product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}