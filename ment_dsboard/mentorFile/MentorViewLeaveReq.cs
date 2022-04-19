using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ment_dsboard.mentorFile
{
    [Activity(Label = "MentorViewLeaveReq")]
    public class MentorViewLeaveReq : AppCompatActivity
    {
        ImageView _arrowback;
        TextView _name, _from, _to, _date, _type, _viewleaverequest;
        Button _revoke, _reject, _accept;
        protected override void OnCreate(Bundle savedInstanceState)
        {
         
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ViewLeaveRequest);
            UIreference();
            _arrowback.Click += _arrowback_Click;
        }

        private void _arrowback_Click(object sender, EventArgs e)
        {
           Finish();
        }

        private void UIreference()
        {
            _arrowback = FindViewById<ImageView>(Resource.Id.imageViewArrowBack);
            _name = FindViewById<TextView>(Resource.Id.textViewName);
            _from = FindViewById<TextView>(Resource.Id.textViewFrom);
            _to = FindViewById<TextView>(Resource.Id.textViewTo);
            _date = FindViewById<TextView>(Resource.Id.textViewDate);
            _type = FindViewById<TextView>(Resource.Id.textViewType);
            _viewleaverequest = FindViewById<TextView>(Resource.Id.textViewLeaveRequest);
            _revoke = FindViewById<Button>(Resource.Id.materialButtonRevoke);
            _reject = FindViewById<Button>(Resource.Id.materialButtonreject);
            _accept = FindViewById<Button>(Resource.Id.materialButtonAccept);
        }
    }
}