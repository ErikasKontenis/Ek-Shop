using Ek.Shop.Application.Abstractions;
using Ek.Shop.Application.InputForms;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Ek.Shop.Web.Infrastructure
{
    public sealed class WorkContextMiddleware
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IWorkContext _workContext;

        public WorkContextMiddleware(IQueryProcessor queryProcessor, IWorkContext workContext)
        {
            _queryProcessor = queryProcessor;
            _workContext = workContext;
        }

        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            var request = context.Request;
            if (request.Headers.ContainsKey("IsApiAdmin"))
            {

                var inputFormResult = await _queryProcessor.GetQueryHandler<GetInputFormCommand, InputFormDto>(new GetInputFormCommand(InputFormCodes.Admin));
                if (inputFormResult.Failure)
                {
                    throw new Exception("Unable to find Admin input form");
                }

                var inputForm = inputFormResult.Object;
                _workContext.WorkingInputFormId = inputForm.Id;
                _workContext.WorkingInputFormName = inputForm.Name;
                _workContext.WorkingLanguageId = 2;
                _workContext.WorkingLanguageName = Languages.English;
            }
            else if (request.Headers.ContainsKey("IsApiClient"))
            {
                var activeInputForm = (await _queryProcessor
                       .GetQueryHandler<GetSystemSettingCommand, OptionDto>(new GetSystemSettingCommand(SystemSettingOptions.ActiveInputForm.Name))).Object;
                var inputFormResult = await _queryProcessor.GetQueryHandler<GetInputFormCommand, InputFormDto>(new GetInputFormCommand(activeInputForm.Value));
                if (inputFormResult.Failure)
                {
                    throw new Exception("Unable to find Client input form");
                }

                var inputForm = inputFormResult.Object;
                _workContext.WorkingInputFormId = inputForm.Id;
                _workContext.WorkingInputFormName = inputForm.Name;
                _workContext.WorkingLanguageId = 1;
                _workContext.WorkingLanguageName = Languages.Lithuanian;
            }

            await next();
        }
    }
}
