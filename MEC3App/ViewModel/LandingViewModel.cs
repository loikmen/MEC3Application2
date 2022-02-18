using MEC3AppSample.Model;
using MEC3AppSample.Views;
using Prism.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using MEC3AppSample;
using MEC3AppSample.Services;
using MEC3App.ViewModel;
using MEC3App.Views;
using Xamarin.Essentials;

namespace MEC3AppSample.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<BaseModel> RemoveCommand { get; }

        public event PropertyChangedEventHandler PropertyChange;

        private ImageSource imagePath;

        public ImageSource ImagePath { get => imagePath; set => PropertyChange(this, new PropertyChangedEventArgs("user.png")); }




        public LandingViewModel()
        {
            baseCards = GetBaseModels();
            imagePath = UserColorCheck();
        }

        public ObservableCollection<BaseModel> baseCards;
        public ObservableCollection<BaseModel> BaseCards
        {
            get { return baseCards; }
            set
            {
                baseCards = value;
                OnPropertyChanged();
            }
        }

        private BaseModel selectedCard;
        public BaseModel SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayBaseCard);


        private void DisplayBaseCard()
        {

            if (selectedCard != null)
            {

                if (selectedCard.Index == 100)
                {
                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {

                        var newViewModel = new CategoryViewModel(100, true) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 100;
        

                    } else {
                    

                        var newViewModel = new CategoryViewModel(100, false) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 100;

                    }   

                } else if (selectedCard.Index == 200)
                {
                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {

                        var newViewModel = new CategoryViewModel(200, true) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 200;

                    } else { 
                    

                        var newViewModel = new CategoryViewModel(200, false) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 200;
                    }



                    } else if(selectedCard.Index == 400){

                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {

                        var newViewModel = new CategoryViewModel(400, true) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 400;

                    } else { 
                    

                        var newViewModel = new CategoryViewModel(400, false) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 400;
                    }
               

                } else if (selectedCard.Index == 600){

                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {

                        var newViewModel = new CategoryViewModel(600, true) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 600;

                    } else { 
                    
                        var newViewModel = new CategoryViewModel(600, false) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 600;
                    }
                }
                else if (selectedCard.Index == 700){

                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {

                        var newViewModel = new CategoryViewModel(700, true) { };
                    var newPage = new CategoryPage { BindingContext = newViewModel };
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(newPage, true);
                        App.pageMonitor = 700;

                    } else { 
                    
                        var newViewModel = new CategoryViewModel(700, false) { };
                        var newPage = new CategoryPage { BindingContext = newViewModel };
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(newPage, true);
                        App.pageMonitor = 700;
                    }
                }
                else if (selectedCard.Index == 800){

                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {
                        var seminarsPage = new SeminarListPage();
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(seminarsPage, true);
                        App.pageMonitor = 800;

                    } else {

                        var seminarsPage = new SeminarListPage();
                        var navigation = Application.Current.MainPage as NavigationPage;
                        navigation.PushAsync(seminarsPage, true);
                        App.pageMonitor = 800;
                    }
                }
            }
        }


        private ObservableCollection<BaseModel> GetBaseModels()
        {

            return new ObservableCollection<BaseModel>
            {
                new BaseModel { Name = "Kopečková zmrzlina", Index = 100, Image = "icecream1.png"},
                new BaseModel { Name = "Točená zmrzlina", Index = 200, Image = "icecream2.png"},
                new BaseModel { Name = "Cukrařina", Index = 400, Image = "cake.png"},
                new BaseModel { Name = "Kakao a čokoláda", Index = 600, Image = "chocolate.png"},
                new BaseModel { Name = "Servisní položky", Index = 700, Image = "dough.png"},
                new BaseModel { Name = "Semináře seznam", Index = 800, Image = "presentation.png"}
            };
        }

        public String UserColorCheck()
        {
            
            if (App.isLogged)
            {
                return "user2Logged.png";
            }
            else
            {
                return "user.png";
            }
        }
       
    }
}