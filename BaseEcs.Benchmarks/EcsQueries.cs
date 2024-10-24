using BenchmarkDotNet.Attributes;

namespace BaseEcs.Benchmarks;



/*
Last result

| Method       | Entities | Mean     | Error   | StdDev  | Ratio | RatioSD |
|------------- |--------- |---------:|--------:|--------:|------:|--------:|
| ProcessQuery | 100000   | 104.4 us | 2.03 us | 2.41 us |  1.00 |    0.03 |

 */
public class EcsQueries
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
						ValueA = random.Next(10),
						ValueB = random.Next(10)
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

		var counter = MyQuery.Counter;
		//Console.WriteLine($"{MyQuery.Counter} / {MyQuery2.Counter} / {MyQuery3.Counter}");
		MyQuery3.Counter = 0;
		MyQuery2.Counter = MyQuery3.Counter;
		MyQuery.Counter = MyQuery2.Counter;
		return counter;
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
		public int ValueA;
		public int ValueB;
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
		public static long Counter;


		public void Execute(
			Span<int> e,
			Span<MyComponentA> componentAs,
			Span<MyComponentB> componentBSpan
		)
		{
			Counter += e.Length;
			for (var i = 0; i < e.Length; i++)
			{
				if (componentAs[i].Value > 10)
				{
					componentAs[i].Value = 0;
					componentBSpan[i].Value += 1;
				}
			}
		}
	}



	private struct MyQuery3 : IQuery<int, MyComponentB, MyComponentC>
	{
		public static long Counter;


		public void Execute(
			Span<int> e,
			Span<MyComponentB> componentBs,
			Span<MyComponentC> componentBSpan
		)
		{
			Counter += e.Length;
			for (var i = 0; i < e.Length; i++)
			{
				if (componentBSpan[i].ValueA > 10)
				{
					componentBs[i].Value -= componentBSpan[i].ValueB;
				}

				componentBSpan[i].ValueA += componentBs[i].Value;
			}
		}
	}
}
