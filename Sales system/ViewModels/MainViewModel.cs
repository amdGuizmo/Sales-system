using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Connection;
using Windows.UI.Xaml;
using Sales_system.Views;

namespace Sales_system.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {

        }

        public void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args
            , Frame contentFrame)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            switch(item.Tag)
            {
                case "Close":
                    SQLiteConnections.DeleteData();
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(Login));
                    break;
                case "User":
                    contentFrame.Navigate(typeof(Usuarios));
                    break;
            }
        }
    }
}
