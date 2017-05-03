using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Umbraco.Web;

namespace LIAUmbraApp.Models
{
    public class ContactModel : IValidatableObject
    {
        private readonly UmbracoHelper _umbHelper = new UmbracoHelper();
        //[Required]
        //[ValidateFirstName]
        public string FirstName { get; set; }

        //[Required]
        public string LastName { get; set; }

        //[Required]
        //[EmailAddress]
        public string EmailAddress { get; set; }

        //[Required]
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

            if (EmailAddress == null)
            {
                yield return new ValidationResult($"{_umbHelper.GetDictionaryValue("emailRequired")}");
            }

            if (Message == null)
            {
                yield return new ValidationResult($"{_umbHelper.GetDictionaryValue("messageRequired")}");
            }

            if (EmailAddress != null && !new EmailAddressAttribute().IsValid(EmailAddress))
            {
                yield return new ValidationResult($"{_umbHelper.GetDictionaryValue("validEmail")}");
            }
        }
    }

    public class ValidateFirstName : ValidationAttribute
    {
        private readonly UmbracoHelper _umbHelper = new UmbracoHelper();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"{_umbHelper.GetDictionaryValue("firstNameRequired")}");
            }
            return ValidationResult.Success;
        }
    }

}