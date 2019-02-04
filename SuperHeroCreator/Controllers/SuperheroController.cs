using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperHeroCreator.Models;

namespace SuperHeroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext SuperHerosDB = new ApplicationDbContext();

        // GET: Superhero
        public ActionResult Index()
        {
            var superhero = SuperHerosDB.SuperHeros.ToList();

            {
                return View(superhero);
            }

        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            var heroDetails = SuperHerosDB.SuperHeros.Find(id);
            return View(heroDetails);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="SuperheroNamae, HerosAlterEgo, PrimaryAbility, SecondaryAbility, CatchPhrase")] SuperHeros superheros)
        {
            try
            {
                SuperHerosDB.SuperHeros.Add(superheros);
                SuperHerosDB.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = SuperHerosDB.SuperHeros.SingleOrDefault(h => h.SuperheroId == id);
            return View(hero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHeros superheros)
        {
            try
            {
                var hero = SuperHerosDB.SuperHeros.SingleOrDefault(h => h.SuperheroId == id);
                hero.SuperheroName = superheros.SuperheroName;
                hero.HerosAlterEgo = superheros.HerosAlterEgo;
                hero.PrimaryAbility = superheros.PrimaryAbility;
                hero.SecondaryAbility = superheros.SecondaryAbility;
                hero.CatchPhrase = superheros.CatchPhrase;
                SuperHerosDB.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            var hero = SuperHerosDB.SuperHeros.Find(id);
            return View(hero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHeros superheros)
        {
            try
            {
                superheros = SuperHerosDB.SuperHeros.Find(id);
                SuperHerosDB.SuperHeros.Remove(superheros);
                SuperHerosDB.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
