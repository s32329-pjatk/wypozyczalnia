DateOnly from = new(2020, 1, 1);
DateOnly to   = new(2026, 3, 28);

int days = to.DayNumber - from.DayNumber;

Console.WriteLine(days);