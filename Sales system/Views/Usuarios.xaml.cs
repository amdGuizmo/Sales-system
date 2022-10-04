using Sales_system.Models;
using Sales_system.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sales_system.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Usuarios : Page
    {
        private UserViewModel users;
        public Usuarios()
        {
            this.InitializeComponent();
            users = new UserViewModel(Paginas, RefreshContainer);
            DataContext = users;
        }

        private void ListViewUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserModel selected = (UserModel)ListViewUsers.SelectedItem;
            users.SelectedUser = selected;
            App.mContentFrame.Navigate(typeof(AddUser));
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            users.AlignmentMenuFlyoutItem(sender);
        }

        private void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
        {
            users.GetUserAsync();
        }
    }
}
