namespace FrontendMentor.Core.agecounter.Model.Exception;

public class YearValidator
{
	private readonly DateInfo _dateInfo;
	private readonly DateError _dateError;

	public YearValidator(DateInfo dateInfo, DateError dateError)
	{
		_dateInfo = dateInfo;
		_dateError = dateError;
	}
	public void ValidateYear(DateTime today)
	{
		if (string.IsNullOrEmpty(_dateInfo.Year))
			return;

		if (!int.TryParse(_dateInfo.Year, out int flagYear) || flagYear > today.Year)
		{
			_dateError.ErrorYear = "Must be in the past";
		}
		else
		{
			_dateError.ErrorYear = string.Empty;
		}
	}

	public void ValidateYear(DateTime today, DateTime birth)
	{
		if (birth > today)
		{
			_dateError.ErrorYear = "Must be in the past";
		}
		else
		{
			_dateError.ErrorYear = string.Empty;
		}
	}
}
