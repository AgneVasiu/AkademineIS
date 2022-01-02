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
    public class TeachersController : Controller
    {

        private readonly ITeachersService _service;

        public TeachersController(ITeachersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allTeachers = await _service.GetAllAsync();
            return View(allTeachers);
        }

        //Get: Teachers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var teacherDetails = await _service.GetByIdAsync(id);
            if (teacherDetails == null) return View("NotFound");
            return View(teacherDetails);
        }

        //Get: teachers/create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicture,FullName,Sex,DateOfBirth,Email,PhoneNumber")]Teacher teacher)
        {
            if (!ModelState.IsValid) return View(teacher);
            await _service.AddAsync(teacher);
            return RedirectToAction(nameof(Index));
        }
        //Get: teachers/Edit/1
        public async Task<IActionResult> Edit(int  id)
        {
            var teacherDetails = await _service.GetByIdAsync(id);
            if (teacherDetails == null) return View("NotFound");
            return View(teacherDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePicture,FullName,Sex,DateOfBirth,Email,PhoneNumber")] Teacher teacher)
        {
            if (!ModelState.IsValid) return View(teacher);

            if(id == teacher.Id)
            {
                await _service.UpdateAsync(id, teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }
        //Get: teachers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var teacherDetails = await _service.GetByIdAsync(id);
            if (teacherDetails == null) return View("NotFound");
            return View(teacherDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherDetails = await _service.GetByIdAsync(id);
            if (teacherDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
