namespace wypozyczalnia;

public interface IExtraFeeCalucatorStrategy
{
    decimal CalculateExtraFee(Rental rental);
}

public class FlatRatePerDayFeeCalculatorStrategy : IExtraFeeCalucatorStrategy
{
    private static decimal FEE_PER_DAY = 50;
    
    public decimal CalculateExtraFee(Rental rental)
    {
        if (rental.ActualReturnDate == null) return 0;
        DateOnly currentDate = DateOnly.FromDateTime((DateTime)rental.ActualReturnDate);
        int delayDays = currentDate.DayNumber - rental.PlannedReturnedDate.DayNumber;
        if (delayDays > 0) return delayDays * FEE_PER_DAY;
        return 0;
    }
}