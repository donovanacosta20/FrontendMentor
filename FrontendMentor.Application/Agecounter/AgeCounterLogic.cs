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
		if ((Birth.Day > _today.Day && Birth.Month < _today.Month) || (Birth.Day <= _today.Day && Birth.Month == _today.Month))
		{
			return 0;
		}

		const int monthsOfYear = 12;

		if (Birth.Day >= _today.Day && Birth.Month >= _today.Month)
		{
			return monthsOfYear - (Birth.Month - _today.Month) - 1;
		}

		if (Birth.Day <= _today.Day && Birth.Month > _today.Month)
		{
			return (monthsOfYear + _today.Month) - Birth.Month;
		}

		return Birth.Month;
	}

	public static int CheckYears()
	{
		if (_today.Day < Birth.Day && _today.Month <= Birth.Month)
		{
			return (_today.Year - Birth.Year) - 1;
		}

		return (_today.Year - Birth.Year);
	}
}
