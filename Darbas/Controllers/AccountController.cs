﻿using Darbas.Data;
using Darbas.Data.Static;
using Darbas.Data.ViewModels;
using Darbas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>
            signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong login inserts. Try again!";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong login inserts. Try again!";
            return View(loginVM);
        }
        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if(user != null)
            {
                TempData["Error"] = "This Email address is already in use";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                //correction username gale
               UserName = registerVM.UserName
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
            
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return View("RegisterCompleted");
        }
        public IActionResult RegisterTeacher()
        {
            var response = new RegisterVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This Email address is already in use";
                return View(registerVM);
            }
            var newTeacher = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                //correction username gale
                UserName = registerVM.UserName
            };
            var newTeacherResponse = await _userManager.CreateAsync(newTeacher, registerVM.Password);

            if (newTeacherResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newTeacher, UserRoles.Teacher);
            }
            return View("RegisterCompleted");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
