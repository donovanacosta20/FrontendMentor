using FrontendMentor.Core.agecounter.Model;
using FrontendMentor.Core.agecounter.Model.Exception;

namespace FrontendMentor.Core.agecounter.Application;

public class AgeCounterHandle
{
	private readonly EmptyField _emptyField;
	private readonly DayValidator _dayValidator;
	private readonly MonthValidator _monthValidator;
	private readonly DateValidator _dateValidator;
	private readonly YearValidator _yearValidator;
	public DateInfo DateInfo { get; init ; }
	public DateError DateError { get; init ; }

	public AgeCounterHandle()
	{
		DateInfo = new DateInfo();
		DateError = new DateError();
		
		_emptyField = new EmptyField(DateInfo, DateError);
		_dayValidator = new DayValidator(DateInfo, DateError);
		_monthValidator = new MonthValidator(DateInfo, DateError);
		_dateValidator = new DateValidator(DateInfo, DateError);
		_yearValidator = new YearValidator(DateInfo, DateError);
	}

	private bool IsAnyError() {
		return string.IsNullOrEmpty(DateError.ErrorDay) && string.IsNullOrEmpty(DateError.ErrorMonth) && string.IsNullOrEmpty(DateError.ErrorYear);
	}

	private bool IsAnyEmpty() {
		return string.IsNullOrEmpty(DateInfo.Day) && string.IsNullOrEmpty(DateInfo.Month) && string.IsNullOrEmpty(DateInfo.Year);
	}


	public void HandleResult() {
		_emptyField.ValidateEmptyField();
		_dayValidator.ValidateDay();
		_monthValidator.ValidateMonth();
		_yearValidator.ValidateYear(CalculateAge.Today);
		_dateValidator.ValidateRightDate();


		if (IsAnyError() && !IsAnyEmpty())
		{
			CalculateAge.Birth = new DateTime(Convert.ToInt16(DateInfo.Year), Convert.ToInt16(DateInfo.Month), Convert.ToInt16(DateInfo.Day));
			_yearValidator.ValidateYear(CalculateAge.Today, CalculateAge.Birth);
		}

		if (IsAnyError())
		{
			DateInfo.DayResult = CalculateAge.CheckDays().ToString();
			DateInfo.MonthResult = CalculateAge.CheckMonths().ToString();
			DateInfo.YearResult = CalculateAge.CheckYears().ToString();

			return;
		}

		DateInfo.DayResult = "--";
		DateInfo.MonthResult = "--";
		DateInfo.YearResult = "--";
	}
}
