﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoerseWebApp3BHWII.Models;
using BoerseWebApp3BHWII.Repositories;

namespace BoerseWebApp3BHWII.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        AktienRepository repo = new AktienRepository();
        List<Aktien> myAktien = repo.GetAllAktien();
        
        return View(myAktien);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}