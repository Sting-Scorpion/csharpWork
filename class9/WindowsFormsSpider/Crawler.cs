using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsSpider
{
    class Crawler
    {
        //private Hashtable urls = new Hashtable();
        //private int count = 0;
        public event Action<Crawler> CrawlerStopped;//爬完的事件
        public event Action<Crawler, string, string> PageDownloaded;
        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>(?<protocal>https?)://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        //协议为https				字符	端口号		  路径部分 文件部分
        //URL检测表达式，用于在HTML文本中查找URL
        public static readonly string strRef = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        //主机过滤规则
        public string HostFilter { get; set; }
        //待下载队列
        Queue<string> pending = new Queue<string>();
        //已下载网页
        public ConcurrentDictionary<string, bool> DownloadedPages { get; } = new ConcurrentDictionary<string, bool>();
        //文件过滤规则
        public string FileFilter { get; set; }
        //最大下载数量
        public int MaxPage { get; set; }
        //起始网址
        public string StartURL { get; set; }
        //网页编码
        public Encoding HtmlEncoding { get; set; }

        public Crawler()
        {
            MaxPage = 40;
            HtmlEncoding = Encoding.UTF8;
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = DownloadedPages.Count.ToString();
                File.WriteAllText("cnblogs" + fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        //文本内容+文本下载的网址
        public void Parse(string html, string current)
        {
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "" || linkUrl.StartsWith("javascript:")) continue;//空或者js，不是真正的html网址，就下一个

                linkUrl = TransToComplete(linkUrl, current);//转绝对路径
                                                            //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)//通过正则表达式判断是否符合
                  && !DownloadedPages.ContainsKey(linkUrl))
                {
                    pending.Enqueue(linkUrl);
                }
                //strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim
                //    ('"', '\"', '#', '>');
                //if (strRef.Length == 0) continue;
                //if (urls[strRef] == null) urls[strRef] = false;
            }
        }
        public void Start()
        {
            DownloadedPages.Clear();
            pending = new Queue<string>();
            pending.Enqueue(StartURL);
            Parallel.Invoke(new Action[]{
                    ()=>Add()
            });

            CrawlerStopped(this);


        }
        //private void Crawl(string startURL)
        //{
        //    urls.Add(startURL, false);
        //    MessageBox.Show("开始爬行......");
        //    while (true)
        //    {
        //        string current = null;
        //        foreach (string url in urls.Keys)
        //        {
        //            if ((bool)urls[url]) continue;
        //            current = url;
        //        }
        //        if (current == null || count > 10) break;
        //        MessageBox.Show("爬行" + current + "页面！");
        //        string html = DownLoad(current);
        //        urls[current] = true;
        //        count++;
        //        Parse(html, url);
        //    }
        //    MessageBox.Show("爬行结束");
        //}
        //转换为完整路径
        private string TransToComplete(string url, string current)
        {
            if (current.EndsWith("/")) current = current.Substring(0, current.Length - 1);
            if (url.Contains("://")) return url;    //完整路径
            if (url.StartsWith("//"))//未加协议
            {
                Match urlMatch = Regex.Match(current, urlParseRegex);
                string protocal = urlMatch.Groups["protocal"].Value;
                return protocal + ":" + url;//协议（eg. http/https）+ URL
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(current, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))//退一级
            {
                url = url.Substring(3);
                int idx = current.LastIndexOf('/');
                return TransToComplete(url, current.Substring(0, idx));
            }

            if (url.StartsWith("./"))//当前路径，去掉就行
            {
                return TransToComplete(url.Substring(2), current);
            }
            //非上述开头的相对路径
            int end = current.LastIndexOf("/");
            return current.Substring(0, end) + "/" + url;
        }
        private void Add()
        {
            while (DownloadedPages.Count < MaxPage && pending.Count > 0)
            {
                string url = pending.Dequeue();
                try
                {
                    string html = DownLoad(url); // 下载
                    DownloadedPages[url] = true;
                    PageDownloaded(this, url, "success");
                    Parse(html, url);//解析,并加入新的链接
                }
                catch (Exception ex)
                {
                    PageDownloaded(this, url, "  Error:" + ex.Message);
                }
            }
        }
    }
}
