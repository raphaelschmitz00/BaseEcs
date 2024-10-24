using System.Diagnostics;

namespace BaseEcs;



public class Chunk<TKey>(
	int size,
	Array[] componentArrays,
	IReadOnlyDictionary<Type, int> typeIndices
) where TKey : notnull
{
	private readonly TKey[] _entities = new TKey[size];
	private readonly Dictionary<TKey, int> _entityIndices = [];


	public bool HasSpace => EntityCount < size;
	public bool HasEntities => EntityCount > 0;

	private int EntityCount { get; set; }


	public Span<TKey> GetEntitySpan() =>
		_entities.AsSpan(0, EntityCount);


	public Span<T> GetSpan<T>()
	{
		var typeIndex = typeIndices[typeof(T)];
		var array = componentArrays[typeIndex];
		var componentArray = (T[])array;
		return componentArray.AsSpan(0, EntityCount);
	}


	public Dictionary<Type, object> GetComponents(TKey entity)
	{
		var entityIndex = _entityIndices[entity];

		return typeIndices.ToDictionary(
			kvp => kvp.Key,
			kvp =>
			{
				var array = componentArrays[kvp.Value];
				return array.GetValue(entityIndex) ?? throw new InvalidOperationException();
			}
		);
	}


	public void AddEntity(TKey entity, IReadOnlyDictionary<Type, object> componentValues)
	{
		Debug.Assert(EntityCount < size);

		_entities[EntityCount] = entity;
		_entityIndices[entity] = EntityCount;

		foreach (var component in componentValues)
		{
			var typeIndex = typeIndices[component.Key];
			var array = componentArrays[typeIndex];
			array.SetValue(component.Value, EntityCount);
		}

		EntityCount++;
	}


	public void RemoveEntity(TKey entity)
	{
		var index = _entityIndices[entity];

		EntityCount--;

		if (index != EntityCount)
		{
			MoveEntity(EntityCount, index);
		}

		foreach (var componentType in componentArrays)
		{
			Array.Clear(componentType, EntityCount, 1);
		}

		_entities[EntityCount] = default!;
		_entityIndices.Remove(entity);
	}


	private void MoveEntity(int fromIndex, int toIndex)
	{
		Debug.Assert(fromIndex >= 0);
		Debug.Assert(fromIndex < EntityCount);
		Debug.Assert(toIndex >= 0);
		Debug.Assert(toIndex < EntityCount);
		Debug.Assert(fromIndex != toIndex);

		var lastEntity = _entities[fromIndex];
		_entities[toIndex] = lastEntity;

		foreach (var componentType in componentArrays)
		{
			Array.Copy(componentType, fromIndex, componentType, toIndex, 1);
		}

		_entityIndices[lastEntity] = toIndex;
	}
}
