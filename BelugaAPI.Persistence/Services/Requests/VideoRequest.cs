namespace BelugaAPI.Persistence.Services.Requests;

public class SendVideoTranslationRequest
{
    public string VideoId { get; set; }
    public string OriginLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public bool? HasTranscription { get; set; }
}