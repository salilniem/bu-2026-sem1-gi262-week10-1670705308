using System;
using System.Collections.Generic;

namespace MidtermExam.Prob02
{
    /// <summary>
    /// โค้ดที่เตรียมให้: แยกข้อความคำสั่งแล้วเรียกเมธอดของ StudentWebBrowser
    /// </summary>
    public class BrowserNavigation
    {
        /// <summary>ประมวลผลคำสั่งที่คั่นด้วย ; โดยสร้าง browser ใหม่ทุกครั้งที่เรียก</summary>
        public string[] AS02_WebBrowserNavigation(string actions)
        {
            var browser = new StudentWebBrowser();
            var output = new List<string>();
            if (string.IsNullOrWhiteSpace(actions)) return output.ToArray();

            foreach (string part in actions.Split(';'))
            {
                string command = part.Trim();
                if (command.StartsWith("open ", StringComparison.Ordinal))
                    browser.Open(command.Substring(5).Trim());
                else if (command == "back") browser.Back();
                else if (command == "forward") browser.Forward();
                else if (command == "current") output.Add(browser.Current());
            }
            return output.ToArray();
        }
    }
}