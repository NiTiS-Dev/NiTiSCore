namespace NiTiS.Interaction;

public class OperationResult<T>
{
	private Result result;
	private T? item;
	public void SendResult(T item, Result result)
	{
		this.result = result;
		this.item = item;
	}
	public void SendResult(T item)
	{
		if (item == null)
		{
			result = Result.Error;
		}
		else
		{
			result = Result.Success;
			this.item = item;
		}
	}
	public OperationResult(T item)
	{
		if (item == null)
		{
			result = Result.Error;
		}
		else
		{
			result = Result.Success;
			this.item = item;
		}
	}
	public OperationResult()
	{
		result = Result.Error;
	}
	public T? Item => item;
	public Result Result => result;
}
