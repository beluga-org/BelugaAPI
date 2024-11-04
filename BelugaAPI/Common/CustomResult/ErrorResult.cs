using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelugaAPI.Common.CustomResult;
public class ErrorResult : IActionResult
{
    private readonly BaseObjectResult _result;

    public ErrorResult(int ErrorCode, params string[] errors)
    {
        if (ErrorCode == 404)
        {
            _result = new BaseObjectResult
            {
                StatusCode = StatusCodes.Status404NotFound,
                Errors = errors.ToList()
            };
        }

    }

    public ErrorResult(object value, params string[] errors)
    {
        _result = new BaseObjectResult
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Result = value,
            Errors = errors.ToList()
        };
    }

    public ErrorResult(params string[] errors)
    {
        _result = new BaseObjectResult
        {
            StatusCode = StatusCodes.Status404NotFound,
            Errors = errors.ToList()
        };
    }

    public ErrorResult(Exception ex)
    {

        _result = new BaseObjectResult
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Errors = new List<String>()
        };

        //{ String.Concat(ex.Message, " - ", ex.InnerException) }
        Exception loopException = ex;

        while (loopException != null)
        {
            _result.Errors.Add(loopException.Message);
            loopException = loopException.InnerException;
        }
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(_result)
        {
            StatusCode = StatusCodes.Status500InternalServerError

        };

        await objectResult.ExecuteResultAsync(context);
    }
}

