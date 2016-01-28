using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ConsoleApplication3
{
    public static class IndexMapping
    {
        public static CreateIndexDescriptor CreateIndexDescriptorForTable<T>(CreateIndexDescriptor indexDescriptor, string index, T tableName) where T : class
        {
            return indexDescriptor
               .Index(index)
               .AddMapping<T>(mappingDescriptor => mappingDescriptor
                   .MapFromAttributes());
        }

    }


}
