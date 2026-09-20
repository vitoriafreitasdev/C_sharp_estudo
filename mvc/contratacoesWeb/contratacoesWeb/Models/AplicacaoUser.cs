using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


namespace contratacoesWeb.Models
{
    [CollectionName("AplicacaoUser")]
    public class AplicacaoUser : MongoIdentityUser<Guid>
    {
    }
}
