using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Morocco public holidays
    /// Source : https://fr.wikipedia.org/wiki/F%C3%AAtes_et_jours_f%C3%A9ri%C3%A9s_au_Maroc
    /// </summary>
    public class MoroccoPublicHoliday : PublicHolidayBase
    {

        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1
        /// </summary>
        /// <param name="year"></param>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Proclamation of independence Day January 11
        /// </summary>
        /// <param name="year"></param>
        public static DateTime ProclamationOfIndependenceDay(int year)
        {
            return new DateTime(year, 1, 11);
        }

        /// <summary>
        /// Amazigh New Year January 14
        /// </summary>
        /// <param name="year"></param>
        public static DateTime AmazighNewYear(int year)
        {
            return new DateTime(year, 1, 14);
        }

        /// <summary>
        /// Labour Day - May 1
        /// </summary>
        /// <param name="year"></param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Throne Day - July 30
        /// </summary>
        /// <param name="year"></param>
        public static DateTime ThroneDay(int year)
        {
            return new DateTime(year, 7, 30);
        }

        /// <summary>
        /// Oued Ed-Dahab Day - August 14
        /// </summary>
        /// <param name="year"></param>
        public static DateTime OuedEdDahabDay(int year)
        {
            return new DateTime(year, 8, 14);
        }

        /// <summary>
        /// Revolution Day - August 20
        /// </summary>
        /// <param name="year"></param>
        public static DateTime RevolutionDay(int year)
        {
            return new DateTime(year, 8, 20);
        }

        /// <summary>
        /// Youth Day - August 21
        /// </summary>
        /// <param name="year"></param>
        /// <remarks>King Mohammed VI birthday</remarks>
        public static DateTime YouthDay(int year)
        {
            return new DateTime(year, 8, 21);
        }

        /// <summary>
        /// Unity Day - October 31
        /// </summary>
        /// <param name="year"></param>
        public static DateTime UnityDay(int year)
        {
            return new DateTime(year, 10, 31);
        }

        /// <summary>
        /// Green March Day - November 6
        /// </summary>
        /// <param name="year"></param>
        public static DateTime GreenMarchDay(int year)
        {
            return new DateTime(year, 11, 6);
        }

        /// <summary>
        /// Independence Day - November 18
        /// </summary>
        /// <param name="year"></param>
        public static DateTime IndependenceDay(int year)
        {
            return new DateTime(year, 11, 18);
        }

        /// <summary>
        /// Islamic New Year - Muharram 1
        /// </summary>
        /// <param name="hijriCalendar"></param>
        /// <param name="hijriYear"></param>
        private static DateTime IslamicNewYear(HijriCalendar hijriCalendar, int hijriYear)
        {
            return hijriCalendar.ToDateTime(hijriYear, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Prophet's Birthday - Rabi' al-awwal 12
        /// </summary>
        /// <param name="hijriCalendar"></param>
        /// <param name="hijriYear"></param>
        private static DateTime ProphetBirthday(HijriCalendar hijriCalendar, int hijriYear)
        {
            return hijriCalendar.ToDateTime(hijriYear, 3, 12, 0, 0, 0, 0);
        }

        /// <summary>
        /// Eid al-Fitr - Shawwal 1
        /// </summary>
        /// <param name="hijriCalendar"></param>
        /// <param name="hijriYear"></param>
        private static DateTime EidAlFitr(HijriCalendar hijriCalendar, int hijriYear)
        {
            return hijriCalendar.ToDateTime(hijriYear, 10, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Eid al-Adha - Dhu al-Hijjah 10
        /// </summary>
        /// <param name="hijriCalendar"></param>
        /// <param name="hijriYear"></param>
        private static DateTime EidAlAdha(HijriCalendar hijriCalendar, int hijriYear)
        {
            return hijriCalendar.ToDateTime(hijriYear, 12, 10, 0, 0, 0, 0);
        }

        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).
                Select(x => x.Key).
                OrderBy(x => x).
                ToList();
        }

        /// <summary>
        /// Public holiday names
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {

            var bHols = new Dictionary<DateTime, string> {
                {
                    NewYear(year), "New Year"
                },
                {
                    ProclamationOfIndependenceDay(year), "Proclamation of Independence Day"
                },
                {
                    AmazighNewYear(year), "Amazigh New Year"
                },
                {
                    LabourDay(year), "Labour Day"
                },
                {
                    ThroneDay(year), "Throne Day"
                },
                {
                    OuedEdDahabDay(year), "Oued Ed-Dahab Day"
                },
                {
                    RevolutionDay(year), "Revolution Day"
                },
                {
                    YouthDay(year), "Youth Day"
                },
                {
                    UnityDay(year), "Unity Day"
                },
                {
                    GreenMarchDay(year), "Green March Day"
                },
                {
                    IndependenceDay(year), "Independence Day"
                }
            };

            var hijriCalendar = new HijriCalendar();

            var gregorianYearStart = new DateTime(year, 1, 1);
            var gregorianYearEnd = new DateTime(year, 12, 31);

            for (var hijriYear = hijriCalendar.GetYear(gregorianYearStart); hijriYear <= hijriCalendar.GetYear(gregorianYearEnd); hijriYear++)
            {
                AddIslamicHoliday(bHols, IslamicNewYear(hijriCalendar, hijriYear), "Islamic New Year", year);
                AddIslamicHoliday(bHols, ProphetBirthday(hijriCalendar, hijriYear), "Prophet's Birthday", year);
                AddIslamicHoliday(bHols, EidAlFitr(hijriCalendar, hijriYear), "Eid al-Fitr", year);
                AddIslamicHoliday(bHols, EidAlAdha(hijriCalendar, hijriYear), "Eid al-Adha", year);
            }

            return bHols;

        }

        private static void AddIslamicHoliday(Dictionary<DateTime, string> holidays, DateTime date, string name, int gregorianYear)
        {
            if (date.Year == gregorianYear)
            {
                holidays.Add(date, name);
            }
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// Note holidays can fall on weekends and there is no fixed moving of such dates.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            return PublicHolidays(dt.Year).Contains(dt.Date);
        }

        /// <summary>
        /// Gets the list of all public holidays
        /// </summary>
        /// <param name="year">The given year</param>
        /// <returns></returns>
        public override IList<Holiday> PublicHolidaysInformation(int year)
        {
            return PublicHolidayNames(year).Select(kvp => new Holiday(kvp.Key, kvp.Value)).ToList();
        }

    }
}
