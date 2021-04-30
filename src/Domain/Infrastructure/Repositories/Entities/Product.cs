using System.Collections.Generic;
using Liquid.Repository;
namespace LiquidCRUDExample.Domain.Infrastructure.Repositories.Entities
{
    public class Product : RepositoryEntity<int>
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public List<Comment> Comments { get; set; }
    }
}