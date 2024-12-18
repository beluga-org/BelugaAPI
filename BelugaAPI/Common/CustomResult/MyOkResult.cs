﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelugaAPI.Common.CustomResult;
public class MyOkResult : IActionResult
{
    private readonly BaseObjectResult _result;

    public MyOkResult(object value, string message = null)
    {
        _result = new BaseObjectResult
        {
            StatusCode = StatusCodes.Status200OK,
            Result = value,
            Message = message
        };
    }

    public MyOkResult(string message = null)
    {
        _result = new BaseObjectResult
        {
            StatusCode = StatusCodes.Status200OK,
            Message = message
        };
    }

    public MyOkResult()
    {
        _result = new BaseObjectResult
        {
            StatusCode = StatusCodes.Status200OK
        };
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(_result)
        {
            StatusCode = StatusCodes.Status200OK

        };

        await objectResult.ExecuteResultAsync(context);
    }
}
