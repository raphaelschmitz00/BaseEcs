namespace BaseEcs;



public interface IEntityBuilder
{
	IEntityBuilder WithComponent<TComponent>(TComponent component)
		where TComponent : notnull;
}



internal class EntityBuilder<TKey>(TKey key) : IEntityBuilder
	where TKey : notnull
{
	private TKey Key { get; } = key;
	private readonly Dictionary<Type, object> _components = [];


	public IEntityBuilder WithComponent<TComponent>(TComponent component)
		where TComponent : notnull
	{
		_components.Add(typeof(TComponent), component);
		return this;
	}


	public void Build(ArchetypeList<TKey> archetypeList)
	{
		archetypeList.AddNewEntity(Key, _components);
	}
}
