using lab6_solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab6_solution.Pages;

public class ConfirmationModel : PageModel
{
    private readonly ILogger<ConfirmationModel> _logger;

    [BindProperty]
    public Cancel CancelObject {get; set;} = default!;

    public ConfirmationModel(ILogger<ConfirmationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("OnPost() Invalid Model State. Returning to previous page.");
            return RedirectToPage("/Cancel");
        }
        _logger.LogWarning($"OnPost() - {CancelObject.FirstName}");
        return Page();
    }
}
