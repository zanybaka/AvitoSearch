using System;
using FluentAssertions;
using NUnit.Framework;

namespace Avito.Search.Tests
{
    [TestFixture]
    public class AvitoParserFixture
    {
        [Test]
        public void YesterdayTest()
        {
            var result = AvitoParser.GetDateValue(
                "Вчера 19:34",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 8, 19, 34, 0));
        }

        [Test]
        public void TodayTest()
        {
            var result = AvitoParser.GetDateValue(
                "Сегодня 19:34",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 9, 19, 34, 0));
        }

        [Test]
        public void OneHourBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "1 час назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 9, 17, 1, 2));
        }

        [Test]
        public void TwoHourBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "2 часа назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 9, 16, 1, 2));
        }

        [Test]
        public void TwentyHoursBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "20 часов назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 8, 22, 1, 2));
        }

        [Test]
        public void OneDayBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "1 день назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 8, 18, 1, 2));
        }

        [Test]
        public void TwoDaysBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "2 дня назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 7, 18, 1, 2));
        }

        [Test]
        public void FiveDaysBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "5 дней назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 4, 18, 1, 2));
        }

        [Test]
        public void OneWeekBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "1 неделя назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 2, 18, 1, 2));
        }

        [Test]
        public void TwoWeeksBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "2 недели назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 1, 26, 18, 1, 2));
        }

        [Test]
        public void FiveWeeksBeforeTest()
        {
            var result = AvitoParser.GetDateValue(
                "5 недель назад",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 1, 5, 18, 1, 2));
        }

        [Test]
        public void DateTest()
        {
            var result = AvitoParser.GetDateValue(
                "6 февраля 19:34",
                new DateTime(2020, 2, 9, 18, 0, 0),
                new DateTime(2020, 2, 9, 18, 1, 2));
            result.Should().Be(new DateTime(2020, 2, 6, 19, 34, 0));
        }
    }
}
