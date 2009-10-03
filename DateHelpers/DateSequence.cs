using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LinqToDateTime
{

  public class DateSequence : IEnumerable<DateTime>
  {
    protected DateTime start;
    protected TimeSpan range;

    public static DateSequence FromYears(int fromYear, int toYear)
    {
      if (toYear < fromYear)
      {
        throw new ArgumentException("The To year must be larger than the From year");
      }
      DateTime start = new DateTime(fromYear, 1, 1);
      DateTime end = new DateTime(toYear, 1, 1);
      return new DateSequence(start, end - start);
    }

    public static SingleYearSequence FromYear(int year)
    {
      return SingleYearSequence.Create(year);
    }

    public static DateSequence FromDates(DateTime from, DateTime to)
    {
      if (to < from)
      {
        throw new ArgumentException("The To date must be larger than the From date");
      }
      return new DateSequence(from, to - from);
    }

    public DateSequence(DateTime dt, TimeSpan ts)
    {
      this.start = dt;
      this.range = ts;
    }

    public IEnumerator<DateTime> GetEnumerator()
    {
      DateTime newDate = start;
      for (int day = 0; newDate < start + range; day++, newDate = start.AddDays(day))
      {
        yield return newDate;
      }
    }

    IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      yield return new DateTime();
    }

    public IEnumerable<DateTime> AsDays()
    {
      DateTime newDate = start;
      for (int day = 0; newDate < start + range; day++, newDate = start.AddDays(day))
      {
        yield return newDate;
      }
    }

    public IEnumerable<DateTime> AsYears()
    {
      DateTime newDate = start;
      for (int year = 0; newDate < start + range; year++, newDate = start.AddYears(year))
      {
        yield return newDate;
      }
    }

    public IEnumerable<DateTime> AsHours()
    {
      DateTime newDate = start;
      for (int hour = 0; newDate < start + range; hour++, newDate = start.AddHours(hour))
      {
        yield return newDate;
      }
    }

    public IEnumerable<DateTime> AsMinutes()
    {
      DateTime newDate = start;
      for (int minute = 0; newDate < start + range; minute++, newDate = start.AddMinutes(minute))
      {
        yield return newDate;
      }
    }

    public IEnumerable<DateTime> AsSeconds()
    {
      DateTime newDate = start;
      for (int second = 0; newDate < start + range; second++, newDate = start.AddSeconds(second))
      {
        yield return newDate;
      }
    }

    public IEnumerable<DateTime> AsMilliseconds()
    {
      DateTime newDate = start;
      for (int msecond = 0; newDate < start + range; msecond++, newDate = start.AddMilliseconds(msecond))
      {
        yield return newDate;
      }
    }

    public IEnumerable<DateTime> AsTicks()
    {
      DateTime newDate = start;
      for (int tick = 0; newDate < start + range; tick++, newDate = start.AddTicks(tick))
      {
        yield return newDate;
      }
    }
  }

}
