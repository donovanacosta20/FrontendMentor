namespace FrontendMentor.Core.agecounter.Model.Exception;

public class DayValidator
{
	private readonly DateInfo _dateInfo;
	private readonly DateError _dateError;

	public DayValidator(DateInfo dateInfo, DateError dateError)
	{
		_dateInfo = dateInfo;
		_dateError = dateError;
	}

	public void ValidateDay()
	{
		if (!string.IsNullOrEmpty(_dateError.ErrorDay))
			return;

		if (!int.TryParse(_dateInfo.Day, out int flagDay) || flagDay < 1 || flagDay > 31)
		{
			_dateError.ErrorDay = "Must be a valid day";
		}
		else
		{
			_dateError.ErrorDay = string.Empty;
		}
	}
}
