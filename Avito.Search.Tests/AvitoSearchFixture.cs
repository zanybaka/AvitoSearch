using System;
using System.Collections.Generic;
using Avito.Model;
using FluentAssertions;
using NUnit.Framework;

namespace Avito.Search.Tests
{
    [TestFixture]
    public class AvitoSearchFixture
    {
        private AvitoSettings _settings;

        [SetUp]
        public void Setup()
        {
            _settings = new AvitoSettings();
        }

        [Test]
        public void AvitoPageRequestTest()
        {
            var request = new AvitoPageRequest(_settings, "apple", searchInTitlesOnly: true);
            string url = request.GetUrl();
            url.Should().NotBeNullOrEmpty();
            url.Length.Should().BeGreaterThan(10);
        }

        [Test]
        public void AvitoPageCountTest()
        {
            var request = new AvitoPageRequest(_settings, "apple", searchInTitlesOnly: true);
            var page = new AvitoPage(_settings, request);
            page.Info().PageCount.Should().BeGreaterThan(1);
        }

        [Test]
        public void AvitoPageTest()
        {
            var settings = new AvitoSettings();
            var request = new AvitoPageRequest(settings, "apple watch", searchInTitlesOnly: true);
            var page = new AvitoPage(settings, request);
            Filter filter = new Filter
            {
                TitleContains = new[] { "apple", "watch" },
                TitleDoesNotContain = new[] { "46m" },
                DatesAfter = DateTime.Now.AddDays(-5),
                MaxPrice = 20000,
                MinPrice = 10000
            };
            List<WebSearchResult> results = page.GetResults(filter);
            results.Count.Should().BeGreaterThan(0);
        }
    }
}
