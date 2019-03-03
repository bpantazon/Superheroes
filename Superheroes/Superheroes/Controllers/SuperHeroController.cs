using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Controllers
{
    public class SuperHeroController : Controller
    {
        IList<Superhero> heroList = new List<Superhero>() { };
        
        ApplicationDbContext db;
        public SuperHeroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            try
            {
                foreach (var hero in db.Superhero)
                {
                    heroList.Add(hero);
                }
            }
            catch
            {
                return View();
            }
            return View(heroList);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            var hero = db.Superhero.Where(s => s.Id == id).FirstOrDefault();
            return View(hero);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(Superhero hero)
        {
            try
            {
                // TODO: Add insert logic here
                db.Superhero.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = db.Superhero.Where(s => s.Id == id).FirstOrDefault();
            return View(hero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero hero)
        {
            try
            {
                // TODO: Add update logic here

                var updatedHero = db.Superhero.Where(s => s.Id == id).Single();

                    updatedHero.Name = hero.Name;
                    updatedHero.AlterEgo = hero.AlterEgo;
                    updatedHero.PrimaryAbility = hero.PrimaryAbility;
                    updatedHero.SecondaryAbility = hero.SecondaryAbility;
                    updatedHero.Catchphrase = hero.Catchphrase;
                    
                             
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            var hero = db.Superhero.Where(s => s.Id == id).FirstOrDefault();
            return View(hero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero hero)
        {
            try
            {
                // TODO: Add delete logic here
                hero = db.Superhero.Where(s => s.Id == hero.Id).Single();
                db.Superhero.Remove(hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
