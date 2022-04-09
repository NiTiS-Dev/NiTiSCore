using NiTiS.Additions;
using System.Collections.Generic;

namespace NiTiS.Interaction;

public class Digger<T>
{
	public T Item { get; }
	private readonly Dipper<T> dipper;
	private readonly Validator<T> validator;
	public Digger(T item, Dipper<T> dipper, Validator<T> validator)
	{
		Item = item;
		this.dipper = dipper;
		this.validator = validator;
	}
	public T GetLast()
	{
		T _cl = Item;
		while(validator(_cl))
		{
			_cl = dipper(_cl);
		}
		return _cl;
	}
	public IEnumerable<T> GetAll()
	{
		T _cl = Item;
		while (validator(_cl))
		{
			yield return _cl;
			_cl = dipper(_cl);
		}
	}
}
