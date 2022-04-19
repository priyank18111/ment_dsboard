using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;

namespace ment_dsboard
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class internshipDetailsAct : AppCompatActivity
    {
        RecyclerView recyclerView;
        Adapter1 adapter1;
        ImageView Backimage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.mentorInternsDetiails);
            string[] names = new string[] { "Shivam Mistry", "Daniel Richard", "Sam Paul", "Will Smith", "Shivam Mistry", "Mit", "Raju", "sagar" };
            recyclerView = FindViewById<RecyclerView>(Resource.Id.testrecycleview);
            Backimage = FindViewById<ImageView>(Resource.Id.Backimage);
            adapter1 = new Adapter1(names);
            recyclerView.SetAdapter(adapter1);
            Backimage.Click += Backimage_Click;

        }

        private void Backimage_Click(object sender, System.EventArgs e)
        {
            Finish();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}