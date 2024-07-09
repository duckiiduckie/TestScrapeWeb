using System;
using TestScrapeWeb;

public class Program
{
    public static void Main(string[] args)
    {
        string url = "https://www.facebook.com/Theanh28/videos"; 
        string email = "gailathutontaiduynhat1@gmail.com"; 
        string password = "duckie010203"; 

        string html = SeleniumScraper.LoginAndGetPageSource(url, email, password);
        HtmlParser.ParseHtmlForVideos(html);
    }
}
