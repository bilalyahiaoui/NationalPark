using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    //Functions with the new table created from the Query in FavoriteParksdDAO.
    public class FavoriteParksController : Controller
    {
        private IFavoriteParksDAO favorites { get; }
        public FavoriteParksController(IFavoriteParksDAO favoriteParksDAO)
        {
            favorites = favoriteParksDAO;
        }

        public IActionResult FavoriteParks()
        {
           List<FavoriteParksViewModel> results = favorites.GetAllFavoriteParks();
            return View(results);
        }
    }
}