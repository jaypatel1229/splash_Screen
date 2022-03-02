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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",MainLauncher =false)]
    
    public class Register : Activity
    {
        TextView RegisterTextView;
        ImageView facebookImageView, googleImageView;
        EditText editNameOfUser, editEmail, editUserName, editPassword;
        Button RegisterButton;
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
            TextColor();
        }

        private void UIReferences()
        {
            RegisterTextView = FindViewById<TextView>(Resource.Id.textViewRegister);   //Register TextView

            editNameOfUser = FindViewById<EditText>(Resource.Id.editTextNameUser);     //EditText for Name Of User
            editEmail = FindViewById<EditText>(Resource.Id.editTextEmail);             //EditText for Email
            editUserName = FindViewById<EditText>(Resource.Id.editTextUserName);       //EditText for UserName
            editPassword = FindViewById<EditText>(Resource.Id.editTextPassword);       //EditText for Password

            facebookImageView = FindViewById<ImageView>(Resource.Id.imageViewFaceBook);  //ImageView For Facebook
            googleImageView = FindViewById<ImageView>(Resource.Id.imageViewGoogle);      //imageView For 

            RegisterButton = FindViewById<Button>(Resource.Id.buttonRegister);          //Button for Register       
        }
        private void UIClick()
        {
            facebookImageView.Click += facebook_Click;
            googleImageView.Click += google_Click;

            RegisterButton.Click += Register_Click;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if(editNameOfUser.Text == "" && editEmail.Text == "" && editUserName.Text == "" && editPassword.Text == "")
            {
                Toast.MakeText(this, "Please Enter the Details", ToastLength.Short).Show();
                editNameOfUser.Error = "Please Enter the Details";
                editEmail.Error = "Please Enter the Details";
                editUserName.Error = "Please Enter the Details";
                editPassword.Error = "Please Enter the Details";
            }
            else if(editNameOfUser.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Name of User", ToastLength.Short).Show();
                editNameOfUser.Error = "Please Enter Name of User";
            }
            else if(!ValidateUser(editNameOfUser.Text))
            {
                //Toast.MakeText(this, "You Can not write Number in Name", ToastLength.Long).Show();
                editNameOfUser.Error = "You Can not write Number in Name";
            }
            //else if(editText2.Text == "" && PatternMatcher)
            //{
            //    Toast.MakeText(this, "Please Enter the Email", ToastLength.Short).Show();
            //}
            else if(editEmail.Text == "")
            {
                //Toast.MakeText(this, "Please fill the Email", ToastLength.Short).Show();
                editEmail.Error = "Please fill the Email";
            }
            else if(!ValidateEmail(editEmail.Text))
            {
                //Toast.MakeText(this, "Please Enter Valid email", ToastLength.Short).Show();
                editEmail.Error = "Please Enter Valid email";
            }
            else if (editUserName.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Username", ToastLength.Short).Show();
                editUserName.Error = "Please Enter Username";
            }
            else if (!ValidateUser(editUserName.Text))
            {
                //Toast.MakeText(this, "Number are Not Allow in Username", ToastLength.Long).Show();
                editUserName.Error = "Number are Not Allow in Username";
            }
            else if(editPassword.Text == "")
            {
                //Toast.MakeText(this, "Please Entert Password", ToastLength.Long).Show();
                editPassword.Error = "Please Entert Password";
            }
            else if (editPassword.Text.Length < 8)
            {
                //Toast.MakeText(this, "Password length is Under 8", ToastLength.Long).Show();
                editPassword.Error = "Password length is Under 8";
            }
            else
            {
                Toast.MakeText(this, "Register Successfully", ToastLength.Short).Show();
                Intent l = new Intent(this, typeof(MainActivity));
                StartActivity(l);
                Finish();
            }          
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

        private void TextColor()
        {
            TextPaint paint = RegisterTextView.Paint;
            float width = paint.MeasureText(RegisterTextView.Text);

            int[] vs = new int[]{
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#28A2F2"),
                        Color.ParseColor("#28A2F2"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, RegisterTextView.TextSize, vs, null, Shader.TileMode.Clamp);
            RegisterTextView.Paint.SetShader(textShader);
        }
    }
}