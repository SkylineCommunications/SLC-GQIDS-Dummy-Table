using Skyline.DataMiner.Analytics.GenericInterface;

public class Arguments
{
	private readonly GQIIntArgument _numColumnsArg = new GQIIntArgument("Number of Columns") { DefaultValue = 1 };
	private readonly GQIIntArgument _numRowsArg = new GQIIntArgument("Number of Rows") { DefaultValue = 1 };

	public int NumberOfColumns { get; private set; }

	public int NumberOfRows { get; private set; }

	public GQIArgument[] GetArguments()
	{
		return new GQIArgument[]
		{
			_numColumnsArg,
			_numRowsArg,
		};
	}

	public void ProcessArguments(OnArgumentsProcessedInputArgs args)
	{
		NumberOfColumns = args.GetArgumentValue(_numColumnsArg);
		NumberOfRows = args.GetArgumentValue(_numRowsArg);
	}
}
