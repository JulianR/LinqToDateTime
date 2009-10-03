using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToDateTime
{
  public class SingleYearSequence : DateSequence
  {

    public SingleYearSequence(DateTime dt, TimeSpan ts)
      : base(dt, ts)
    {
    }

    public static SingleYearSequence Create(int year)
    {
      DateTime start = new DateTime(year, 1, 1);
      return new SingleYearSequence(start, start.AddYears(1) - start);
    }

    public DateSequence January() { return ToMonth(Month.January); }
    public DateSequence February() { return ToMonth(Month.February); }
    public DateSequence March() { return ToMonth(Month.March); }
    public DateSequence April() { return ToMonth(Month.April); }
    public DateSequence May() { return ToMonth(Month.May); }
    public DateSequence June() { return ToMonth(Month.June); }
    public DateSequence July() { return ToMonth(Month.July); }
    public DateSequence August() { return ToMonth(Month.August); }
    public DateSequence September() { return ToMonth(Month.September); }
    public DateSequence October() { return ToMonth(Month.October); }
    public DateSequence November() { return ToMonth(Month.November); }
    public DateSequence December() { return ToMonth(Month.December); }

    public IEnumerable<DateTime> AsWeeks()
    {

      DateTime januaryFourth = new DateTime(start.Year, 1, 4);

      int correction = januaryFourth.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)januaryFourth.DayOfWeek;

      int ordinalDay = (7 + (int)DayOfWeek.Thursday) - (correction + 3);

      DateTime firstMonday = new DateTime(start.Year, 1, ordinalDay).AddDays(-3);

      DateTime newDate = firstMonday;
      for (int week = 0; week < 52; week++, newDate = newDate.AddDays(7))
      {
        yield return newDate;
      }

    }

    public DateSequence ToMonth(Month month)
    {
      DateTime newStart = new DateTime(start.Year, (int)month, 1);
      DateTime end;

      if (month == Month.December)
        end = new DateTime(start.Year + 1, (int)Month.January, 1);
      else
        end = new DateTime(start.Year, (int)month + 1, 1);

      return new DateSequence(newStart, end - newStart);
    }
  }
}
