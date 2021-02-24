using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstDemo.Models;

namespace FirstDemo.Controllers
{
    public class StudentController : Controller
    {
        // 1. *************RETRIEVE ALL STUDENT DETAILS ******************
        // GET: Student
      
        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            StudentDBHandle dbhandle = new StudentDBHandle();
            var dd = dbhandle.GetStudent().ToList();

            switch (SortBy)
            {
                case "Name":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    dd = dd.OrderBy(x => x.Name).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    dd = dd.OrderByDescending(x => x.Name).ToList();
                                    break;
                                }
                            default:
                                {
                                    dd = dd.OrderBy(x => x.Name).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "City":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    dd = dd.OrderBy(x => x.City).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    dd = dd.OrderByDescending(x => x.City).ToList();
                                    break;
                                }
                            default:
                                {
                                    dd = dd.OrderBy(x => x.City).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "DOB":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    dd = dd.OrderBy(x => x.DOB).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    dd = dd.OrderByDescending(x => x.DOB).ToList();
                                    break;
                                }
                            default:
                                {
                                    dd = dd.OrderBy(x => x.DOB).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        dd = dd.OrderBy(x => x.Name).ToList();
                        break;
                    }
            }

            ModelState.Clear();
            return View(dd);

        }
        // 2. *************ADD NEW STUDENT ******************
        // GET: Student/Create
        public ActionResult Create(int? id)
        {
            StudentDBHandle sdb = new StudentDBHandle();
            var dd = sdb.GetStudent().Find(smodel => smodel.Id == id);
            //dd.IsMovie = (dd.IsMovie == false) ? false : dd.IsMovie;
            //dd.IsCricket = (dd.IsCricket == false) ? false : dd.IsCricket;
            var genList = sdb.GenList().ToList();
            ViewBag.GenList = new SelectList(genList, "Id", "Name");
            return View(dd);
            //  return View(sdb.GetStudent().Find(smodel => smodel.Id == id));
        }
        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
               
                //if (ModelState.IsValid)
                //{
                StudentDBHandle sdb = new StudentDBHandle();
                if (smodel.Id > 0)
                {
                    sdb.UpdateDetails(smodel);
                    return RedirectToAction("Index");
                    //if (sdb.UpdateDetails(smodel))
                    //{
                    //    ViewBag.Message = "Student Details Updated Successfully";
                    //    ModelState.Clear();
                    //}
                }
                else
                {
                    if (sdb.AddStudent(smodel))
                    {
                        // ViewBag.Message = "Student Details Added Successfully";
                        return RedirectToAction("Index");
                      //  ModelState.Clear();
                    }
                }
                //}
                return View();
            }
            catch
            {
                return View();
            }
        }

        // 3. ************* EDIT STUDENT DETAILS ******************
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDBHandle sdb = new StudentDBHandle();
            var dd = sdb.GetStudent().Find(smodel => smodel.Id == id);
           
            return View();
            //  return View(sdb.GetStudent().Find(smodel => smodel.Id == id));
        }

        // POST: Student/Edit/5
        //  [HttpPost]
        public ActionResult Eite(StudentModel smodel)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE STUDENT DETAILS ******************
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                if (sdb.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Demo()
        {

            return View();
        }
        
        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }




    }
}
