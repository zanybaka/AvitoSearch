using System;
using System.Collections.Generic;
using Avito.Model;

namespace Avito.UI.Interfaces
{
    public interface IMainForm
    {
        event EventHandler Search;
        event EventHandler SearchNext;
        event EventHandler LoadLayoutFromFile;
        event EventHandler FormLoaded;
        event EventHandler SaveLayoutAsFile;
        event EventHandler SaveLayoutToDefaultFile;
        event EventHandler ResetLayoutToDefault;
        event EventHandler SortBy;

        int PageCount { get; set; }
        int ResultCount { get; set; }
        bool CanSearchNext { get; set; }
        DateTime? SearchStartFrom { get; set; }

        void ApplyLayout(Layout layout);
        Layout GetLayout();
        void AddResultEntry(WebSearchResult newResult);
        object BeginSearching();
        void EndSearching(object state);
        void UpdateResults(IEnumerable<WebSearchResult> results);
        object BeginLoadingLayout();
        void EndLoadingLayout(object state);
        object BeginSorting();
        object BeginSavingLayout();
        void EndSavingLayout(object state);
        object BeginSearchingNext();
        void EndSearchingNext(object state);
    }
}