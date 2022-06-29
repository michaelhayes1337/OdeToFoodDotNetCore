using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFoodDotNetCore.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData db;

        public string Message { get; set; }
        public int RestaurantCount { get; set; }
        public IEnumerable<Restaurant> restaurantData { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public ListModel(IRestaurantData db)
        {
            this.Message = "Something";
            this.db = db;
            
        }

        public IActionResult OnGet()
        {
            RestaurantCount = db.GetAll().Count();
            restaurantData = String.IsNullOrEmpty(SearchTerm) ? db.GetAll() : db.GetRestaurantsByName(SearchTerm);
            
            return Page();
        }
    }
}
