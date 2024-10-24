namespace BaseEcs;



public class QueryExecutor<TKey>(
	ArchetypeList<TKey> archetypeList
) where TKey : notnull
{
	public void Execute<TQuery, TComponent>(TQuery query)
		where TQuery : IQuery<TKey, TComponent>
	{
		var componentTypes = new[] { typeof(TComponent) };

		var chunkLists = archetypeList.GetFittingChunkLists(componentTypes);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent>()
				);
			}
		}
	}


	public void Execute<TQuery, TComponent1, TComponent2>(TQuery query)
		where TQuery : IQuery<TKey, TComponent1, TComponent2>
	{
		var componentTypes = new[] { typeof(TComponent1), typeof(TComponent2) };

		var chunkLists = archetypeList.GetFittingChunkLists(componentTypes);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>()
				);
			}
		}
	}


	public void Execute<TQuery, TComponent1, TComponent2, TComponent3>(TQuery query)
		where TQuery : IQuery<TKey, TComponent1, TComponent2, TComponent3>
	{
		var chunkLists = archetypeList.GetFittingChunkLists(
			[typeof(TComponent1), typeof(TComponent2), typeof(TComponent3)]
		);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>(),
					chunk.GetSpan<TComponent3>()
				);
			}
		}
	}


	public void Execute<TQuery, TComponent1, TComponent2, TComponent3, TComponent4>(TQuery query) where TQuery : IQuery
		<TKey, TComponent1, TComponent2, TComponent3, TComponent4>
	{
		var chunkLists = archetypeList.GetFittingChunkLists(
			[
				typeof(TComponent1),
				typeof(TComponent2),
				typeof(TComponent3),
				typeof(TComponent4)
			]
		);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>(),
					chunk.GetSpan<TComponent3>(),
					chunk.GetSpan<TComponent4>()
				);
			}
		}
	}


	public void Execute<
		TQuery,
		TComponent1,
		TComponent2,
		TComponent3,
		TComponent4,
		TComponent5>(TQuery query)
		where TQuery : IQuery<
			TKey,
			TComponent1,
			TComponent2,
			TComponent3,
			TComponent4,
			TComponent5>
	{
		var chunkLists = archetypeList.GetFittingChunkLists(
			[
				typeof(TComponent1),
				typeof(TComponent2),
				typeof(TComponent3),
				typeof(TComponent4),
				typeof(TComponent5)
			]
		);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>(),
					chunk.GetSpan<TComponent3>(),
					chunk.GetSpan<TComponent4>(),
					chunk.GetSpan<TComponent5>()
				);
			}
		}
	}


	public void Execute<
		TQuery,
		TComponent1,
		TComponent2,
		TComponent3,
		TComponent4,
		TComponent5,
		TComponent6>(TQuery query)
		where TQuery : IQuery<
			TKey,
			TComponent1,
			TComponent2,
			TComponent3,
			TComponent4,
			TComponent5,
			TComponent6>
	{
		var chunkLists = archetypeList.GetFittingChunkLists(
			[
				typeof(TComponent1),
				typeof(TComponent2),
				typeof(TComponent3),
				typeof(TComponent4),
				typeof(TComponent5),
				typeof(TComponent6)
			]
		);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>(),
					chunk.GetSpan<TComponent3>(),
					chunk.GetSpan<TComponent4>(),
					chunk.GetSpan<TComponent5>(),
					chunk.GetSpan<TComponent6>()
				);
			}
		}
	}


	public void Execute<
		TQuery,
		TComponent1,
		TComponent2,
		TComponent3,
		TComponent4,
		TComponent5,
		TComponent6,
		TComponent7>(TQuery query)
		where TQuery : IQuery<
			TKey,
			TComponent1,
			TComponent2,
			TComponent3,
			TComponent4,
			TComponent5,
			TComponent6,
			TComponent7>
	{
		var chunkLists = archetypeList.GetFittingChunkLists(
			[
				typeof(TComponent1),
				typeof(TComponent2),
				typeof(TComponent3),
				typeof(TComponent4),
				typeof(TComponent5),
				typeof(TComponent6),
				typeof(TComponent7)
			]
		);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>(),
					chunk.GetSpan<TComponent3>(),
					chunk.GetSpan<TComponent4>(),
					chunk.GetSpan<TComponent5>(),
					chunk.GetSpan<TComponent6>(),
					chunk.GetSpan<TComponent7>()
				);
			}
		}
	}


	public void Execute<
		TQuery,
		TComponent1,
		TComponent2,
		TComponent3,
		TComponent4,
		TComponent5,
		TComponent6,
		TComponent7,
		TComponent8>(TQuery query)
		where TQuery : IQuery<
			TKey,
			TComponent1,
			TComponent2,
			TComponent3,
			TComponent4,
			TComponent5,
			TComponent6,
			TComponent7,
			TComponent8>
	{
		var chunkLists = archetypeList.GetFittingChunkLists(
			[
				typeof(TComponent1),
				typeof(TComponent2),
				typeof(TComponent3),
				typeof(TComponent4),
				typeof(TComponent5),
				typeof(TComponent6),
				typeof(TComponent7),
				typeof(TComponent8)
			]
		);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>(),
					chunk.GetSpan<TComponent3>(),
					chunk.GetSpan<TComponent4>(),
					chunk.GetSpan<TComponent5>(),
					chunk.GetSpan<TComponent6>(),
					chunk.GetSpan<TComponent7>(),
					chunk.GetSpan<TComponent8>()
				);
			}
		}
	}


	public void Execute<
		TQuery,
		TComponent1,
		TComponent2,
		TComponent3,
		TComponent4,
		TComponent5,
		TComponent6,
		TComponent7,
		TComponent8,
		TComponent9>(TQuery query)
		where TQuery : IQuery<
			TKey,
			TComponent1,
			TComponent2,
			TComponent3,
			TComponent4,
			TComponent5,
			TComponent6,
			TComponent7,
			TComponent8,
			TComponent9>
	{
		var chunkLists = archetypeList.GetFittingChunkLists(
			[
				typeof(TComponent1),
				typeof(TComponent2),
				typeof(TComponent3),
				typeof(TComponent4),
				typeof(TComponent5),
				typeof(TComponent6),
				typeof(TComponent7),
				typeof(TComponent8),
				typeof(TComponent9)
			]
		);

		foreach (var chunkList in chunkLists)
		{
			foreach (var chunk in chunkList.ChunkSpan)
			{
				query.Execute(
					chunk.GetEntitySpan(),
					chunk.GetSpan<TComponent1>(),
					chunk.GetSpan<TComponent2>(),
					chunk.GetSpan<TComponent3>(),
					chunk.GetSpan<TComponent4>(),
					chunk.GetSpan<TComponent5>(),
					chunk.GetSpan<TComponent6>(),
					chunk.GetSpan<TComponent7>(),
					chunk.GetSpan<TComponent8>(),
					chunk.GetSpan<TComponent9>()
				);
			}
		}
	}
}
