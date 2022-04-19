using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using ment_dsboard.MentorsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ment_dsboard.mentorFile
{
    [Activity(Label = "leaverequest")]
    public class leaverequest : AppCompatActivity
    {
        RecyclerView.LayoutManager mLayoutManager;

        List<internOnLeave> leavelist;
        leaveRecyclerAdapter mAdapter;
        RecyclerView recycler;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerviewId);
            datainput();
            mLayoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(mLayoutManager);
            mAdapter = new leaveRecyclerAdapter(leavelist, ApplicationContext);
            recycler.SetAdapter(mAdapter);

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