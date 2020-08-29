using System;
using System.Globalization;
using System.Linq;
using Shared.Utils.Lib.Entities.Number;
using Shared.Utils.Lib.Entities.String;
using Shared.Utils.Lib.Utils;

namespace Avito.Search
{
    public class AvitoParser
    {
        internal static int? GetPriceValue(string nodeText)
        {
            return new NullableInteger(
                new ReplaceText(
                    new ReplaceText(
                        new ReplaceText(
                            new TrimText(nodeText),
                            "₽", ""),
                        "&nbsp;", ""),
                    " ", ""));
        }

        internal static string GetTitleValue(string nodeText)
        {
            return new TrimText(nodeText);
        }

        internal static string GetCategoryValue(string nodeText)
        {
            return new TrimText(nodeText);
        }

        internal static string GetAddressValue(string nodeText)
        {
            return new TrimText(nodeText);
        }

        internal static DateTime? GetDateValue(string nodeText, DateTime today, DateTime now)
        {
            string absoluteDate = new TrimText(nodeText);
            string[] parts = absoluteDate.Split(' ');
            DateTime date;
            if (absoluteDate.StartsWith("Сегодня"))
            {
                date = today.Date;
            }
            else if (absoluteDate.StartsWith("Вчера"))
            {
                date = today.Date.AddDays(-1);
            }
            else if (absoluteDate.Contains(" час ") || absoluteDate.Contains(" часа ") || absoluteDate.Contains(" часов "))
            {
                date = now.AddHours(-int.Parse(parts[0]));
                return date;
            }
            else if (absoluteDate.Contains(" минута ") || absoluteDate.Contains(" минуты ") || absoluteDate.Contains(" минут ") || absoluteDate.Contains(" минуту "))
            {
                date = now.AddMinutes(-int.Parse(parts[0]));
                return date;
            }
            else if (absoluteDate.Contains(" день ") || absoluteDate.Contains(" дня ") || absoluteDate.Contains(" дней "))
            {
                date = now.AddDays(-int.Parse(parts[0]));
                return date;
            }
            else if (absoluteDate.Contains(" неделя ") || absoluteDate.Contains(" недель ") || absoluteDate.Contains(" недели ") || absoluteDate.Contains(" неделю "))
            {
                date = now.AddDays(-int.Parse(parts[0]) * 7);
                return date;
            }
            else if (absoluteDate.Contains(" год ") || absoluteDate.Contains(" года ") || absoluteDate.Contains(" лет "))
            {
                date = now.AddYears(-int.Parse(parts[0]));
                return date;
            }
            else
            {
                CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                try
                {
                    date = DateTime.ParseExact(absoluteDate, "dd MMM.", cultureInfo);
                }
                catch (FormatException)
                {
                    try
                    {
                        date = DateTime.ParseExact(absoluteDate, "dd MMM", cultureInfo);
                    }
                    catch (FormatException)
                    {
                        try
                        {
                            string day = int.Parse(parts[0]).ToString("00");
                            string month = parts[1].Substring(0, 3);
                            date = DateTime.ParseExact(day + ' ' + month, "dd MMM", cultureInfo);
                        }
                        catch (FormatException)
                        {
                            Log.Error($"Can't parse date time {absoluteDate}.");
                            return null;
                        }
                    }
                }
            }

            string[] strings = parts.Last().Split(':');
            DateTime value = date
                .AddHours(int.Parse(strings[0]))
                .AddMinutes(int.Parse(strings[1]));
            return value;
        }
    }
}