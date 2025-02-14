namespace FrontendMentor.Application.Agecounter;

public static class AgeCounterLogic
{
	private static readonly DateTime _today = DateTime.Now;
	public static DateTime Birth { get; set;}
	public static int CheckDays()
	{
		if (Birth.Day == _today.Day && Birth.Month == _today.Month)
		{
			return 0;
		}

		const int daysOfMonth = 31;

		if (Birth.Day > _today.Day && (Birth.Month >= _today.Month || Birth.Month < _today.Month))
		{
			return daysOfMonth - (Birth.Day - _today.Day);
		}

		return _today.Day - Birth.Day;
	}

	public static int CheckMonths()
	{
		const int monthsOfYear = 12;
		
		if (Birth.Day > _today.Day)
		{
			return (_today.Month - Birth.Month - 1 + monthsOfYear) % monthsOfYear;
		}
	
		return (_today.Month - Birth.Month + monthsOfYear) % monthsOfYear;
		
	}

	public static int CheckYears()
	{
		if(_today.Month > Birth.Month || (_today.Month == Birth.Month && _today.Day >= Birth.Day)) {
			return (_today.Year - Birth.Year);
		}


		return (_today.Year - Birth.Year) - 1;
	}
}
