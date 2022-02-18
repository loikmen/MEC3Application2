using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MEC3AppSample.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using MEC3App.Model;

namespace MEC3AppSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        public Page1()
        {
            InitializeComponent();

        }


        public void LoginCheck(object sender, EventArgs e)
        {
            String inputName = nameEntry2.Text;
            String inputPassword = nameEntry3.Text;

            var model = GetLoginModel(inputName, inputPassword);

            var userName = model.userName;
            var email = model.userEmail;
            var data = model.data;
            var customerName = model.customerName;

            var user = new UserDto(data,email,userName,customerName);

            if (App.isLogged)
            {
                DisplayAlert("Oznámení", "Uživatel je již přihlášen", "OK");

            } else
            {
                if (user.data == "Ok")
                {
                   // DisplayAlert("Oznámení", "Úspěšně přihlášen", "OK");
                    App.isLogged = true;
                    var landingPage = new LandingPage();
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(landingPage, true);

                }
                else
                {
                    DisplayAlert("Oznámení", "Nesprávné jméno nebo heslo", "OK");
                    App.isLogged = false;
                  
                }

            }
                    
        }

        private User.Rootobject GetLoginModel(String username, String password)
        {
                String inputName = username;
                String inputPassword = password;
            
            var data ="{\"UserName\":\""+inputName +"\",\"Password\":\""+inputPassword+"\"}";

            var postData = data.ToString();

            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] byte1 = encoding.GetBytes(postData);
            var LoginModel = new User.Rootobject();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var requestObj = (HttpWebRequest)WebRequest.Create("https://www.mec3.cz/mec3mobile/UserMobile/LoginUser");
                requestObj.Method = "POST";
                requestObj.ContentType = "application/json; charset=utf-8";
                requestObj.ContentLength = byte1.Length;
                
          
                 Stream stream = requestObj.GetRequestStream();
                 stream.Write(byte1, 0, byte1.Length);

                
                var responseObj = (HttpWebResponse)requestObj.GetResponse();
                if (responseObj.StatusCode == HttpStatusCode.OK)
                {

                    using (stream = responseObj.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(stream);
                        var result = sr.ReadToEnd();
                        LoginModel = JsonConvert.DeserializeObject<User.Rootobject>(result);
                        sr.Close();
                    }                   
                }
                       
            return LoginModel;
            }

            async void returnHome(object sender, EventArgs e)
        {

            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation .PushAsync(landingPage, true);

        }

        protected override bool OnBackButtonPressed()
        {
            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(landingPage, true);

            return true;
        }

        async void pushBack(object sender, EventArgs e)
        {

            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(landingPage, true);
        }
    }
}