using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "GQI_Dummy-Table")]
public class MyDataSource : IGQIDataSource, IGQIInputArguments
{
	private readonly Arguments _arguments = new Arguments();

	public GQIArgument[] GetInputArguments()
	{
		return _arguments.GetArguments();
	}

	public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
	{
		_arguments.ProcessArguments(args);
		return new OnArgumentsProcessedOutputArgs();
	}

	public GQIColumn[] GetColumns()
	{
		var numColumns = _arguments.NumberOfColumns;

		var columns = new GQIColumn[numColumns];

		for (int i = 0; i < numColumns; i++)
		{
			columns[i] = new GQIStringColumn($"Column {i + 1}");
		}

		return columns;
	}

	public GQIPage GetNextPage(GetNextPageInputArgs args)
	{
		var numColumns = _arguments.NumberOfColumns;
		var numRows = _arguments.NumberOfRows;

		var rows = new GQIRow[numRows];

		for (int row = 0; row < numRows; row++)
		{
			var key = $"Row {row + 1}";
			var cells = new GQICell[numColumns];

			for (int col = 0; col < numColumns; col++)
			{
				cells[col] = new GQICell();
			}

			rows[row] = new GQIRow(key, cells);
		}

		return new GQIPage(rows)
		{
			HasNextPage = false,
		};
	}
}