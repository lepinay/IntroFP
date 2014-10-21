using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

class WebPageDownloadTest
{
    class WebPageDownloader
    {
        public TResult FetchUrl<TResult>(
            string url,
            Func<string, StreamReader, TResult> callback)
        {
            var req = WebRequest.Create(url);

            using (var resp = req.GetResponse())
            using (var stream = resp.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return callback(url, reader);
            }
        }
    }

    public void TestFetchUrlWithCallback()
    {
        Func<string, StreamReader, string> myCallback = (url, reader) =>
        {
            var html = reader.ReadToEnd();
            var html1000 = html.Substring(0, 1000);
            Console.WriteLine(
                "Downloaded {0}. First 1000 is {1}", url,
                html1000);
            return html;
        };

        var downloader = new WebPageDownloader();
        var google = downloader.FetchUrl("http://www.google.com",
                                          myCallback);
    var yahoo = downloader.FetchUrl("http://www.yahoo.com",
                                  myCallback);

        // test with a list of sites
        var sites = new List<string> {
        "http://www.bing.com",
        "http://www.google.com",
        "http://www.yahoo.com"};

        // process each site in the list
        sites.ForEach(site => downloader.FetchUrl(site, myCallback));

        #region curry
        Func<int, Func<int, Func<int, int>>> add = a => (b => (c => a + b + c));
        var add1abc = add(1);
        add1abc(2)(3);
        #endregion

    }


}