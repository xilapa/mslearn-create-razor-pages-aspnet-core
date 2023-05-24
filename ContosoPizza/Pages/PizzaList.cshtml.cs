using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPiza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;
        
        [BindProperty]
        public Pizza? NewPizza { get; set; }

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }
        
        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza is null)
                return Page();
            
            _service.AddPizza(NewPizza);
            return RedirectToAction(nameof(OnGet));
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);
            return RedirectToAction(nameof(OnGet));
        }
    }
}
