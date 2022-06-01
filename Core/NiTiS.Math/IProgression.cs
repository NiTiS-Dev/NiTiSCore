using System;
using System.Collections.Generic;

namespace NiTiS.Math;

public interface IProgression<T>
{
	/// <summary>
	/// First element of progression
	/// </summary>
	public T First { get; set; }
	/// <summary>
	/// Get element of progression by <paramref name="index"/>
	/// </summary>
	/// <param name="index">Element index</param>
	public T Get(int index);
	/// <summary>
	/// Returns sum of the all element from one to <paramref name="endIndex"/>
	/// </summary>
	/// <param name="endIndex">Index of last element in range</param>
	public T Sum(int endIndex);
	public IEnumerable<T> SumArray(int count);
	public IEnumerable<T> SumArray(int startIndex, int endIndex);
	public IEnumerable<T> SumArray(Predicate<T> predicate);
}