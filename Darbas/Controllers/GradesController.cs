using Darbas.Data;
using Darbas.Data.Services;
using Darbas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Controllers
{
    public class GradesController : Controller
    {
        private readonly IGradesService _service;

        public GradesController(IGradesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allGrades = await _service.GetAllAsync(n => n.Subject);
            return View(allGrades);
        }
        //Get: Grades/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var gradeDetails = await _service.GetGradeByIdAsync(id);
            return View(gradeDetails);
        }


        //Get: Grades/Create
        public async Task<IActionResult> Create()
        {
            var gradeDropdownData = await _service.GetNewGradeDropdownsValues();
            ViewBag.Subjects = new SelectList(gradeDropdownData.Subjects, "Id", "SubjectName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewGradeVM grade)
        {
            if (!ModelState.IsValid) 
            {
                var gradeDropdownData = await _service.GetNewGradeDropdownsValues();
                ViewBag.Subjects = new SelectList(gradeDropdownData.Subjects, "Id", "SubjectName");
                return View(grade);
            }
            await _service.AddNewGradeAsync(grade);
            return RedirectToAction(nameof(Index));
        }

        //Get: Grades/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var gradeDetails = await _service.GetGradeByIdAsync(id);
            if (gradeDetails == null) return View("NotFound");

            var response = new NewGradeVM()
            {
                Id = gradeDetails.Id,
                Grade1 = gradeDetails.Grade1,
                Grade2 = gradeDetails.Grade2,
                Grade3 = gradeDetails.Grade3,
                Grade4 = gradeDetails.Grade4,
                Grade5 = gradeDetails.Grade5,
                SubjectId = gradeDetails.SubjectId
            };

            var gradeDropdownData = await _service.GetNewGradeDropdownsValues();
            ViewBag.Subjects = new SelectList(gradeDropdownData.Subjects, "Id", "SubjectName");
            
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (int id, NewGradeVM grade)
        {
            if (id != grade.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var gradeDropdownData = await _service.GetNewGradeDropdownsValues();
                ViewBag.Subjects = new SelectList(gradeDropdownData.Subjects, "Id", "SubjectName");
                return View(grade);
            }
            await _service.UpdateGradeAsync(grade);
            return RedirectToAction(nameof(Index));
        }

        //Get: Grades/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var gradeDetails = await _service.GetByIdAsync(id);
            if (gradeDetails == null) return View("NotFound");
            return View(gradeDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var gradeDetails = await _service.GetByIdAsync(id);
            if (gradeDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
