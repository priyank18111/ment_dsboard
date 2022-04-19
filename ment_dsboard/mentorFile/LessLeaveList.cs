using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ment_dsboard
{
    class LeaveListless
    {
        public LeaveListless(string intrenNameLessLeave, int totalLessLeaves)
        {
            InternNameLessLeave = intrenNameLessLeave;
            TotalLessLeaves = totalLessLeaves;
        }

        public string InternNameLessLeave { get;  set; }
        public int TotalLessLeaves { get;  set; }
    }
    class LessLeaveList
    {
        static LeaveListless[] lessleavelists =
        {

            new LeaveListless("Elsa Frost",02),
            new LeaveListless("Anna Martin",01),
            new LeaveListless("Elsa Frost",02),
            new LeaveListless("Anna Martin",01),
            new LeaveListless("Elsa Frost",02),
            new LeaveListless("Anna Martin",01),
            new LeaveListless("Elsa Frost",02),
            new LeaveListless("Anna Martin",01),
        };

        private LeaveListless[] leaveListless;

        public LessLeaveList()
        {
            leaveListless= lessleavelists;
        }
        public int lessLeaveNumber
        {
            get { return leaveListless.Length; }
        }
        public LeaveListless this[int i]
        {

            get { return leaveListless[i]; }
        }

       
    }
}