# `.AsQueryable()` Benchmarks

Some benchmarks of the `IEnumerable` extension method `.AsQueryable()`.

## Results

|                    Method |                Job |            Runtime |            Mean |         Error |          StdDev |          Median |
|-------------------------- |------------------- |------------------- |----------------:|--------------:|----------------:|----------------:|
|          InlineEnumerable |           .NET 6.0 |           .NET 6.0 |        827.9 ns |      26.48 ns |        73.37 ns |        801.0 ns |
|           InlineQueryable |           .NET 6.0 |           .NET 6.0 |  5,384,721.5 ns | 106,356.81 ns |   180,601.93 ns |  5,339,189.8 ns |
|  ExtensionMethodQueryable |           .NET 6.0 |           .NET 6.0 |  8,728,990.5 ns | 495,489.06 ns | 1,453,183.64 ns |  8,198,828.1 ns |
| ExtensionMethodEnumerable |           .NET 6.0 |           .NET 6.0 |      1,325.1 ns |      56.01 ns |       162.50 ns |      1,265.9 ns |
|          InlineEnumerable |      .NET Core 3.1 |      .NET Core 3.1 |      1,211.2 ns |      52.47 ns |       149.69 ns |      1,154.2 ns |
|           InlineQueryable |      .NET Core 3.1 |      .NET Core 3.1 |  6,504,211.8 ns | 212,455.56 ns |   616,372.09 ns |  6,213,507.0 ns |
|  ExtensionMethodQueryable |      .NET Core 3.1 |      .NET Core 3.1 |  8,186,277.6 ns | 148,351.28 ns |   131,509.54 ns |  8,136,007.0 ns |
| ExtensionMethodEnumerable |      .NET Core 3.1 |      .NET Core 3.1 |      1,941.5 ns |      78.50 ns |       231.45 ns |      1,884.7 ns |
|          InlineEnumerable | .NET Framework 4.8 | .NET Framework 4.8 |      1,142.4 ns |      44.23 ns |       129.71 ns |      1,099.5 ns |
|           InlineQueryable | .NET Framework 4.8 | .NET Framework 4.8 |  9,070,071.2 ns | 378,424.93 ns | 1,115,794.44 ns |  8,390,901.6 ns |
|  ExtensionMethodQueryable | .NET Framework 4.8 | .NET Framework 4.8 | 12,395,017.0 ns | 357,850.87 ns | 1,026,741.21 ns | 11,874,745.3 ns |
| ExtensionMethodEnumerable | .NET Framework 4.8 | .NET Framework 4.8 |      1,875.9 ns |      86.84 ns |       256.06 ns |      1,739.5 ns |
