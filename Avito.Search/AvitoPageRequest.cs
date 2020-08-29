using Shared.Utils.Lib.Entities.If;
using Shared.Utils.Lib.Entities.String;

namespace Avito.Search
{
    public class AvitoPageRequest
    {
        private readonly AvitoSettings _settings;
        private readonly int _pageNumber;
        private readonly string _searchText;
        private readonly bool _searchInTitlesOnly;

        public AvitoPageRequest(AvitoSettings settings, int pageNumber, string searchText, bool searchInTitlesOnly = true)
        {
            _settings = settings;
            this._pageNumber = pageNumber;
            this._searchText = searchText;
            this._searchInTitlesOnly = searchInTitlesOnly;
        }

        public AvitoPageRequest(AvitoSettings settings, string searchText, bool searchInTitlesOnly = true)
        : this (settings, -1, searchText, searchInTitlesOnly)
        {
        }

        public string GetUrl()
        {
            string textToSearch = new ReplaceChar(_searchText, ' ', '+');
            Iif<int> searchIntTitleOnlyIf = new Iif<int>(() => _searchInTitlesOnly, 1, 0);
            string url =
                new Iif<string>(
                    () => _pageNumber == -1,
                    new FormatString(
                        _settings.UrlFormat,
                        textToSearch,
                        searchIntTitleOnlyIf),
                    new FormatString(
                        _settings.PageUrlFormat,
                        _pageNumber,
                        textToSearch,
                        searchIntTitleOnlyIf));
            return url;
        } 
    }
}