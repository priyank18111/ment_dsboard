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
    class AdapterMoreLeaves : RecyclerView.Adapter
    {
        private MoreLeaveList moreLeaveList;
        private DashboardMentorsFragment dashboardMentorsFragment;

        public AdapterMoreLeaves(MoreLeaveList moreLeaveList, DashboardMentorsFragment dashboardMentorsFragment)
        {
            this.moreLeaveList = moreLeaveList;
            this.dashboardMentorsFragment = dashboardMentorsFragment;
        }

        public override int ItemCount => moreLeaveList.MoreLeaveListNumbers;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ViewHolderMoreLeaves viewHolderMoreLeaves = holder as ViewHolderMoreLeaves;
            viewHolderMoreLeaves.BindData(moreLeaveList[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.internMoreLeaveListLayout, parent, false);
            return new ViewHolderMoreLeaves(view);
        }

        class ViewHolderMoreLeaves : RecyclerView.ViewHolder
        {
            private TextView _textViewInternNamesMoreLeaves;
            private TextView _textViewTotalMoreLeaves;
            public ViewHolderMoreLeaves(View itemView) : base(itemView)
            {
                _textViewInternNamesMoreLeaves = itemView.FindViewById<TextView>(Resource.Id.textViewInterNameMoreLeave);
                _textViewTotalMoreLeaves = itemView.FindViewById<TextView>(Resource.Id.textViewTotalMoreLeaves);
            }

            internal void BindData(Leavelistsmore leavelistsmore)
            {
                _textViewInternNamesMoreLeaves.Text = leavelistsmore.InternName;
                _textViewTotalMoreLeaves.Text = leavelistsmore.TotalMoreLeaves.ToString();
            }
        }
    }
}