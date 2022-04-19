using Fragment = AndroidX.Fragment.App.Fragment;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.RecyclerView.Widget;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using MikePhil.Charting.Util;

namespace ment_dsboard
{
    class DashboardMentorsFragment : Fragment
    {
        private Context context;
        private RecyclerView _recyclerViewMoreLeaves;
        private RecyclerView.LayoutManager _layoutmanagerMoreLeaves;
        private AdapterMoreLeaves _adapterMoreLeaves;
        private MoreLeaveList _moreLeaveList;

        private RecyclerView _recyclerViewLessLeaves;
        private RecyclerView.LayoutManager _layoutManagerLessLeaves;
        private AdapterLessLeaves _adapterLessLeaves;
        private LessLeaveList _lessLeaveList;

        private PieChart _pieChartLeaveStatusMentors;
        private PieDataSet _pieDataSetLeaveStatusMentors;
        private PieData _pieDataLeaveStatusMentors;
        private List<PieEntry> _leaveListStatusMentors;
        private List<int> _pieChartColors;

        public DashboardMentorsFragment()
        {
        }

        public DashboardMentorsFragment(Context context)
        {
            this.context = context;
        }

      

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View viewdashboard = inflater.Inflate(Resource.Layout.dashboardMentorsFragmentLayout, container, false);

            _recyclerViewMoreLeaves = viewdashboard.FindViewById<RecyclerView>(Resource.Id.recyclerViewInternsMoreLeaves);
            _recyclerViewLessLeaves = viewdashboard.FindViewById<RecyclerView>(Resource.Id.recyclerViewIntrenLessLeaves);
            _pieChartLeaveStatusMentors = viewdashboard.FindViewById<PieChart>(Resource.Id.pieChartLeaveStatusMentors);

            _layoutmanagerMoreLeaves = new LinearLayoutManager(context);
            _recyclerViewMoreLeaves.SetLayoutManager(_layoutmanagerMoreLeaves);

            _moreLeaveList = new MoreLeaveList();
            _adapterMoreLeaves = new AdapterMoreLeaves(_moreLeaveList,this);
            _recyclerViewMoreLeaves.SetAdapter(_adapterMoreLeaves);

            _layoutManagerLessLeaves = new LinearLayoutManager(context);
            _recyclerViewLessLeaves.SetLayoutManager(_layoutManagerLessLeaves);

            _lessLeaveList = new LessLeaveList();
            _adapterLessLeaves = new AdapterLessLeaves(_lessLeaveList,this);
            _recyclerViewLessLeaves.SetAdapter(_adapterLessLeaves);

            GetPieData();
            return viewdashboard;
        }

        private void GetPieData()
        {
            _leaveListStatusMentors = new List<PieEntry>();
            _leaveListStatusMentors.Add(new PieEntry(10));
            _leaveListStatusMentors.Add(new PieEntry(5));
            _leaveListStatusMentors.Add(new PieEntry(8));

            _pieDataSetLeaveStatusMentors = new PieDataSet(_leaveListStatusMentors, "Leave Status");
            _pieChartColors = new List<int>();
            foreach(var color in ColorTemplate.MaterialColors)
            {
                _pieChartColors.Add(color);

            }
            _pieDataSetLeaveStatusMentors.SetColors(_pieChartColors.ToArray());
            _pieDataLeaveStatusMentors = new PieData(_pieDataSetLeaveStatusMentors);
            _pieChartLeaveStatusMentors.Data = _pieDataLeaveStatusMentors;
            _pieChartLeaveStatusMentors.Invalidate();
            _pieChartLeaveStatusMentors.Description.Enabled = false;
            _pieChartLeaveStatusMentors.Animate();
        }
    }
}