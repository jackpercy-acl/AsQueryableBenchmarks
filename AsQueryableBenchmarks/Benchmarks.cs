using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace AsQueryableBenchmarks
{
    [ShortRunJob(RuntimeMoniker.Net60)]
    [ShortRunJob(RuntimeMoniker.NetCoreApp31)]
    [ShortRunJob(RuntimeMoniker.Net48)]
    [ShortRunJob(RuntimeMoniker.Net47)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmarks
    {
        private ICollection<Table> _tables;

        private Guid _fieldId;

        [GlobalSetup]
        public void Setup()
        {
            _tables = Enumerable.Range(0, 10)
                .Select(i => new Table
                {
                    Id = Guid.NewGuid(),
                    Name = $"Table {i}",
                    Fields = Enumerable.Range(0, 5)
                        .Select(j => new Field
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Table {i} - Field {j}"
                        })
                        .ToArray()
                })
                .ToArray();
        
            var allFields = _tables.SelectMany(t => t.Fields).ToArray();
            var index = new Random().Next(0, allFields.Length - 1);
        
            _fieldId = allFields[index].Id;
        }
        
        [Benchmark]
        public void InlineEnumerable()
        {
            var table = _tables.Where(t => t.Fields.Where(f => f.Id == _fieldId).Any()).SingleOrDefault();
        }
        
        [Benchmark]
        public void InlineQueryable()
        {
            var table = _tables.Where(t => t.Fields.AsQueryable().Where(f => f.Id == _fieldId).Any()).SingleOrDefault();
        }

        [Benchmark]
        public void ExtensionMethodQueryable()
        {
            var table = _tables.WithFieldQueryable(_fieldId);
        }
        
        [Benchmark]
        public void ExtensionMethodEnumerable()
        {
            var table = _tables.WithFieldEnumerable(_fieldId);
        }
    }
}
