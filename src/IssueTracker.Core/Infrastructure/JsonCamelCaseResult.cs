using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Core.Infrastructure
{
    public class JsonCamelCaseResult : JsonResult
    {
        public IList<string> ErrorMessages { get; private set; }
        public JsonCamelCaseResult(object value) : base(value)
        {
            ErrorMessages = new List<string>();
            Value = value;
        }

        public void AddError(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
        }

        public override void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType.ToString()) ? "application/json" : ContentType.ToString();


            SerializeData(response).Wait();
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var response = context.HttpContext.Response;
            response.ContentType = ContentType == null || string.IsNullOrEmpty(ContentType.ToString()) ? "application/json" : ContentType.ToString();


            await SerializeData(response);
        }

        protected virtual async Task SerializeData(HttpResponse response)
        {
            if (ErrorMessages.Any())
            {
                var originalData = Value;
                Value = new
                {
                    Success = false,
                    OriginalData = originalData,
                    ErrorMessage = string.Join("\n", ErrorMessages),
                    ErrorMessages = ErrorMessages.ToArray()
                };

                response.StatusCode = 400;
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[]
                {
                    new StringEnumConverter(),
                },
                StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };


            await response.WriteAsync(JsonConvert.SerializeObject(Value, settings));

        }
    }
}
