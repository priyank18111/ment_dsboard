using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ment_dsboard
{
    [Activity(Label = "ForgetPassword")]
    public class ForgetPassword : AppCompatActivity
    {
        private TextInputLayout emailTextInputLayout;
        private EditText emailTextInputEditText;
        private Button sendButton;
        private TextView Resend;
        private Regex validEmail = new Regex("^[a-z0-9]+(@)+[a-z]+(.)+[a-z]{{2,3}}*$");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forget_password); 
            UIReferences();
            UIClickEvent();

        }

        private void UIClickEvent()
        {
            sendButton.Click += SendButton_Click;
            
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!checkemail())
            {

                Toast.MakeText(this, "Please Check your Email and Try Again", ToastLength.Long).Show();
            }

            else if (checkemail())
            {

                Toast.MakeText(this, "Reset Link Sent To Email", ToastLength.Short).Show();
            }
        }

        private bool checkemail()
        {
            if (emailTextInputEditText.Text.Length == 0)
            {
                emailTextInputLayout.Error = "Enter Email";
                return false;
            }
            else if (!ValidateEmail(emailTextInputEditText.Text))
            {
                emailTextInputLayout.Error = "We cannot Find your Email";
                return false;
            }

            return true;
        }

        private bool ValidateEmail(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            return validEmail.IsMatch(text);
        }

        private void UIReferences()
        {
            emailTextInputLayout = FindViewById<TextInputLayout>(Resource.Id.emailTextInputLayout1);
            emailTextInputEditText = FindViewById<EditText>(Resource.Id.emailTextInputEditText);
            sendButton = FindViewById<Button>(Resource.Id.sendButton);
            Resend = FindViewById<TextView>(Resource.Id.resendTextView); 
        }
    }
}