using System;
using System.Collections.Generic;

namespace NiTiS.Math;

public interface IProgression : IProgression<double>
{

}
public interface IProgression<T>
{
	public T First { get; set; }
	public T Get(int index);
	public T Sum(int endIndex);
	public IEnumerable<T> SumArray(int count);

	public IEnumerable<T> SumArray(int startIndex, int endIndex);
	public IEnumerable<T> SumArray(Predicate<T> predicate);
}