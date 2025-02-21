namespace FrontendMentor.Core.agecounter.Application;

public static class CalculateAge
{
	public static DateTime Today { get; private set; } = DateTime.Now;
	public static DateTime Birth { get; set; }
	public static int CheckDays()
	{
		if (Birth.Day == Today.Day && Birth.Month == Today.Month)
		{
			return 0;
		}

		const int daysOfMonth = 31;

		if (Birth.Day > Today.Day && (Birth.Month >= Today.Month || Birth.Month < Today.Month))
		{
			return daysOfMonth - (Birth.Day - Today.Day);
		}

		return Today.Day - Birth.Day;
	}

	public static int CheckMonths()
	{
		const int monthsOfYear = 12;

		if (Birth.Day > Today.Day)
		{
			return (Today.Month - Birth.Month - 1 + monthsOfYear) % monthsOfYear;
		}

		return (Today.Month - Birth.Month + monthsOfYear) % monthsOfYear;

	}

	public static int CheckYears()
	{
		if (Today.Month > Birth.Month || (Today.Month == Birth.Month && Today.Day >= Birth.Day))
		{
			return (Today.Year - Birth.Year);
		}


		return (Today.Year - Birth.Year) - 1;
	}
}
