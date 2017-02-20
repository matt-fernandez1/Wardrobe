using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe2.Models;

namespace Wardrobe2.Controllers
{
    public class ClothingPropertiesController : Controller
    {
        private AWardrobeEntities db = new AWardrobeEntities();

        // GET: ClothingProperties
        public ActionResult Index()
        {
            var clothingProperties = db.ClothingProperties.Include(c => c.Accessory).Include(c => c.Bottom).Include(c => c.Sho).Include(c => c.Top);
            return View(clothingProperties.ToList());
        }

        // GET: ClothingProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingProperty clothingProperty = db.ClothingProperties.Find(id);
            if (clothingProperty == null)
            {
                return HttpNotFound();
            }
            return View(clothingProperty);
        }

        // GET: ClothingProperties/Create
        public ActionResult Create()
        {
            ViewBag.ClothingID = new SelectList(db.Accessories, "AccessoriesID", "Accessories");
            ViewBag.ClothingID = new SelectList(db.Bottoms, "BottomsID", "Bottoms");
            ViewBag.ClothingID = new SelectList(db.Shoes, "ShoesID", "Shoes");
            ViewBag.ClothingID = new SelectList(db.Tops, "TopsID", "Tops");
            return View();
        }

        // POST: ClothingProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothingID,Name,Photo,Color,Season,Occasion")] ClothingProperty clothingProperty)
        {
            if (ModelState.IsValid)
            {
                db.ClothingProperties.Add(clothingProperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClothingID = new SelectList(db.Accessories, "AccessoriesID", "Accessories", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Bottoms, "BottomsID", "Bottoms", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Shoes, "ShoesID", "Shoes", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Tops, "TopsID", "Tops", clothingProperty.ClothingID);
            return View(clothingProperty);
        }

        // GET: ClothingProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingProperty clothingProperty = db.ClothingProperties.Find(id);
            if (clothingProperty == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClothingID = new SelectList(db.Accessories, "AccessoriesID", "Accessories", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Bottoms, "BottomsID", "Bottoms", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Shoes, "ShoesID", "Shoes", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Tops, "TopsID", "Tops", clothingProperty.ClothingID);
            return View(clothingProperty);
        }

        // POST: ClothingProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothingID,Name,Photo,Color,Season,Occasion")] ClothingProperty clothingProperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothingProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClothingID = new SelectList(db.Accessories, "AccessoriesID", "Accessories", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Bottoms, "BottomsID", "Bottoms", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Shoes, "ShoesID", "Shoes", clothingProperty.ClothingID);
            ViewBag.ClothingID = new SelectList(db.Tops, "TopsID", "Tops", clothingProperty.ClothingID);
            return View(clothingProperty);
        }

        // GET: ClothingProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingProperty clothingProperty = db.ClothingProperties.Find(id);
            if (clothingProperty == null)
            {
                return HttpNotFound();
            }
            return View(clothingProperty);
        }

        // POST: ClothingProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClothingProperty clothingProperty = db.ClothingProperties.Find(id);
            db.ClothingProperties.Remove(clothingProperty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
