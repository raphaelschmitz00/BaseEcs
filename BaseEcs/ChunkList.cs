using System.Runtime.InteropServices;

namespace BaseEcs;



public class ChunkList<TKey>(Archetype archetype) where TKey : notnull
{
	private readonly List<Chunk<TKey>> _chunks = [];


	public Span<Chunk<TKey>> ChunkSpan => CollectionsMarshal.AsSpan(_chunks);
	public bool HasChunks => _chunks.Count > 0;

	private int ChunkSize { get; set; } = 16;


	public Chunk<TKey> GetChunkWithSpace()
	{
		var alreadyExistingChunkWithSpace = _chunks.FirstOrDefault(x => x.HasSpace);
		if (alreadyExistingChunkWithSpace != null) return alreadyExistingChunkWithSpace;

		ChunkSize *= 2;
		var newChunk = Create();
		_chunks.Add(newChunk);
		return newChunk;
	}


	private Chunk<TKey> Create()
	{
		var typeIndices = archetype.TypeIndices;

		var componentArrays =
			typeIndices
				.OrderBy(x => x.Value)
				.Select(x => Array.CreateInstance(x.Key, ChunkSize))
				.ToArray();

		return new Chunk<TKey>(ChunkSize, componentArrays, typeIndices);
	}


	public void Remove(Chunk<TKey> chunk)
	{
		_chunks.Remove(chunk);
	}
}
