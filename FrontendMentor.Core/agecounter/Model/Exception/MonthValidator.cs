namespace FrontendMentor.Core.agecounter.Model.Exception;

public class MonthValidator
{
	private readonly DateInfo _dateInfo;
	private readonly DateError _dateError;

	public MonthValidator(DateInfo dateInfo, DateError dateError)
	{
		_dateInfo = dateInfo;
		_dateError = dateError;
	}

	public void ValidateMonth()
	{
		if (!string.IsNullOrEmpty(_dateError.ErrorMonth))
			return;

		if (!int.TryParse(_dateInfo.Month, out int flagMonth) || flagMonth < 1 || flagMonth > 12)
		{
			_dateError.ErrorMonth = "Must be a valid month";
		}
		else
		{
			_dateError.ErrorMonth = string.Empty;
		}
	}
}