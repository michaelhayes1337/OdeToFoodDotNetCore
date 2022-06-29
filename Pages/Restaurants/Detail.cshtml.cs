using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFoodDotNetCore.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData db;

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData db)
        {
            this.db = db;
        }
        public IActionResult OnGet(int restaurantID)
        {
            Restaurant = db.Get(restaurantID);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}
