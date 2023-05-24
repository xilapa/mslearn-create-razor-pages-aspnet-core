using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPiza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }
        
        public void OnGetAsync()
        {
            PizzaList = _service.GetPizzas();
        }
    }
}
