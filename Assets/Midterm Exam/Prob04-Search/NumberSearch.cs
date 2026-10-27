using System;

namespace MidtermExam.Prob04
{
    public class NumberSearch
    {
        /// <summary>ข้อ 04.1: ค้นหาตัวเลขด้วย Sequential Search จากต้น array ไปท้าย array</summary>
        /// <param name="values">array ที่อาจไม่เรียงลำดับ มีค่าซ้ำหรือตัวเลขติดลบได้</param>
        /// <param name="target">ค่าที่ต้องการค้นหา</param>
        /// <returns>
        /// - index แรกที่พบ เริ่มนับจาก 0 
        /// - ถ้าไม่พบ หรือ input เป็น null หรือเป็น array ว่าง ให้ return -1</returns>
        /// <remarks>
        /// ห้ามเรียงลำดับหรือแก้ไข array และห้ามใช้เมธอดค้นหาสำเร็จรูปหรือ LINQ
        /// ตัวอย่าง: values = [4, 2, 4, 1], target = 4 ต้องคืน 0 ไม่ใช่ 2
        /// ใช้เวลา O(n) และเขียนคอมเมนต์อธิบายเหตุผลของเวลาที่ใช้เหนือคำตอบ
        /// </remarks>
        // Explanation of Time Complexity O(n):
        // Sequential Search ต้องวนลูปตรวจสอบสมาชิกทีละตัวตั้งแต่ index แรกไปจนถึง indexสุดท้าย
        // - Worst Case: เมื่อ target อยู่ที่ตำแหน่งสุดท้าย หรือไม่มี target อยู่ใน array เลย
        //   โปรแกรมจะต้องเปรียบเทียบข้อมูลทั้งหมด n ครั้ง (เท่ากับจำนวนสมาชิกใน array)
        // - Therefore: Time Complexity ในกรณีแย่ที่สุดจึงเป็น O(n)
        public int AS04_SequentialSearch(int[] values, int target)
        {
            if (values == null || values.Length == 0)
            {
                return -1;
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == target)
                {
                    return i; // คืนค่า index แรกที่พบทันที
                }
            }

            return -1; // ไม่พบ target ใน array
        }

        /// <summary>ข้อ 04.2: ค้นหาตัวเลขด้วย Binary Search โดยลดช่วงค้นหาประมาณครึ่งหนึ่งต่อขั้น</summary>
        /// <param name="sortedValues">
        /// array ที่เรียงจากน้อยไปมากให้แล้ว มีค่าซ้ำหรือตัวเลขติดลบได้ ไม่ต้องตรวจหรือเรียงใหม่
        /// </param>
        /// <param name="target">ค่าที่ต้องการค้นหา</param>
        /// <returns>
        /// index ใดก็ได้ที่มีค่าเท่ากับ target หรือ -1 ถ้าไม่พบ/input เป็น null หรือว่าง
        /// ต่างจาก Sequential Search ในข้อนี้ไม่จำเป็นต้องคืน index แรกของค่าที่ซ้ำ
        /// </returns>
        /// <remarks>
        /// ใช้ลูปหรือ recursion ได้ แต่ห้ามค้นหาแบบไล่ทุกสมาชิกหรือเรียกเมธอดค้นหาสำเร็จรูป
        /// ห้ามแก้ไข array ตัวอย่าง: [1, 2, 2, 2, 5] ค้นหา 2 คืน 1, 2 หรือ 3 ได้
        /// ใช้เวลา O(log n) และเขียนคอมเมนต์อธิบายเหตุผลของเวลาที่ใช้เหนือคำตอบ
        /// </remarks>
        // Explanation of Time Complexity O(log n):
        // Binary Search ทำงานบน array ที่เรียงลำดับแล้ว โดยในแต่ละรอบของการเปรียบเทียบ
        // ช่วงการค้นหาจะถูกแบ่งครึ่งลงเรื่อยๆ (ขอบเขตขนาดย่อยลงเป็น n/2, n/4, n/8, ...)
        // - Worst Case: จำนวนครั้งในการวนลูปค้นหาจะเท่ากับจำนวนครั้งที่แบ่ง n ด้วย 2 จนกว่าจะเหลือ 1
        //   นั่นคือ log2(n) ครั้ง
        // - Therefore: Time Complexity ในกรณีแย่ที่สุดจึงเป็น O(log n)
        public int AS05_BinarySearch(int[] sortedValues, int target)
        {
            // 1. จัดการ input ที่เป็น null/ว่าง
            if (sortedValues == null || sortedValues.Length == 0)
            {
                return -1;
            }

            int left = 0;
            int right = sortedValues.Length - 1;

            while (left <= right)
            {
                // 2. เลือก index ตรงกลาง (ป้องกัน Integer Overflow จาก (left + right) / 2)
                int mid = left + (right - left) / 2;

                if (sortedValues[mid] == target)
                {
                    return mid; // พบ target คืนค่า index ตรงกลาง
                }

                // 3. ปรับขอบเขตการค้นหาตัดส่วนที่ไม่ต้องการออก
                if (sortedValues[mid] < target)
                {
                    left = mid + 1; // target อยู่ทางขวา
                }
                else
                {
                    right = mid - 1; // target อยู่ทางซ้าย
                }
            }

            // 4. ค้นหาจนหมดช่วง (left > right) แล้วยังไม่พบ
            return -1;
        }
    }
}