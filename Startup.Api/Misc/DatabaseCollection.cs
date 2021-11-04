using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Startup.Api.Misc
{
    public class DatabaseCollection : IEnumerable
    {
        public DatabaseCollection((Type dbContextType, Type interfaceEntity)[] databaseEntities)
        {
            Items = databaseEntities.Select(x => new DatabaseCollectionItem(x.dbContextType, x.interfaceEntity));
        }

        public IEnumerable<DatabaseCollectionItem> Items { get; }

        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }

    public class DatabaseCollectionItem
    {
        public Type DbContextType { get; }
        public Type InterfaceEntity { get; }

        public DatabaseCollectionItem(Type dbContextType, Type interfaceEntity)
        {
            DbContextType = dbContextType;
            InterfaceEntity = interfaceEntity;
        }
    }
}
