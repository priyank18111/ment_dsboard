using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextInputLayout = Google.Android.Material.TextField.TextInputLayout;

namespace ment_dsboard
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class ChangePasswordActivity : Activity
    {
        private TextInputLayout _textInputlayoutConfirmPassword , _textInputlayoutPassword, _textInputlayoutNewPassword;
        public EditText _editTextPassword, _editTextNewPassword, _editTextConfirmPassword;
        public TextView _textViewForgotPassword;
        public Button _buttonchangePassword;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.changePasswordLayout);

            _editTextPassword = FindViewById<EditText>(Resource.Id.oldPassEditText);
            _editTextNewPassword = FindViewById<EditText>(Resource.Id.NewPassEditText);
            _editTextConfirmPassword = FindViewById<EditText>(Resource.Id.confirmPassEditText);

            _textViewForgotPassword = FindViewById<TextView>(Resource.Id.Forgetpassword);

            _textInputlayoutConfirmPassword = FindViewById<TextInputLayout>(Resource.Id.confirmPassInputLayout);
            _textInputlayoutPassword = FindViewById<TextInputLayout>(Resource.Id.oldPassInputLayout);
            _textInputlayoutNewPassword = FindViewById<TextInputLayout>(Resource.Id.newPassInputLayout);

            _buttonchangePassword = FindViewById<Button>(Resource.Id.changePasswordBtn);

            _editTextConfirmPassword.TextChanged += _editTextConfirmPassword_TextChanged;
            _editTextNewPassword.TextChanged += _editTextNewPassword_TextChanged;
            _editTextPassword.TextChanged += _editTextPassword_TextChanged;

            _buttonchangePassword.Click += _buttonchangePassword_Click;
            _textViewForgotPassword.Click += _textViewForgotPassword_Click;
        }

        private void _textViewForgotPassword_Click(object sender, EventArgs e)
        {
             Intent FP = new Intent(this, typeof(ForgetPassword));
                StartActivity(FP);
            
        }

        private void _buttonchangePassword_Click(object sender, EventArgs e)
        {
            if (_editTextPassword.Text == "" && _editTextNewPassword.Text == "" && _editTextConfirmPassword.Text == "")
            {
                _textInputlayoutPassword.Error = "Please Enter-old Password";
                _textInputlayoutNewPassword.Error = "Please Enter-New Password";
                _textInputlayoutConfirmPassword.Error = "Please Re-enter Password";

            }

            else if (_editTextPassword.Text.Length < 8)
            {
                _textInputlayoutPassword.Error = "Must be at least 8 characters";
            }

            else if (_editTextNewPassword.Text.Length < 8)
            {
                _textInputlayoutNewPassword.Error = "Must be at least 8 characters";
            }

            else if (_editTextNewPassword.Text != _editTextConfirmPassword.Text)
            {

                _textInputlayoutConfirmPassword.Error = "Your NewPassword doesn't match with ConfirmPassword";
            }

            else
            {
                
                Toast.MakeText(this, "Password Change Successsfully", ToastLength.Short).Show();
                Finish();
            }

        }

        private void _editTextPassword_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            _textInputlayoutPassword.Error = null;
        }

        private void _editTextNewPassword_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            _textInputlayoutNewPassword.Error = null;
        }

        private void _editTextConfirmPassword_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if(_editTextNewPassword.Text != _editTextConfirmPassword.Text)
            {
                _textInputlayoutConfirmPassword.Error = "Please Re-enter Password";
            }
            else
            {
                _textInputlayoutConfirmPassword.Error = null;
            }
        }
    }
}