
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace contratacoesWeb.Models
{
    [CollectionName("Roles")]
    public class Roles : MongoIdentityRole<Guid>
    {
    }
}
