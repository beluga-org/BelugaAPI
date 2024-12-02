using System.ComponentModel.DataAnnotations.Schema;
 
namespace BelugaAPI.Core.Entities;

[Table("user")]
public class User
{
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public string id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
    public List<Video> videos { get; set; }
    public List<AccessKey> accessKeys { get; set; }
    public List<Chat> chats { get; set; }
}