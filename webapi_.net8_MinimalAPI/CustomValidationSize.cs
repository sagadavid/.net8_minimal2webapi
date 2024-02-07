using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace webapi_.net8_MinimalAPI
{
    public class CustomValidationSize : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);

            var validShirt = validationContext.ObjectInstance as ShirtModel;
            if (validShirt != null && !string.IsNullOrEmpty(validShirt.Gender))
            {
                if (validShirt.Gender.Equals("Male",
                    StringComparison.OrdinalIgnoreCase)
                    && validShirt.Size < 6)
                {
                    return new ValidationResult("shirt size for Male cannot be smaller than 6");
                }
                else if (validShirt.Gender.Equals("Female",
                    StringComparison.OrdinalIgnoreCase)
                    && validShirt.Size < 4)
                    {
                    return new ValidationResult("Female shirt size is no less than 4");
                }
            }
            return ValidationResult.Success;

        }
    }
}

/*
 {
    "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "errors": {
        "Size": [
            "shirt size for Male cannot be smaller than 6"
        ]
    },
    "traceId": "00-aa4958bb87a5dc4cf2226cdb50593a14-64dd62dc35005f47-00"
}
 */ 