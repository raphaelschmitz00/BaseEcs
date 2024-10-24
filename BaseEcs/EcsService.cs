namespace BaseEcs;



public interface IEcsService<TKey> where TKey : notnull
{
	QueryExecutor<TKey> Queries { get; }
	public IEntityBuilder AddEntity(TKey key);
	public void DestroyComponent<TComponent>(TKey entity);
	public void DestroyEntity(TKey entity);
	public void ApplyChanges();
}



public class EcsService<TKey> : IEcsService<TKey> where TKey : notnull
{
	public QueryExecutor<TKey> Queries { get; }
	private readonly List<EntityBuilder<TKey>> _entityBuilders = [];
	private readonly List<(TKey key, Type componentType)> _componentsToDestroy = [];
	private readonly List<TKey> _entitiesToDestroy = [];
	private readonly ArchetypeList<TKey> _archetypeList;


	private EcsService(
		ArchetypeList<TKey> archetypeList,
		QueryExecutor<TKey> queryExecutor
	)
	{
		_archetypeList = archetypeList;
		Queries = queryExecutor;
	}


	public static EcsService<TKey> Create()
	{
		var archetypeList = new ArchetypeList<TKey>();
		var queryExecutor = new QueryExecutor<TKey>(archetypeList);
		return new EcsService<TKey>(archetypeList, queryExecutor);
	}


	public IEntityBuilder AddEntity(TKey key)
	{
		var entityBuilder = new EntityBuilder<TKey>(key);
		_entityBuilders.Add(entityBuilder);
		return entityBuilder;
	}


	public void DestroyComponent<TComponent>(TKey entity) =>
		_componentsToDestroy.Add((entity, typeof(TComponent)));


	public void DestroyEntity(TKey entity) => _entitiesToDestroy.Add(entity);


	public void ApplyChanges()
	{
		foreach (var entityBuilder in _entityBuilders)
		{
			entityBuilder.Build(_archetypeList);
		}

		_entityBuilders.Clear();


		foreach (var tuple in _componentsToDestroy)
		{
			_archetypeList.DestroyComponent(tuple.key, tuple.componentType);
		}

		_componentsToDestroy.Clear();


		foreach (var key in _entitiesToDestroy)
		{
			_archetypeList.DestroyEntity(key);
		}

		_entitiesToDestroy.Clear();
	}
}
