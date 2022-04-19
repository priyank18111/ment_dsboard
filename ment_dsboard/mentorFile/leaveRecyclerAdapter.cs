using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.RecyclerView.Widget;
using ment_dsboard.mentorFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ment_dsboard.MentorsFile
{
    internal class leaveRecyclerAdapter : RecyclerView.Adapter
    {
        RecyclerView.ViewHolder viewHolder;
        public const int USER = 0, IMAGE = 1;
        List<internOnLeave> leavelist;
        MyViewHolder viewholder1;
        MyViewHolder2 viewHolder2;
        Context con;

        //public event EventHandler<int> itemClick;


        public leaveRecyclerAdapter(List<internOnLeave> leavelist, Context context)
        {
            this.leavelist = leavelist;
            con = context;

           
        }

        //public override int ItemCount => throw new NotImplementedException();
        public override int ItemCount
        {
            get { return leavelist.Count; }
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case USER:
                    MyViewHolder viewHolder1 = holder as MyViewHolder;
                    configureViewHolder1(viewHolder1, position);
                    break;
                case IMAGE:
                    MyViewHolder2 viewholder2 = holder as MyViewHolder2;
                    configureViewHolder2(viewholder2, position);
                    break;
            }

        }



        private void configureViewHolder2(MyViewHolder2 vh2, int position)
        {
            if (leavelist[position].statusofleave.Trim() == "pending")
            {

                vh2.leavestatusbutton2.SetTextColor(Android.Graphics.Color.ParseColor("#FF6A00"));

                vh2.leavestatusbutton2.SetBackgroundResource(Resource.Drawable.buttonstroke3);
            }
            else if (leavelist[position].statusofleave.Trim() == "accepted")
            {
                vh2.leavestatusbutton2.SetTextColor(Android.Graphics.Color.ParseColor("#4D94FF"));
                vh2.leavestatusbutton2.SetBackgroundResource(Resource.Drawable.buttonstroke2);
            }
            vh2.monthtext2.Text = leavelist[position].seperatordate;
            vh2.reaasonTextView2.Text = leavelist[position].reason;
            vh2.dayDateTextview2.Text = leavelist[position].date;
            vh2.typeofleaveTextview2.Text = leavelist[position].typeofleave;
            vh2.leavestatusbutton2.Text = leavelist[position].statusofleave;
            vh2.revokebutton2.Text = leavelist[position].buttontext;
            vh2.constraintLayout2.Click += ConstraintLayout2_Click;
        }

        private void ConstraintLayout2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(con, typeof(MentorViewLeaveReq));
            con.StartActivity(intent);
        }

        private void configureViewHolder1(MyViewHolder vh1, int position)
        {
            if (leavelist[position].statusofleave.Trim() == "pending")
            {

                vh1.leavestatusbutton.SetTextColor(Android.Graphics.Color.ParseColor("#FF6A00"));
                vh1.leavestatusbutton.SetBackgroundResource(Resource.Drawable.buttonstroke3);
            }
            else if (leavelist[position].statusofleave.Trim() == "accepted")
            {
                vh1.leavestatusbutton.SetTextColor(Android.Graphics.Color.ParseColor("#4D94FF"));
                vh1.leavestatusbutton.SetBackgroundResource(Resource.Drawable.buttonstroke2);
            }
            vh1.reaasonTextView.Text = leavelist[position].reason;
            vh1.dayDateTextview.Text = leavelist[position].date;
            vh1.typeofleaveTextview.Text = leavelist[position].typeofleave;
            vh1.leavestatusbutton.Text = leavelist[position].statusofleave;
            vh1.revokebutton.Text = leavelist[position].buttontext;
            vh1.constraintLayout1.Click += ConstraintLayout1_Click;

        }

        private void ConstraintLayout1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(con, typeof(MentorViewLeaveReq));
            con.StartActivity(intent);
        }

        public override int GetItemViewType(int position)
        {
            if (leavelist[position].seperatordate != "")
                return IMAGE;
            else
                return USER;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            switch (viewType)
            {
                case USER:
                    View v1 = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.hetrogenousRowitem, parent, false);
                    viewHolder = new MyViewHolder(v1);
                    break;
                case IMAGE:
                    View v2 = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.hetrogenouslayout2, parent, false);
                    viewHolder = new MyViewHolder2(v2);
                    break;
            }
            return viewHolder;
        }
        public class MyViewHolder : RecyclerView.ViewHolder
        {
            //private readonly Action<int> listener;
            public Button leavestatusbutton, revokebutton;
            public TextView reaasonTextView, dayDateTextview, typeofleaveTextview;
            public ConstraintLayout constraintLayout1;
            public MyViewHolder(View itemView) : base(itemView)
            {
                reaasonTextView = itemView.FindViewById<TextView>(Resource.Id.textviewitem1);
                dayDateTextview = itemView.FindViewById<TextView>(Resource.Id.textviewitem2);
                typeofleaveTextview = itemView.FindViewById<TextView>(Resource.Id.textviewitem3);
                leavestatusbutton = itemView.FindViewById<Button>(Resource.Id.textviewitem4);
                revokebutton = itemView.FindViewById<Button>(Resource.Id.textviewitem5);
                constraintLayout1 = itemView.FindViewById<ConstraintLayout>(Resource.Id.constraintLayout2);
            }


        }
        public class MyViewHolder2 : RecyclerView.ViewHolder
        {
            public Button leavestatusbutton2, revokebutton2;
            public TextView reaasonTextView2, dayDateTextview2, typeofleaveTextview2;
            //private readonly Action<int> listener;
            public TextView monthnameTextView, monthtext2;
            public ConstraintLayout constraintLayout2;
            public MyViewHolder2(View itemView) : base(itemView)
            {

                monthtext2 = itemView.FindViewById<TextView>(Resource.Id.monthid2);
                reaasonTextView2 = itemView.FindViewById<TextView>(Resource.Id.textviewitem1);
                dayDateTextview2 = itemView.FindViewById<TextView>(Resource.Id.textviewitem2);
                typeofleaveTextview2 = itemView.FindViewById<TextView>(Resource.Id.textviewitem3);
                leavestatusbutton2 = itemView.FindViewById<Button>(Resource.Id.textviewitem4);
                revokebutton2 = itemView.FindViewById<Button>(Resource.Id.textviewitem5);
                constraintLayout2 = itemView.FindViewById<ConstraintLayout>(Resource.Id.constraintLayout1);
            }


        }

    }
}