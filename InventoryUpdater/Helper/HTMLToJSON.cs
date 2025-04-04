﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using SellerSense.Model;
using SellerSense.Model.Interfaces;

namespace SellerSense.Helper
{
    public static class HTMLToJSON
    {
        //public class BaseMap
        //{
        //    public string ImageURL { get; set; }
        //    public string Code { get; set; }
        //    public string Price { get; set; }

        //    public BaseMap(string img, string code, string price)
        //    {
        //        ImageURL = img;
        //        Code = code;
        //        Price = price;
        //    }
        //}


        public static string EscJSONChar(string html)
        {
            string text= HtmlUtilities.ConvertToPlainText(html);
            if (text.Length > 100) 
            { return text.Substring(0, 100); } 
            else 
                return text;
        }

        //HtmlDocument
        public static M_BaseCodeList AngleSharpParse(string html)
        {
            M_BaseCodeList bc = new M_BaseCodeList();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            foreach (IElement element in document.QuerySelectorAll("tr"))
            {
                if(AppVersion.Ver ==  AppVersion.Number.V1)
                {
                    bc.codes.Add(new BaseCodeV1(
                    (((AngleSharp.Dom.Element)element.Children[0]).FirstElementChild as AngleSharp.Html.Dom.IHtmlImageElement).Source,
                    element.Children[1].InnerHtml.Trim(),
                    element.Children[2].InnerHtml.Trim(),
                    element.Children[3].InnerHtml.Trim()
                    ));
                }
                if (AppVersion.Ver == AppVersion.Number.V2)
                {
                    bc.codes.Add(new BaseCodeV2(
                    (((AngleSharp.Dom.Element)element.Children[0]).FirstElementChild as AngleSharp.Html.Dom.IHtmlImageElement).Source,
                    element.Children[1].InnerHtml.Trim(),
                    element.Children[2].InnerHtml.Trim(),
                    element.Children[3].InnerHtml.Trim(),
                    element.Children[4].InnerHtml.Trim()
                    ));
                }


            }

            return bc;
        }

        public static string GetJSON(M_BaseCodeList baseMapList, bool removeFormatting = false)
        {
            JObject jobj = new JObject();
            JArray array = new JArray();

            foreach (var item in baseMapList.codes)
            {
                if (removeFormatting)
                {
                    item.Price = item.Price.Replace("Rs", "").Replace(",", "");
                }
                array.Add(JObject.FromObject(item));
            }
            JProperty root = new JProperty("Inventory", array);
            jobj.Add(root);
            return jobj.ToString();
        }
    }
}
