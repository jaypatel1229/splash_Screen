using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace splash_screen
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ForgotPass : Activity
    {
        TextView forgotTextView;
        EditText newPassEditText, confirmPassEditText;
        Button DoneButton;    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forgotpass);

            UIReferences();
            UIClick();
            TextColor();
        }
        private void UIReferences()
        {
            forgotTextView = FindViewById<TextView>(Resource.Id.textViewForgot);       //Forgot Textview 

            newPassEditText = FindViewById<EditText>(Resource.Id.editTextNewPass);     //New Password EditText
            confirmPassEditText = FindViewById<EditText>(Resource.Id.editTextConfirmPass);  //Confirm Password EditText 

            DoneButton = FindViewById<Button>(Resource.Id.buttonDone);                 //Done button to Reset Password
        }

        private void UIClick()
        {
            DoneButton.Click += Reset_Click;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //if (editText1.Text == "" || editText2.Text == "")
            //{
            //    //Toast.MakeText(this, "Please fill the password and confirm password", ToastLength.Long).Show();
            //    editText1.Error = "Please fill the password and confirm password";
            //    editText2.Error = "Please fill the password and confirm password";
            //}
            if (newPassEditText.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Password", ToastLength.Short).Show();
                newPassEditText.Error = "Please Enter Password";
            }
            else if(confirmPassEditText.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Confirm Password", ToastLength.Short).Show();
                confirmPassEditText.Error = "Please Enter Confirm Password";
            }
            else if(newPassEditText.Text != confirmPassEditText.Text)
            {
                Toast.MakeText(this, "Password and confirm Password Not Same", ToastLength.Short).Show();               
            }
            else 
            {
                Toast.MakeText(this, "Password Reset Done", ToastLength.Short).Show();

                Intent c = new Intent(this, typeof(MainActivity));
                StartActivity(c);
            }            
        }
        private void TextColor()
        {
            TextPaint paint = forgotTextView.Paint;
            float width = paint.MeasureText(forgotTextView.Text);
            int[] vs = new int[]
            {
                Color.ParseColor("#5E07A6"),
                Color.ParseColor("#5E07A6"),
                Color.ParseColor("#5E07A6"),
                Color.ParseColor("#28A2F2"),
                Color.ParseColor("#28A2F2"),
            };
            Shader textShader = new LinearGradient(0, 0, width, forgotTextView.TextSize, vs, null, Shader.TileMode.Clamp);
            forgotTextView.Paint.SetShader(textShader);
        }
    }
}