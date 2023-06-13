using System;

public class MinMaxIntAttribute : Attribute
{
	public MinMaxIntAttribute(int min, int max)
	{
		Min = min;
		Max = max;
	}
	public int Min { get; private set; }
	public int Max { get; private set; }
}