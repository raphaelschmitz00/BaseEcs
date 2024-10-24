using BenchmarkDotNet.Attributes;

namespace BaseEcs.Benchmarks;


/*
 Last result
 
| Method       | Entities | Mean     | Error    | StdDev   | Ratio | RatioSD |
|------------- |--------- |---------:|---------:|---------:|------:|--------:|
| ProcessQuery | 100000   | 63.52 us | 1.048 us | 0.929 us |  1.00 |    0.02 |

 */
public class SimpleEcsQueries
{
	[Params(100_000)] public int Entities;


	private readonly EcsService<int> _ecsService = EcsService<int>.Create();


	[GlobalSetup]
	public void GlobalSetup()
	{
		var random = new Random(12345);

		for (int i = 0; i < Entities; i++)
		{
			var entityBuilder = _ecsService.AddEntity(i);
			var componentDecision = random.NextSingle();

			if (componentDecision < 0.6f)
			{
				entityBuilder.WithComponent(
					new MyComponentA
					{
						Value = random.Next(10)
					}
				);
			}

			if (componentDecision > 0.2f && componentDecision < 0.7f)
			{
				entityBuilder.WithComponent(
					new MyComponentB { Value = random.Next(10) }
				);
			}

			if (componentDecision > 0.5f)
			{
				entityBuilder.WithComponent(
					new MyComponentC
					{
						Value = random.Next(10)
					}
				);
			}
		}

		_ecsService.ApplyChanges();
	}


	[Benchmark(Baseline = true)]
	public long ProcessQuery()
	{
		var myQuery = new MyQuery();
		var myQuery2 = new MyQuery2();
		var myQuery3 = new MyQuery3();

		_ecsService.Queries.Execute<MyQuery, MyComponentA>(myQuery);
		_ecsService.Queries.Execute<MyQuery2, MyComponentA, MyComponentB>(myQuery2);
		_ecsService.Queries.Execute<MyQuery3, MyComponentB, MyComponentC>(myQuery3);

		return MyQuery.Counter;
	}



	private struct MyComponentA
	{
		public int Value;
	}



	private struct MyComponentB
	{
		public int Value;
	}



	private struct MyComponentC
	{
		public int Value;
	}



	private struct MyQuery : IQuery<int, MyComponentA>
	{
		public static long Counter;


		public void Execute(Span<int> e, Span<MyComponentA> component)
		{
			Counter += e.Length;
			for (var i = 0; i < e.Length; i++)
			{
				component[i].Value++;
			}
		}
	}



	private struct MyQuery2 : IQuery<int, MyComponentA, MyComponentB>
	{
		public void Execute(
			Span<int> e,
			Span<MyComponentA> componentASpan,
			Span<MyComponentB> componentBSpan
		)
		{
			for (var i = 0; i < e.Length; i++)
			{
				componentASpan[i].Value++;
				componentBSpan[i].Value++;
			}
		}
	}



	private struct MyQuery3 : IQuery<int, MyComponentB, MyComponentC>
	{
		public void Execute(
			Span<int> e,
			Span<MyComponentB> componentBSpan,
			Span<MyComponentC> componentCSpan
		)
		{
			for (var i = 0; i < e.Length; i++)
			{
				componentBSpan[i].Value++;
				componentCSpan[i].Value++;
			}
		}
	}
}
