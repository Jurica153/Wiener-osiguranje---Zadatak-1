using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InsurePartner.Repositories;

namespace InsurePartner.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PartnerRepository _repository;

        public IndexModel(PartnerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<dynamic> Partners { get; set; }

        public int? NewPartnerId { get; set; }

        [BindProperty]
        public string PartnerExternalCode { get; set; }

        [BindProperty]
        public string NewPolicyNumber { get; set; }

        [BindProperty]
        public decimal NewPolicyAmount { get; set; }

        public async Task OnGetAsync(int? newPartnerId)
        {
            NewPartnerId = newPartnerId;
            Partners = await _repository.GetAllPartnersWithPolicyStatsAsync();
        }

        public async Task<IActionResult> OnPostCreatePolicyAsync()
        {
            if (string.IsNullOrEmpty(NewPolicyNumber) || NewPolicyAmount <= 0 || string.IsNullOrEmpty(PartnerExternalCode))
            {
                Partners = await _repository.GetAllPartnersWithPolicyStatsAsync();
                return Page();
            }

            int? partnerId = await _repository.GetPartnerIdByExternalCodeAsync(PartnerExternalCode);

            if (partnerId.HasValue)
            {
                await _repository.InsertPolicyAsync(partnerId.Value, NewPolicyNumber, NewPolicyAmount);
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, $"Partner s vanjskom šifrom '{PartnerExternalCode}' nije pronaðen.");
                Partners = await _repository.GetAllPartnersWithPolicyStatsAsync();
                return Page();
            }
        }
    }
}
