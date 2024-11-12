namespace BelugaAPI.Application.InputModel;

public class TranslationInputModel
{
    public string language { get; set; }
    public string videoId { get; set; }
    public string status { get; set; }
    public string? translationUrl { get; set; }
    public string? subtitleUrl { get; set; }
}

public class UpdateTranslationInputModel
{
    public string? language { get; set; }
    public string? videoId { get; set; }
    public string? status { get; set; }
    public string? translationUrl { get; set; }
    public string? subtitleUrl { get; set; }
}
