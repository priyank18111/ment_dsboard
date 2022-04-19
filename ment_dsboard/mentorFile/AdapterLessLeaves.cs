using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ment_dsboard
{
    class AdapterLessLeaves : RecyclerView.Adapter
    {
        private LessLeaveList lessLeaveList;
        private DashboardMentorsFragment dashboardMentorsFragment;

        public AdapterLessLeaves(LessLeaveList lessLeaveList, DashboardMentorsFragment dashboardMentorsFragment)
        {
            this.lessLeaveList = lessLeaveList;
            this.dashboardMentorsFragment = dashboardMentorsFragment;
        }

        public override int ItemCount => lessLeaveList.lessLeaveNumber;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ViewHolderLessView viewHolderLessView = holder as ViewHolderLessView;
            viewHolderLessView.BindData(lessLeaveList[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.internLessLeaveListLayout, parent, false);
            return new ViewHolderLessView(view);
        }

        class ViewHolderLessView : RecyclerView.ViewHolder
        {
            private TextView _textViewInternsNameLessLeave;
            private TextView _textViewTotalLessLeaves;
            public ViewHolderLessView(View itemView) : base(itemView)
            {
                _textViewInternsNameLessLeave = itemView.FindViewById<TextView>(Resource.Id.textViewInterNameLessLeave);
                _textViewTotalLessLeaves = itemView.FindViewById<TextView>(Resource.Id.textViewTotalLessLeaves);
            }

            internal void BindData(LeaveListless leaveListless)
            {
                _textViewInternsNameLessLeave.Text = leaveListless.InternNameLessLeave;
                _textViewTotalLessLeaves.Text = leaveListless.TotalLessLeaves.ToString();
            }
        }
    }
}