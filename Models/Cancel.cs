using System.ComponentModel.DataAnnotations;

namespace lab6_solution.Models;

public enum Product
{
    MindSync,
    Seraphine,
    SoulSear,
    PhantomClaw
}

public class Cancel
{
    [Display(Name = "First Name")]
    [StringLength(60, MinimumLength = 3)]
    public string FirstName {get; set;} = string.Empty;

    [Display(Name = "Last Name")]
    [StringLength(60, MinimumLength = 3)]
    public string LastName {get; set;} = string.Empty;
    
    [Display(Name = "Email Address")]
    [EmailAddress]
    public string Email {get; set;} = string.Empty;
    
    [Display(Name = "Phone Number")]
    [Phone]
    public string Phone {get; set;} = string.Empty;
    
    [Required]
    public Product? Product {get; set;}

    [Display(Name = "Agree to non-disclosure terms.")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree.")]
    public bool AgreeToNDA {get; set;}

    [Display(Name = "Agree to waive all liability.")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree.")]
    public bool AgreeToLiability {get; set;}

    [Display(Name = "Agree to early termination fee.")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree.")]
    public bool AgreeToFee {get; set;}
}