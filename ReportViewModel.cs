using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolesDemo.Models
{
    public class ReportViewModel
    {

        public DateTime StartDate { get; set; }
        // public String[] staff { get; set; }


        /* public String getPopularElement()
         {
             int count = 1, tempCount;
             String popular = staff[0];
             String temp = "";
             for (int i = 0; i <= (staff.Length - 1); i++)
             {
                 temp = staff[i];
                 tempCount = 0;
                 for (int j = 1; j <= staff.Length; j++)
                 {
                     if (temp == staff[j])
                         tempCount++;
                 }
                 if (tempCount > count)
                 {
                     popular = temp;
                     count = tempCount;
                 }
             }
             return popular;
         }
         * */
    }
}