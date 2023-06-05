using System;
using System.Collections.Generic;
using System.Linq;

namespace AsQueryableBenchmarks
{
    public static class ModelExtensions
    {
        public static IQueryable<Field> WithIdQ(this IEnumerable<Field> source, Guid? id) =>
            source.AsQueryable().Where(x => x.Id == id);
        
        public static Table WithFieldQ(this IEnumerable<Table> tables, Guid fieldId)
        {
            return tables.SingleOrDefault(table => table.Fields.WithIdQ(fieldId).Any());
        }
        
        public static IEnumerable<Field> WithIdE(this IEnumerable<Field> source, Guid? id) =>
            source.Where(x => x.Id == id);
        
        public static Table WithFieldE(this IEnumerable<Table> tables, Guid fieldId)
        {
            return tables.SingleOrDefault(table => table.Fields.WithIdE(fieldId).Any());
        }
    }
}
