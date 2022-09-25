namespace BooksPenalty.PenaltyCalculatorLibrary.ApiResponse;

public class GetConvertDto
{
	public string date { get; set; }
	public Info info { get; set; }
	public Query query { get; set; }
	public decimal result { get; set; }
	public bool success { get; set; }
}

public class Info
{
	public double rate { get; set; }
	public int timestamp { get; set; }
}

public class Query
{
	public int amount { get; set; }
	public string from { get; set; }
	public string to { get; set; }
}


