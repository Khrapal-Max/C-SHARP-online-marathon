using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace NUnitShoppingSystem.Test
{
    public class DBContextMock
    {
        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T: class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(x => x.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }
    }
}
