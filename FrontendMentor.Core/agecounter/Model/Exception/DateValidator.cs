namespace FrontendMentor.Core.agecounter.Model.Exception;

public class DateValidator
{
	private readonly DateInfo _dateInfo;
	private readonly DateError _dateError;

	public DateValidator(DateInfo dateInfo, DateError dateError)
	{
		_dateInfo = dateInfo;
		_dateError = dateError;
	}


	public void ValidateRightDate()
	{
		if (string.IsNullOrEmpty(_dateInfo.Day) || string.IsNullOrEmpty(_dateInfo.Month) || string.IsNullOrEmpty(_dateInfo.Year)
			|| !string.IsNullOrEmpty(_dateError.ErrorDay) || !string.IsNullOrEmpty(_dateError.ErrorMonth) || !string.IsNullOrEmpty(_dateError.ErrorYear))
		{
			return;
		}

		if (!int.TryParse(_dateInfo.Year, out int flagYear) || !int.TryParse(_dateInfo.Month, out int flagMonth)
			|| !int.TryParse(_dateInfo.Day, out int flagDay))
		{
			_dateError.ErrorDay = "Must be a valid date";
			return;
		}

		int flagDate = DateTime.DaysInMonth(flagYear, flagMonth);
		if (flagDay > flagDate)
		{
			_dateError.ErrorDay = "Must be a valid date";
		}
		else
		{
			_dateError.ErrorDay = string.Empty;
		}
	}
}
