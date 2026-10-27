using System;
using System.Collections.Generic;

namespace MidtermExam.Prob02
{
    /// <summary>
    /// ข้อ 02: จำลองประวัติการเปิดเว็บด้วย Stack สองชุด ตามหลัก LIFO
    /// </summary>
    public class StudentWebBrowser
    {
        private Stack<string> backHistory = new Stack<string>();
        private Stack<string> forwardHistory = new Stack<string>();
        private string currentUrl = string.Empty;

        /// <summary>เปิดหน้าเว็บใหม่ และปรับประวัติสำหรับการย้อนกลับและไปข้างหน้า</summary>
        public void Open(string url)
        {
            // 1. ตรวจสอบว่า URL เป็น null, string.Empty หรือมีแต่ช่องว่างหรือไม่
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            // 2. ถ้ามีหน้าปัจจุบันอยู่แล้ว ให้ดันเข้า backHistory
            if (!string.IsNullOrEmpty(currentUrl))
            {
                backHistory.Push(currentUrl);
            }

            // 3. เปลี่ยนหน้าปัจจุบันเป็น URL ใหม่
            currentUrl = url;

            // 4. ล้างประวัติการไปข้างหน้า (Redo stack)
            forwardHistory.Clear();
        }

        /// <summary>ย้อนกลับไปยังหน้าล่าสุดในประวัติย้อนกลับหนึ่งขั้น</summary>
        public void Back()
        {
            // ถ้าไม่มีประวัติย้อนกลับ ให้จบเมธอดโดยไม่เปลี่ยนสถานะ
            if (backHistory.Count == 0)
            {
                return;
            }

            // เก็บหน้าปัจจุบันไว้ใน forwardHistory
            forwardHistory.Push(currentUrl);

            // ดึงหน้าล่าสุดจาก backHistory มาเป็นหน้าปัจจุบัน
            currentUrl = backHistory.Pop();
        }

        /// <summary>ไปข้างหน้าไปยังหน้าล่าสุดในประวัติไปข้างหน้าหนึ่งขั้น</summary>
        public void Forward()
        {
            // ถ้าไม่มีประวัติไปข้างหน้า ให้จบเมธอดโดยไม่เปลี่ยนสถานะ
            if (forwardHistory.Count == 0)
            {
                return;
            }

            // เก็บหน้าปัจจุบันไว้ใน backHistory
            backHistory.Push(currentUrl);

            // ดึงหน้าล่าสุดจาก forwardHistory มาเป็นหน้าปัจจุบัน
            currentUrl = forwardHistory.Pop();
        }

        /// <summary>อ่าน URL ของหน้าปัจจุบัน โดยไม่เปลี่ยนหน้าหรือประวัติใด ๆ</summary>
        public string Current()
        {
            return currentUrl;
        }
    }
}