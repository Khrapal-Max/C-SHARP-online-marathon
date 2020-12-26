using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSystem.Test
{
    public class DbContextMock
    {
        public DbSet <T> GetQueryableMockDbset<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());
            dbSet.Setup(x => x.Add(It.IsAny<T>())).Callback<T>((x) => sourceList.Add(x));
            return dbSet.Object;
        }
    }
}
