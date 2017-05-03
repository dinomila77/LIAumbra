using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace LIAUmbraApp.Models
{
    public class ContactViewModel : IValidatableObject
    {
        private readonly UmbracoHelper _umbHelper = new UmbracoHelper();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName == null)
            {
                yield return new ValidationResult($"{_umbHelper.GetDictionaryValue("firstNameRequired")}");
            }

            if (LastName == null)
            {
                yield return new ValidationResult($"{_umbHelper.GetDictionaryValue("lastNameRequired")}");
            }

            if (Message == null)
            {
                yield return new ValidationResult($"{_umbHelper.GetDictionaryValue("messageRequired")}");
            }
        }
    }
}