using Liquid.Repository;
namespace LiquidCRUDExample.Domain.Infrastructure.Repositories.Entities
{
    public class Category : RepositoryEntity<int>
    {
        public string Name { get; set; }
    }
}