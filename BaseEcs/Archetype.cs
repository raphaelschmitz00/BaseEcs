namespace BaseEcs;



public class Archetype(HashSet<Type> componentTypes)
{
	public IReadOnlyDictionary<Type, int> TypeIndices { get; } =
		componentTypes
			.Select((type, index) => (type, index))
			.ToDictionary(x => x.type, x => x.index);

	public ICollection<Type> ComponentTypes { get; } = componentTypes;


	public bool HasOnlyComponents(IEnumerable<Type> types) =>
		componentTypes.SetEquals(types);


	public bool HasComponents(IEnumerable<Type> types) =>
		componentTypes.IsSupersetOf(types);
}
