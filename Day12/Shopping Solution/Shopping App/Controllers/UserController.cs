﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_App.Interfaces;
using Shopping_App.Models.DTOs;

namespace Shopping_App.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        public IActionResult Register(UserDTO viewModel)
        {
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException exp)
            {
                ViewBag.Message = "User name already exits";
            }
            catch (Exception)
            {
                ViewBag.Message = "Invalid data. Coudld not register";
                throw;
            }

            return View();
        }
        
        [HttpPost("Login")]
        public IActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                TempData.Add("username", userDTO.Username);
                return RedirectToAction("Index", "Home");
            }
            ViewData["Message"] = "Invalid username or password";
            return View();
        }
    }
}