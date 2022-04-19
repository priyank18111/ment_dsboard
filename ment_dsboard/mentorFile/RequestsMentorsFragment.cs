using Fragment = AndroidX.Fragment.App.Fragment;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ment_dsboard.mentorFile;
using AndroidX.RecyclerView.Widget;
using ment_dsboard.MentorsFile;

namespace ment_dsboard
{
    public class RequestsMentorsFragment : Fragment
    {
        RecyclerView.LayoutManager mLayoutManager;
        List<internOnLeave> leavelist;
        leaveRecyclerAdapter mAdapter;
        RecyclerView recycler;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View leaveStatusView = inflater.Inflate(Resource.Layout.activity_main, container, false);
            recycler = leaveStatusView.FindViewById<RecyclerView>(Resource.Id.recyclerviewId);
            

            datainput();
            mLayoutManager = new LinearLayoutManager(Activity);
            recycler.SetLayoutManager(mLayoutManager);
            mAdapter = new leaveRecyclerAdapter(leavelist, Activity);
            recycler.SetAdapter(mAdapter);
            return leaveStatusView;
        }
        private void datainput()
        {
            leavelist = new List<internOnLeave>
            {
               new internOnLeave{ reason ="i have to visit a family function",day="Wed",date="16 feb",typeofleave="half day",seperatordate =" Jan 2022",statusofleave="accepted",buttontext="Revoke"},
               new internOnLeave{ reason ="i have to visit a dentist ",day="Wed",date="14 feb",typeofleave="full day",statusofleave="pending",buttontext="Req to revoke"},
               new internOnLeave{ reason ="i missed the bus",day="thu",date="17 feb",typeofleave="half day",seperatordate ="",statusofleave="accepted",buttontext="Revoke"},
               new internOnLeave{ reason ="i missed the train",day="Friday",date="18 feb",typeofleave="full day",seperatordate =" Feb 2022",statusofleave="pending",buttontext="Revoke"},
               new internOnLeave{ reason ="Mood nahi hai",day="Monday",date="20 feb",typeofleave="half day",seperatordate =" Mar 2022",statusofleave="accepted",buttontext="Req to revoke"},
               new internOnLeave{ reason ="Shadi thi",day="Tue",date="25 feb",typeofleave="full day",seperatordate ="",statusofleave="accepted",buttontext="Revoke"},
               new internOnLeave{ reason ="Dadi nahi  rahi",day="Wed",date="26 feb",typeofleave="full day",seperatordate =" Apr 2022",statusofleave="pending",buttontext="Revoke"},
               new internOnLeave{ reason ="Baju wala nahi raha",day="Thu",date="27 feb",typeofleave="full day",seperatordate ="",statusofleave="accepted",buttontext="Revoke"},

            };
        
    }
    }
}