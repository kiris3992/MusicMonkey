using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace MusicMonkeyWebApp.Models.Paging
{
    public class PagingModel
    {
        public int PageIndex { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; private set; }
        public int PreviousPage { get; private set; }
        public int NextPage { get; private set; }
        public PagingModel() { }
        public PagingModel(int pageIndex, int itemsPerPage, int totalItems)
        {
            PageIndex = pageIndex <= 0 ? 0 : pageIndex;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = ItemsPerPage == 0 ? 0 : (int)Math.Ceiling((decimal)TotalItems / (decimal)ItemsPerPage);
            PreviousPage = PageIndex <= 1 ? 0 : PageIndex - 1;
            NextPage = PageIndex >= TotalPages - 1 ? TotalPages - 1 : PageIndex + 1;
            if (PageIndex > TotalPages - 1) PageIndex = TotalPages -1;
        }
    }
}
