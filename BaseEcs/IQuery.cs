namespace BaseEcs;



public interface IQuery<TKey, TComponent>
{
	void Execute(Span<TKey> e, Span<TComponent> componentSpan);
}



public interface IQuery<TKey, TComponent1, TComponent2>
{
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span
	);
}



public interface IQuery<TKey, TComponent1, TComponent2, TComponent3>
{
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span,
		Span<TComponent3> component3Span
	);
}



public interface IQuery<TKey, TComponent1, TComponent2, TComponent3, TComponent4>
{
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span,
		Span<TComponent3> component3Span,
		Span<TComponent4> component4Span
	);
}



public interface IQuery<
	TKey,
	TComponent1,
	TComponent2,
	TComponent3,
	TComponent4,
	TComponent5>
{
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span,
		Span<TComponent3> component3Span,
		Span<TComponent4> component4Span,
		Span<TComponent5> component5Span
	);
}



public interface IQuery<
	TKey,
	TComponent1,
	TComponent2,
	TComponent3,
	TComponent4,
	TComponent5,
	TComponent6>
{
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span,
		Span<TComponent3> component3Span,
		Span<TComponent4> component4Span,
		Span<TComponent5> component5Span,
		Span<TComponent6> component6Span
	);
}



public interface IQuery<
	TKey,
	TComponent1,
	TComponent2,
	TComponent3,
	TComponent4,
	TComponent5,
	TComponent6,
	TComponent7>
{
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span,
		Span<TComponent3> component3Span,
		Span<TComponent4> component4Span,
		Span<TComponent5> component5Span,
		Span<TComponent6> component6Span,
		Span<TComponent7> component7Span
	);
}



public interface IQuery<
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
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span,
		Span<TComponent3> component3Span,
		Span<TComponent4> component4Span,
		Span<TComponent5> component5Span,
		Span<TComponent6> component6Span,
		Span<TComponent7> component7Span,
		Span<TComponent8> component8Span
	);
}



public interface IQuery<
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
	void Execute(
		Span<TKey> e,
		Span<TComponent1> component1Span,
		Span<TComponent2> component2Span,
		Span<TComponent3> component3Span,
		Span<TComponent4> component4Span,
		Span<TComponent5> component5Span,
		Span<TComponent6> component6Span,
		Span<TComponent7> component7Span,
		Span<TComponent8> component8Span,
		Span<TComponent9> component9Span
	);
}
