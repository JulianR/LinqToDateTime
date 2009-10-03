using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LinqToDateTime
{
  class Program
  {
    static void Main(string[] args)
    {

      /*
       *    1. Find the 1st Tuesday of June 2012
            2. Find the last Friday of March 2008
            3. Find every Saturday in January 2013
            4. Find the 3rd Friday in July 2009
            5. Find every Saturday over the next 3 months
            6. Find every day in March 2018
      */

      var lastTueday = (from d in DateSequence.FromYear(2012).June()
                        where d.DayOfWeek == DayOfWeek.Tuesday
                        select d).First();

      var lastFriday = (from d in DateSequence.FromYear(2008).March()
                        where d.DayOfWeek == DayOfWeek.Friday
                        select d).Last();

      var saturdays = (from d in DateSequence.FromYear(2013).January()
                       where d.DayOfWeek == DayOfWeek.Saturday
                       select d);

      var nextSaturdays = (from d in DateSequence.FromDates(DateTime.Today, DateTime.Today.AddMonths(3))
                           where d.DayOfWeek == DayOfWeek.Saturday
                           select d);

      var allDays = (from d in DateSequence.FromYear(2018).March()
                     select d);

      foreach (var d in nextSaturdays) Console.WriteLine(d.Date);


    }
  }

  public enum Month
  {
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    September = 9,
    October = 10,
    November = 11,
    December = 12
  }



  public static class DateTimeExtensions
  {
    public static int GetWeekNumber(this DateTime dt)
    {
      /*
      * Example: Friday, September 26, 2008
      * Ordinal day: 244 + 26 = 270
      * Weekday: Friday = 5
      * 270 - 5 + 10 = 275
      * 275 / 7 = 39 plus an irrelevant fraction
      * Result: Week 39 */
      return (dt.DayOfYear - (dt.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)dt.DayOfWeek) + 10) / 7;

    }

  }
}
