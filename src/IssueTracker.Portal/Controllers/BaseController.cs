using IssueTracker.Core.Data;
using IssueTracker.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IssueTracker.Portal.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUow Uow;
        public BaseController(IUow uow)
        {
            Uow = uow;
        }

        [Obsolete("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.")]
        protected JsonResult Json<T>(T data)
        {
            throw new InvalidOperationException("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.");
        }

        protected JsonResult JsonValidationError()
        {
            var result = new JsonCamelCaseResult(null);

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }

        protected JsonCamelCaseResult JsonError(string errorMessage)
        {
            var result = new JsonCamelCaseResult(null);

            result.AddError(errorMessage);

            return result;
        }

        protected JsonCamelCaseResult JsonSuccess(object value)
        {
            return new JsonCamelCaseResult(value);
        }
    }
}
