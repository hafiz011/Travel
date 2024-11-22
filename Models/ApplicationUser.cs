using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Flyjaatra.IdentityModels
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
        // Add custom properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
