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
    class Leavelistsmore
    {
        public Leavelistsmore(string internName, int totalMoreLeaves)
        {
            InternName = internName;
            TotalMoreLeaves = totalMoreLeaves;
        }

        public string InternName { get;  set; }
        public int TotalMoreLeaves { get;  set; }
    }
    class MoreLeaveList
    {
        static Leavelistsmore[] lists =
        { 
        
            new Leavelistsmore("Oaken Hans",10),
            new Leavelistsmore("Seven Snowgies",07),
            new Leavelistsmore("Marsh Mellow",06),
            new Leavelistsmore("Oaken Hans",10),
            new Leavelistsmore("Seven Snowgies",07),
            new Leavelistsmore("Marsh Mellow",06),
            new Leavelistsmore("Oaken Hans",10),
            new Leavelistsmore("Seven Snowgies",07),
            new Leavelistsmore("Marsh Mellow",06),
            new Leavelistsmore("Oaken Hans",10),
            new Leavelistsmore("Seven Snowgies",07),
            new Leavelistsmore("Marsh Mellow",06),


        };

        private Leavelistsmore[] newlists;

        public MoreLeaveList()
        {
            newlists = lists;
        }

        public int MoreLeaveListNumbers
        {
            get { return newlists.Length; }
        }

        public Leavelistsmore this[int i]
        {
            get { return newlists[i]; }
        }
    }
}