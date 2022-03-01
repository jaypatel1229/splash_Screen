using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Text.RegularExpressions;

namespace splash_screen
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        EditText editText1,editText2;
        TextView textView3, textView5, txtLogin;
        Button button1,button2;
        ImageView imageView1,imageView2;
        Regex UserRegex = new Regex("^[a-z-A-Z- ]*$");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClick();
            

            TextPaint paint = txtLogin.Paint;
            float width = paint.MeasureText(txtLogin.Text);

            int[] vs = new int[]{
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#28A2F2"),
                        Color.ParseColor("#28A2F2"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, txtLogin.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            txtLogin.Paint.SetShader(textShader);
        }

        private void UIReferences()
        {
            textView3 = FindViewById<TextView>(Resource.Id.textView4);
            textView5 = FindViewById<TextView>(Resource.Id.forgotpass);


            editText1 = FindViewById<EditText>(Resource.Id.loginUser);
            editText2 = FindViewById<EditText>(Resource.Id.passwordUser);
            button1 = FindViewById<Button>(Resource.Id.loginBtn);
            button2 = FindViewById<Button>(Resource.Id.registerBtn);

            imageView1 = FindViewById<ImageView>(Resource.Id.facebook);
            imageView2 = FindViewById<ImageView>(Resource.Id.google);

            txtLogin = FindViewById<TextView>(Resource.Id.textView1);
        }

        private void UIClick()
        {
            textView3.Click += Register_Click;
            textView5.Click += Forgot_Click;

            button1.Click += Login_Click;
            button2.Click += RegisterA_Click;

            imageView1.Click += facebook_Click;
            imageView2.Click += google_Click;
        }
       

        private void Login_Click(object sender, EventArgs e)
        {
            if(editText1.Text == "" && editText2.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Details", ToastLength.Short).Show();
                editText1.Error = "Please Enter Details";
                editText2.Error = "Please Enter Details";
            }
            else if(editText1.Text == "")
            {                        
                //Toast.MakeText(this, "Please Fill the Username", ToastLength.Short).Show();
                editText1.Error = "Please Fill the Username";
            }
            else if (!ValidateUser(editText1.Text))
            {
                //Toast.MakeText(this, "Number are Not Allow in Username", ToastLength.Short).Show();
                editText1.Error = "Number are Not Allow in Username";
            }
            else if(editText2.Text == "")
            {
                //Toast.MakeText(this, "Please Fill the Password", ToastLength.Short).Show();
                editText2.Error = "Please Fill the Password";
            }
            else if(editText2.Text.Length<8 )
            {
                //Toast.MakeText(this, "Length of Password is Under 8", ToastLength.Short).Show();
                editText2.Error = "Length of Password is Under 8";
            }
            else
            {
                Toast.MakeText(this, "Login Successfully", ToastLength.Short).Show();
                //Finish();
            }           
        }
        bool ValidateUser(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
                return false;

            return UserRegex.IsMatch(user);
        }


        private void facebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this,"Are You Login With Facebook?",ToastLength.Short).Show();
        }

        private void google_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Are You Login With Google?", ToastLength.Short).Show();
        }

        private void RegisterA_Click(object sender, EventArgs e)
        {
            Intent R = new Intent(this, typeof(Register));
            StartActivity(R);
        }

        private void Forgot_Click(object sender, EventArgs e)
        {
            Intent a = new Intent(this, typeof(ForgotPass));
            StartActivity(a);
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this,typeof(Register));
            StartActivity(i);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}