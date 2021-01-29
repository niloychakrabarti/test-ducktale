using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentRecord.Models;

namespace StudentRecord.Controllers
{
    public class studentrecordsController : Controller
    {
        private StudentRecordsEntities db = new StudentRecordsEntities();

        // GET: studentrecords
        public ActionResult Index(string filter,string search)
        {
            if (filter == "Name")
            {
                return View(db.studentrecords.Where(x => x.FirstName.StartsWith(search) || search == null).ToList());
            }
            else if (filter == "Class")
            {
                return View(db.studentrecords.Where(x => x.Class.StartsWith(search) || search == null).ToList());
            }
            else if (filter == "Subject")
            {
                return View(db.studentrecords.Where(x => x.Subjects.StartsWith(search) || search == null).ToList());
            }
            else if(filter=="Marks")
            {
                return View(db.studentrecords.Where(x => x.Marks == Convert.ToInt32(search) || search == null).ToList());
            }
            else
            {
                return View(db.studentrecords.ToList());
            }
            
        }

        // GET: studentrecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentrecord studentrecord = db.studentrecords.Find(id);
            if (studentrecord == null)
            {
                return HttpNotFound();
            }
            return View(studentrecord);
        }

        // GET: studentrecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: studentrecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Class,Subjects,Marks")] studentrecord studentrecord)
        {
            if (ModelState.IsValid)
            {
                db.studentrecords.Add(studentrecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentrecord);
        }

        // GET: studentrecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentrecord studentrecord = db.studentrecords.Find(id);
            if (studentrecord == null)
            {
                return HttpNotFound();
            }
            return View(studentrecord);
        }

        // POST: studentrecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Class,Subjects,Marks")] studentrecord studentrecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentrecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentrecord);
        }

        // GET: studentrecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentrecord studentrecord = db.studentrecords.Find(id);
            if (studentrecord == null)
            {
                return HttpNotFound();
            }
            return View(studentrecord);
        }

        // POST: studentrecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentrecord studentrecord = db.studentrecords.Find(id);
            db.studentrecords.Remove(studentrecord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(string filter, string search)
        {
            
            if (filter == "Name")
            {
                return View(db.studentrecords.Where(x => x.FirstName.StartsWith(search) || search==null).ToList());
            }
            else if (filter == "Class")
            {
                return View(db.studentrecords.Where(x => x.Class == search || search==null).ToList());
            }
            else if (filter == "Subjects")
            {
                return View(db.studentrecords.Where(x => x.Subjects == search || search == null).ToList());
            }
            else
            {
                return View(db.studentrecords.Where(x => x.Marks == Convert.ToInt32(search) || search == null).ToList());
            }
            
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
