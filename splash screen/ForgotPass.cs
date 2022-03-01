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
    [Activity(Label = "ForgotPass")]
    public class ForgotPass : Activity
    {
        Button btn;
        EditText editText1, editText2;
        TextView txtForgot;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forgotpass);

            UIReferences();
            UIClick();

            TextPaint paint = txtForgot.Paint;
            float width = paint.MeasureText(txtForgot.Text);

            int[] vs = new int[]
            {
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#28A2F2"),
                        Color.ParseColor("#28A2F2"),
            };
            Shader textShader = new LinearGradient(0, 0, width, txtForgot.TextSize,vs, null, Shader.TileMode.Clamp);
            txtForgot.Paint.SetShader(textShader);
        }
        private void UIReferences()
        {
            btn = FindViewById<Button>(Resource.Id.forgotPassword);
            editText1 = FindViewById<EditText>(Resource.Id.newpass);
            editText2 = FindViewById<EditText>(Resource.Id.confirmpass);

            txtForgot = FindViewById<TextView>(Resource.Id.forgottxt);
        }

        private void UIClick()
        {
            btn.Click += Reset_Click;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //if (editText1.Text == "" || editText2.Text == "")
            //{
            //    //Toast.MakeText(this, "Please fill the password and confirm password", ToastLength.Long).Show();
            //    editText1.Error = "Please fill the password and confirm password";
            //    editText2.Error = "Please fill the password and confirm password";
            //}
            if (editText1.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Password", ToastLength.Short).Show();
                editText1.Error = "Please Enter Password";
            }
            else if(editText2.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Confirm Password", ToastLength.Short).Show();
                editText2.Error = "Please Enter Confirm Password";
            }
            else if(editText1.Text != editText2.Text)
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
    }
}