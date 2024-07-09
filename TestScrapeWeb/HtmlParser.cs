using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestScrapeWeb
{
    public class HtmlParser
    {
        public static void ParseHtmlForVideos(string html)
        {


            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var siblingDivs = doc.DocumentNode.SelectNodes("//div[span[contains(text(), 'Video')]]/following-sibling::div");

            HtmlNode videoDivs = null;

            if (siblingDivs != null)
            {
                foreach (var siblingDiv in siblingDivs)
                {
                    videoDivs = siblingDiv;
                }
            }
            var videoLinksSet = new HashSet<string>();
            if (videoDivs != null)
            {
                var linkNodes = doc.DocumentNode.SelectNodes("//a[@href]");
                var vidsDiv = videoDivs.SelectSingleNode("(./div/div)[1]");

                IEnumerable<HtmlNode> childNodes = videoDivs.ChildNodes;
                int cnt = 0;
                /*foreach (var child in linkNodes)
                {*/
                    var videoLinks = doc.DocumentNode.SelectNodes("//a[@href]");

                    if (videoLinks != null)
                    {
                        foreach (var videoLink in videoLinks)
                        {
                            var href = videoLink.GetAttributeValue("href", string.Empty);

                            if (href.Contains("/videos/") && videoLinksSet.Add(href))
                            {
                                cnt++;
                                Console.WriteLine($"Video Link: {href}");
                                Console.WriteLine();
                            }
                        }
                   /* }*/
                }
                Console.WriteLine(cnt);

                Console.WriteLine("--------------------");
                /* var videoLinksSet = new HashSet<string>();

                 if (videoDivs != null)
                 {
                     foreach (var videoDiv in videoDivs)
                     {
                         var videoLinks = videoDiv.SelectNodes(".//a[@href]");

                         if (videoLinks != null)
                         {
                             foreach (var videoLink in videoLinks)
                             {
                                 *//*var href = videoLink.GetAttributeValue("href", string.Empty);

                                 if (href.Contains("/videos/") && videoLinksSet.Add(href))
                                 {
                                     Console.WriteLine($"Video Link: {href}");
                                     // Extract view count
                                     var viewCountNode = videoDiv.SelectSingleNode(".//div[contains(text(), 'lượt phát')]");
                                     var viewCount = viewCountNode?.InnerText.Trim();

                                     // Extract time
                                     var timeNode = videoDiv.SelectSingleNode(".//span[contains(text(), 'ngày trước')]");
                                     var time = timeNode?.InnerText.Trim();

                                     // Extract reaction count
                                     var reactionNode = videoDiv.SelectSingleNode(".//span[contains(text(), 'Xem ai đã bày tỏ cảm xúc về tin này')]/following-sibling::span[last()]");
                                     var reactionCount = reactionNode?.InnerText.Trim();

                                     // Output the results
                                     Console.WriteLine($"Views: {viewCount}");
                                     Console.WriteLine($"Time: {time}");
                                     Console.WriteLine($"Reactions: {reactionCount}");
                                     Console.WriteLine();
                                 }*//*
                             }
                         }
                                 Console.WriteLine("Video Information:");

                                 // Print all child nodes of videoDiv
                                 PrintChildNodes(videoDiv);

                                 Console.WriteLine("--------------------");
                                 break;
                     }
                 }*/
            }
        }
    }
}
