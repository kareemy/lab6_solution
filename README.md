## Your Name: LAB 6 SOLUTION

# CIDM 3312 Lab 6: Frontend 2

In this lab exercise you will create a cancellation form for the ThoughtTronix website. This form will allow the user to enter in some information and submit a cancellation request to ThoughtTronix. It will consist of two razor pages, one with the cancellation form (Cancel.cshtml) and one that displays the confirmation (Confirmation.cshtml). You will also need page models and an entity class to handle the request.

## Task 0: Prepare Your Environment

1. Create an ASP.NET Core Project using the `dotnet new webapp` command.

## Task 1: Make an Entity Class

1. Make a `Models/` folder. Within the `Models/` folder, create a file `Cancel.cs`.
2. Cancel.cs will contain the `Cancel` entity class that represents a cancellation request.
3. Add `using System.ComponentModel.DataAnnotations;` to the top of Cancel.cs to bring in support for data validation.
4. Add the proper namespace to Cancel.cs.
5. Create an enum class to represent each Product -
   
   ```
   public enum Product
   {
   MindSync,
   Seraphine,
   SoulSear,
   PhantomClaw
   }
   ```

7. Create a `Cancel` entity class with the following properties and validation rules:
   
   | Property Name | Data Validation Rules |
   |---------------|-----------------------|
   | FirstName     | Display as "First Name", Maximum length = 60, Minimum length = 3 |
   | LastName      | Display as "Last Name", Maximum length = 60, Minimum length = 3 |
   | Email         | Display as "Email Address", validate as [EmailAddress] |
   | Phone         | Display as "Phone Number", validate as [Phone], string |
   | Product       | Data Type = Product?, Required |
   | AgreeToNDA    | Data Type = bool, Display as "Agree to non-disclosure terms." |
   | AgreeToLiability | bool, Display as "Agree to waive all liability." |
   | AgreeToFee    | bool, Display as "Agree to early termination fee." |

## Task 2: Make Cancel Razor Page

1. Create a new page model named `Cancel.cshtml.cs` based on the `Index.cshtml.cs` basic page model template.
2. Add the proper `using` directive to bring in access to your Cancel class.
3. Within the `CancelModel` class, add -
```
[BindProperty]
public Cancel CancelObject {get; set;} = default!;
```
4. Create a new razor page named `Cancel.cshtml`. Make it a razor page with the `@page` keyword and connect to the CancelModel with `@model`.
5. Make your razor page look like the following (https://i.imgur.com/UM5ef5C.png):

![Image of cancel page](https://i.imgur.com/UM5ef5C.png)

6. Use the same styling as done in the Advanced Bootstrap lesson.
7. Connect the Drop Down Select List to the `enum` class with `asp-items="Html.GetEnumSelectList<Product>()"`.
8. Use placeholders and floating labels for the text input fields.

## Task 3: Code Client-Side Data Validation

1. Add JS Scripts for client-side data validation.
2. Add HTML for client-side data validation. Your razor page should look like this with data validation (https://i.imgur.com/6QKjVDr.png):

![data validation](https://i.imgur.com/6QKjVDr.png)

3. NOTE: Your checkboxes will appear green. They validate correctly whether or not they are checked. See the extra credit section if you want to require them to be checked.
4. NOTE: The phone number will not validate correctly on the client-side. It is required but will not validate to a proper phone number. That is OK for this lab.

## Task 4: Make Confirmation Razor Page

1. Create a new page model named `Confirmation.cshtml.cs` based on the `Index.cshtml.cs` basic page model template.
2. This razor page needs a reference to CancelObject as well -
```
[BindProperty]
public Cancel CancelObject {get; set;} = default!;
```
3. Within `Confirmation.cshtml.cs`, add an OnPost() method -
```
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
```
4. Create a new razor page named `Confirmation.cshtml`. Make it a razor page with the `@page` keyword and connect to the ConfirmationModel with `@model`.
5. Make your razor page look like the following (https://i.imgur.com/boguzAJ.png):

![Confirmation Page](https://i.imgur.com/boguzAJ.png)

6. Use the same styling as done in the Advanced Bootstrap lesson. This will use the `<dl>`, `<dt>`, and `<dd>` HTML tags.
7. You will also make use `@Html.DisplayNameFor()` and `@Html.DisplayFor()`.
8. Go back to `Cancel.cshtml` and use `asp-page` with the `<form>` tag to send the data to the Confirmation page -
   `<form method="post" asp-page="Confirmation">`
9. Reach out if you have any questions or need help clarifying any of the UI requirements.

## Extra Credit Task 5: Validate Check Boxes

1. Currently the checkboxes will always validate successfully. If you to require that they user tick the boxes, you need to create a few workarounds.
2. Add the following data validation rule to `Models/Cancel.cs` above each bool property -
```
[Range(typeof(bool), "true", "true", ErrorMessage = "You must agree.")]
```
This code validates the bool to a range of values between "true" and "true". It is a workaround to require the checkbox to be selected or true.
3. Open _ValidationScriptsPartial.cshtml and add the following JS code to properly perform client-side validation of this rule -
```
<script>
    $(document).ready(function() {
        $('form').validate().settings.validClass += ' is-valid';
        $('form').validate().settings.errorClass += ' is-invalid';

        var defaultRangeValidator = $.validator.methods.range;
        $.validator.methods.range = function(value, element, param) {
        if(element.type === 'checkbox') {
            // if it's a checkbox return true if it is checked
            return element.checked;
        } else {
            // otherwise run the default validation function
            return defaultRangeValidator.call(this, value, element, param);
        }
    }
    });
</script>
```
4. With these changes in place, run your app and see if you can validate the checkboxes correctly.
5. Completing this task successfully will give you +5 extra credit points on this assignment.

## Submit your assignment. You are now finished with Lab 6
   
