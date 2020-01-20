using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nortwind.MVCWebUI.Models;
using System.Text;

namespace Nortwind.MVCWebUI.HtmlHelpers
{
    public static class PagingHelpers
    //helper methodu statictir.
    {
        //Extension metho: .Net içerisinde bulunan sınıflara yeni özellikler eklememize olanak sağlar. Net 3.0 ile gelen bir özelliktir.
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo)
        {
            //<a href ="">1</a> 
            int totalPage = (int)Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);//sayfa sayısı
            //bir tane bile eleman artsa bu yeni bir eleman demektir. Bu yüzden Math.Ceiling işlemi yapmamız gerekir

            var stringBuilder = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {
                var tagBuilder = new TagBuilder("a");//önce a tagini oluştur
                tagBuilder.MergeAttribute("href", String.Format("/Product/Index/?page={0}&category={1}", i, pagingInfo.CurrentCategory));//a tagi içerisine verilecek linki oluştur
                tagBuilder.InnerHtml = i.ToString();//inner html görünen 1,2,3... değeri
                if (pagingInfo.CurrentPage == i) 
                {
                    tagBuilder.AddCssClass("selected");
                }
                stringBuilder.Append(tagBuilder);

            }
            return MvcHtmlString.Create(stringBuilder.ToString());

        }
    }
}