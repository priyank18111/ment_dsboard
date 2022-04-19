using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.FloatingActionButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Google.Android.Material.BottomNavigation.BottomNavigationView;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace ment_dsboard
{ 
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class DashboardMentors : AppCompatActivity, IOnNavigationItemSelectedListener
    {
        private BottomNavigationView _bottomNavigationViewMentors;
        private DashboardMentorsFragment _dashboardMentorsFragment;
        private RequestsMentorsFragment _requestsMentorsFragment;
        private ProfileMentorsFragment _profileMentorsFragment;
        private Toolbar _toolbarMentors;
     
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
            SetContentView(Resource.Layout.dashboardMentorsLayout);

            UIReferences();
            UIClickEvents();
            ObjectCreation();
            
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutDashBoardMentors, _dashboardMentorsFragment).Commit();
            _toolbarMentors.Title = Resources.GetString(Resource.String.dashboard);


        }

        private void UIReferences()
        {
            _bottomNavigationViewMentors = FindViewById<BottomNavigationView>(Resource.Id.bottonNavigationViewMentors);
            _toolbarMentors = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbarMentors);
        }

        
        private void UIClickEvents()
        {
            _bottomNavigationViewMentors.SetOnNavigationItemSelectedListener(this);
        }

        private void ObjectCreation()
        {
            _dashboardMentorsFragment = new DashboardMentorsFragment(this);
            _requestsMentorsFragment = new RequestsMentorsFragment();
            _profileMentorsFragment = new ProfileMentorsFragment();
        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Resource.Id.dashboardmentors:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutDashBoardMentors, _dashboardMentorsFragment).Commit();
                    _toolbarMentors.Title = Resources.GetString(Resource.String.dashboard);
                    break;

                case Resource.Id.requestsmentors:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutDashBoardMentors, _requestsMentorsFragment).Commit();
                    _toolbarMentors.Title = Resources.GetString(Resource.String.request);
                    break;

                case Resource.Id.profilementors:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutDashBoardMentors, _profileMentorsFragment).Commit();
                    _toolbarMentors.Title = Resources.GetString(Resource.String.profile);
                    break;

            }

            return true;
        }
    }

   
}