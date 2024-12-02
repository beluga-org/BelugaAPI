using System.ComponentModel.DataAnnotations.Schema;

namespace BelugaAPI.Core.Entities;

[Table("video")]
public class Video
{
    public string id { get; set; }
    [Column("original_name")]
    public string originalName { get; set; }
    [Column("original_language")]
    public string originalLanguage{ get; set; }
    [Column("assistant_external_id")]
    public string? assistantExternalId { get; set; }
    [Column("original_url")]
    public string originalUrl { get; set; }
    [Column("user_id")]
    public string userId { get; set; }
    public User user { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
    public List<Translation> translations { get; set; }
    public List<Chat> chats { get; set; }
}