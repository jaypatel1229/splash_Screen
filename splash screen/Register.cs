using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace splash_screen
{
    [Activity(Label = "Register", Theme = "@style/AppTheme",MainLauncher =false)]
    
    public class Register : Activity
    {
        TextView textRegister;
        ImageView imageView1, imageView2;
        EditText editText1, editText2, editText3, editText4;
        Button button1;
        Regex EmailRegex = new Regex(@"^[a-z]([\w\.\-]+)@([\w\-]+)((\.)+)com|edu|in|org|net$+");
        //Regex EmailRegex = new Regex(@"^[a-z]([\w]*[\w\.]*(?!\.)@gmail.com");
        Regex UserRegex = new Regex("^[a-z-A-Z- .]*$");

        //Regex UserRegex = new Regex("^[a-z-A-Z -,.()][^0-9]*$");
        //Regex EmailRegex = new Regex(@"^[a-z]([\w\.\-]+)@([\w\-]+)((\.(\w){3,3})+)$+");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            UIReferences();
            UIClick();
            TextPaint paint = textRegister.Paint;
            float width = paint.MeasureText(textRegister.Text);

            int[] vs = new int[]{
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#28A2F2"),
                        Color.ParseColor("#28A2F2"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, textRegister.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            textRegister.Paint.SetShader(textShader);
        }

        private void UIReferences()
        {
            editText1 = FindViewById<EditText>(Resource.Id.loguser);
            editText2 = FindViewById<EditText>(Resource.Id.emailtxt);
            editText3 = FindViewById<EditText>(Resource.Id.username);
            editText4 = FindViewById<EditText>(Resource.Id.passwordUser);

            imageView1 = FindViewById<ImageView>(Resource.Id.facebook1);
            imageView2 = FindViewById<ImageView>(Resource.Id.google1);

            button1 = FindViewById<Button>(Resource.Id.register);

            textRegister = FindViewById<TextView>(Resource.Id.texRegister);
        }

        private void UIClick()
        {
            imageView1.Click += facebook_Click;
            imageView2.Click += google_Click;

            button1.Click += Register_Click;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if(editText1.Text == "" && editText2.Text == "" && editText3.Text == "" && editText4.Text == "")
            {
                Toast.MakeText(this, "Please Enter the Details", ToastLength.Short).Show();
                editText1.Error = "Please Enter the Details";
                editText2.Error = "Please Enter the Details";
                editText3.Error = "Please Enter the Details";
                editText4.Error = "Please Enter the Details";
            }
            else if(editText1.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Name of User", ToastLength.Short).Show();
                editText1.Error = "Please Enter Name of User";
            }
            else if(!ValidateUser(editText1.Text))
            {
                //Toast.MakeText(this, "You Can not write Number in Name", ToastLength.Long).Show();
                editText1.Error = "You Can not write Number in Name";
            }
            //else if(editText2.Text == "" && PatternMatcher)
            //{
            //    Toast.MakeText(this, "Please Enter the Email", ToastLength.Short).Show();
            //}
            else if(editText2.Text == "")
            {
                //Toast.MakeText(this, "Please fill the Email", ToastLength.Short).Show();
                editText2.Error = "Please fill the Email";
            }
            else if(!ValidateEmail(editText2.Text))
            {
                //Toast.MakeText(this, "Please Enter Valid email", ToastLength.Short).Show();
                editText2.Error = "Please Enter Valid email";
            }
            else if (editText3.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Username", ToastLength.Short).Show();
                editText3.Error = "Please Enter Username";
            }
            else if (!ValidateUser(editText3.Text))
            {
                //Toast.MakeText(this, "Number are Not Allow in Username", ToastLength.Long).Show();
                editText3.Error = "Number are Not Allow in Username";
            }
            else if(editText4.Text == "")
            {
                //Toast.MakeText(this, "Please Entert Password", ToastLength.Long).Show();
                editText4.Error = "Please Entert Password";
            }
            else if (editText4.Text.Length < 8)
            {
                //Toast.MakeText(this, "Password length is Under 8", ToastLength.Long).Show();
                editText4.Error = "Password length is Under 8";
            }
            else
            {
                Toast.MakeText(this, "Register Successfully", ToastLength.Short).Show();
                Intent l = new Intent(this, typeof(MainActivity));
                StartActivity(l);
                Finish();
            }
          

            //if (editText4.Text == "" && editText3.Text == "" && editText2.Text == "" && editText1.Text == "")
            //{
            //    Toast.MakeText(this, "Please Entert the Name of User", ToastLength.Long).Show();
            //}
            //else if (editText3.Text == "" && editText2.Text == "" && editText1.Text == "")
            //{
            //    Toast.MakeText(this, "Please Enter the Email", ToastLength.Short).Show();
            //}
            //else if (editText2.Text == "" && editText1.Text == "")
            //{
            //    Toast.MakeText(this, "Please Enter Username", ToastLength.Short).Show();
            //}
            //else if (editText1.Text == "")
            //{
            //    Toast.MakeText(this, "Please Enter the Password", ToastLength.Short).Show();
            //}
            //else
            //{
            //    Intent l = new Intent(this, typeof(MainActivity));
            //    StartActivity(l);
            //}

            //Toast.MakeText(this, "Register Successfully", ToastLength.Short).Show();
        }
        bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }
        bool ValidateUser(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
                return false;

            return UserRegex.IsMatch(user);
        }

        private void facebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Are You Register With Facebook?",ToastLength.Short).Show();
        }

        private void google_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Are You Register With Google?", ToastLength.Short).Show();
        }
    }
}