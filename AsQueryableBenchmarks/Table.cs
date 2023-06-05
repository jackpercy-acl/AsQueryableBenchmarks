using System;
using System.Collections.Generic;

namespace AsQueryableBenchmarks
{
    public class Table
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Field> Fields { get; set; }
    }
}
