using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BelugaAPI.Common.CustomResult;
public class ModelValidationResult : IActionResult
{
    private readonly BaseObjectResult _result;

    public ModelValidationResult(ModelStateDictionary modelState)
    {
        _result = new BaseObjectResult
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity,

            Errors = modelState.Keys
            .SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage))
            .ToList()
        };
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(_result)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity
        };

        await objectResult.ExecuteResultAsync(context);
    }
}
