using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab6_solution.Models;

namespace lab6_solution.Pages;

public class CancelModel : PageModel
{
    private readonly ILogger<CancelModel> _logger;

    [BindProperty]
    public Cancel CancelObject {get; set;} = default!;
    public CancelModel(ILogger<CancelModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
