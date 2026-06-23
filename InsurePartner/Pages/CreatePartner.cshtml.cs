using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InsurePartner.Models;
using InsurePartner.Repositories;

namespace InsurePartner.Pages
{
    public class CreatePartnerModel : PageModel
    {
        private readonly PartnerRepository _repositoy;

        public CreatePartnerModel(PartnerRepository repository)
        {
            _repositoy = repository;
        }

        [BindProperty]
        public Partner NoviPartner { get; set; }
        public void OnGet()
        {
            // Ovdje možemo inicijalizirati NoviPartner ako je potrebno
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Ako validacija padne, ostajemo na formi i prikazujemo greške
            }

            int noviId = await _repositoy.InsertPartnerAsync(NoviPartner);
            return RedirectToPage("/Index", new { newPartnerId = noviId });
        }
    }
}
