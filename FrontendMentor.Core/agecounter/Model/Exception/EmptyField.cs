namespace FrontendMentor.Core.agecounter.Model.Exception;

public class EmptyField 
{
	private readonly DateInfo _dateInfo;
	private readonly DateError _dateError;

	public EmptyField(DateInfo dateInfo, DateError dateError)
	{
		_dateInfo = dateInfo;
		_dateError = dateError;
	}

	private bool IsEmptyField(string fieldName)
	{
		return string.IsNullOrEmpty(fieldName);
	}

	public void ValidateEmptyField()
	{
		_dateError.ErrorDay = IsEmptyField(_dateInfo.Day) ? "This field is required" : "";
		_dateError.ErrorMonth = IsEmptyField(_dateInfo.Month) ? "This field is required" : "";
		_dateError.ErrorYear = IsEmptyField(_dateInfo.Year) ? "This field is required" : "";
	}
}
