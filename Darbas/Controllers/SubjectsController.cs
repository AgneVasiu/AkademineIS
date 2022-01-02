using Darbas.Data;
using Darbas.Data.Services;
using Darbas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _service;

        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allSubjects = await _service.GetAllAsync();
            return View(allSubjects);
        }
        //Get:Subjects/Create

        public IActionResult Create()
        {
            return View();
        }
       [HttpPost]
       public async Task<IActionResult> Create([Bind("SubjectName,Creditsnumber")]Subject subject)
        {
            if (!ModelState.IsValid) return View(subject);
            await _service.AddAsync(subject);
            return RedirectToAction(nameof(Index));
        }
        //Get:Subjects/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var subjectDetails = await _service.GetByIdAsync(id);
            if (subjectDetails == null) return View("NotFound");
            return View(subjectDetails);
        }
        //Get:Subjets/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var subjectDetails = await _service.GetByIdAsync(id);
            if (subjectDetails == null) return View("NotFound");
            return View(subjectDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,SubjectName,Creditsnumber")] Subject subject)
        {
            if (!ModelState.IsValid) return View(subject);
            await _service.UpdateAsync(id, subject);
            return RedirectToAction(nameof(Index));
        }
        //Get:Subjets/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var subjectDetails = await _service.GetByIdAsync(id);
            if (subjectDetails == null) return View("NotFound");
            return View(subjectDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var subjectDetails = await _service.GetByIdAsync(id);
            if (subjectDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
