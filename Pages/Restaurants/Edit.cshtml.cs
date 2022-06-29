using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFoodDotNetCore.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData db;
        public Restaurant restaurant;
        public EditModel(IRestaurantData db)
        {
            this.db = db;
        }
        public IActionResult OnGet(int restaurantID)
        {
            restaurant = db.Get(restaurantID);
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
