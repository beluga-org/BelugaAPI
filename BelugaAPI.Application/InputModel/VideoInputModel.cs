using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelugaAPI.Application.InputModel;
public class VideoInputModel
{
    public IFormFile file { get; set; }
    public string originalLanguage { get; set; }
    public string targetLanguage { get; set; }
    public string userId { get; set; }
}

public class VideoAddContentInputModel
{
    public string content { get; set; }
}