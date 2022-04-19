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
using DE.Hdodenhof.Circleimageview;
using AndroidX.CardView.Widget;
using Android.App;
using Xamarin.Essentials;
using Android.Graphics;
using Path = System.IO.Path;

namespace ment_dsboard
{
    public class ProfileMentorsFragment : Fragment
    {
        public CircleImageView profileImage;
        public CardView cardViewProfileImage;
        public int getImage;
        public ImageView mentorNextDetailsImageView, mentornextChangePassImageView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View leaveStatusView = inflater.Inflate(Resource.Layout.mentorProfileLyt, container, false);
            cardViewProfileImage = leaveStatusView.FindViewById<CardView>(Resource.Id.mentorCardView);
            mentorNextDetailsImageView = leaveStatusView.FindViewById<ImageView>(Resource.Id.mentorNextDetailsImageView);
            mentornextChangePassImageView = leaveStatusView.FindViewById<ImageView>(Resource.Id.mentornextChangePassImageView);
            mentornextChangePassImageView.Click += MentornextChangePassImageView_Click;
            mentorNextDetailsImageView.Click += MentorNextDetailsImageView_Click;
            profileImage = leaveStatusView.FindViewById<CircleImageView>(Resource.Id.profileImageImageView);
            profileImage.Click += ProfileImage_Click;
            imageSetter(getImage);
            return leaveStatusView;
        }

        private void MentornextChangePassImageView_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(ChangePasswordActivity));
            Context.StartActivity(intent);
        }

        private void MentorNextDetailsImageView_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context,typeof(internshipDetailsAct));
            Context.StartActivity(intent);
        }

        private void imageSetter(int getImage)
        {
            profileImage.SetImageResource(getImage);
        }

        private void ProfileImage_Click(object sender, EventArgs e)
        {
            AndroidX.AppCompat.App.AlertDialog.Builder alert = new AndroidX.AppCompat.App.AlertDialog.Builder(Context);
            alert.SetTitle("Select Profile");
            alert.SetMessage("Select your Image");

            alert.SetPositiveButton("Gallery", (senderAlert, args) =>
            {
                MyLayoutPickimage_Click();
            });

            alert.SetNegativeButton("Camera", (senderAlert, args) =>
            {
                MyLayoutTakeimage_Click();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
        private async void MyLayoutPickimage_Click()
        {
            var res = await MediaPicker.PickPhotoAsync();
            if (res.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || (res.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))) ;
            {
                var stream = await res.OpenReadAsync();
                profileImage.SetImageBitmap(BitmapFactory.DecodeStream(stream));

            }
        }

        private async void MyLayoutTakeimage_Click()
        {
            var photo = await MediaPicker.CapturePhotoAsync();

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            {
                profileImage.SetImageBitmap(BitmapFactory.DecodeStream(stream));
            }

        }
    }
}