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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",MainLauncher =false)]
    public class MainActivity : AppCompatActivity
    {       
        TextView createAcc,forgotPass,loginText;
        EditText user_editText, password_editText;
        Button loginButton,registerButton;
        ImageView facebook_imageView,google_imageView;
        Regex UserRegex = new Regex("^[a-z-A-Z- ]*$");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClick();
            TextColor();          
        }

        private void UIReferences()
        {
            loginText = FindViewById<TextView>(Resource.Id.textViewLogin);                 //Login Text For Colors 

            createAcc = FindViewById<TextView>(Resource.Id.textViewCreateAcc);             //TextView1
            forgotPass = FindViewById<TextView>(Resource.Id.textViewForgotPass);           //TextView2


            user_editText = FindViewById<EditText>(Resource.Id.editTextUser);               //EditText1
            password_editText = FindViewById<EditText>(Resource.Id.editTextPassword);       //EditText2

            loginButton = FindViewById<Button>(Resource.Id.buttonLogin);                    //Login Button
            registerButton = FindViewById<Button>(Resource.Id.buttonRegister);              //Register Buttton

            facebook_imageView = FindViewById<ImageView>(Resource.Id.imageViewfacebook);    //Facebook 
            google_imageView = FindViewById<ImageView>(Resource.Id.imageViewgoogle);        //Google
        }

        private void UIClick()
        {
            createAcc.Click += Register_Click;
            forgotPass.Click += Forgot_Click;

            loginButton.Click += Login_Click;
            registerButton.Click += RegisterA_Click;

            facebook_imageView.Click += facebook_Click;
            google_imageView.Click += google_Click;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Register));
            StartActivity(i);
        }

        private void Forgot_Click(object sender, EventArgs e)
        {
            Intent a = new Intent(this, typeof(ForgotPass));
            StartActivity(a);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if(user_editText.Text == "" && password_editText.Text == "")
            {
                //Toast.MakeText(this, "Please Enter Details", ToastLength.Short).Show();
                user_editText.Error = "Please Enter Details";
                password_editText.Error = "Please Enter Details";
            }
            else if(user_editText.Text == "")
            {
                //Toast.MakeText(this, "Please Fill the Username", ToastLength.Short).Show();
                user_editText.Error = "Please Fill the Username";
            }
            else if (!ValidateUser(user_editText.Text))
            {
                //Toast.MakeText(this, "Number are Not Allow in Username", ToastLength.Short).Show();
                user_editText.Error = "Number are Not Allow in Username";
            }
            else if(password_editText.Text == "")
            {
                //Toast.MakeText(this, "Please Fill the Password", ToastLength.Short).Show();
                password_editText.Error = "Please Fill the Password";
            }
            else if(password_editText.Text.Length<8 )
            {
                //Toast.MakeText(this, "Length of Password is Under 8", ToastLength.Short).Show();
                password_editText.Error = "Length of Password is Under 8";
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
        private void RegisterA_Click(object sender, EventArgs e)
        {
            Intent R = new Intent(this, typeof(Register));
            StartActivity(R);
        }

        private void facebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this,"Are You Login With Facebook?",ToastLength.Short).Show();
        }

        private void google_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Are You Login With Google?", ToastLength.Short).Show();
        }

        private void TextColor()
        {
            TextPaint paint = LoginText.Paint;
            float width = paint.MeasureText(LoginText.Text);
            int[] vs = new int[]{
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#5E07A6"),
                        Color.ParseColor("#28A2F2"),
                        Color.ParseColor("#28A2F2"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, LoginText.TextSize, vs, null, Shader.TileMode.Clamp);
            LoginText.Paint.SetShader(textShader);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
    }
}