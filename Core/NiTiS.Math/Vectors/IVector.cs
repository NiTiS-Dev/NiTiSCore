namespace NiTiS.Math.Vectors;

/// <summary>
/// Specifies that the object is a vector
/// </summary>
public interface IVector
{
	/// <summary>
	/// Returns the length of the vector. If you want to compare the length of several vectors use <see cref="LengthSquared">the squared length </see>
	/// </summary>
	double Length { get; }
	/// <summary>
	/// Returns the length of a vector squared, use to compare the lengths of vectors
	/// </summary>
	double LengthSquared { get; }
	/// <summary>
	/// Normalizes the vector. The length of the vector becomes equal to 1 and the vector retains its direction
	/// </summary>
	void Normalize();
}
/// <summary>
/// Interface for creating vectors
/// </summary>
/// <typeparam name="T">Determines how the vector is measured</typeparam>
public interface IVector<T> : IVector
{
	/// <summary>
	/// Returns the value along the specified axis. Returns zero if the axis does not exist
	/// </summary>
	/// <param name="axis">The coordinate axis along which you get the value</param>
	/// <returns></returns>
	T GetValueByDimension(Axis axis);
}