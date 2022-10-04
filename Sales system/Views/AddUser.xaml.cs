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
using Sales_system.ViewModels;
using Sales_system.Library;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sales_system.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddUser : Page
    {
        public AddUser()
        {
            this.InitializeComponent();
            Object[] campos = { NID, Name, LastName, Telephone, Email, Password, User };
            this.DataContext = new UserViewModel(campos);
        }

        private void NID_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBoxEvent.numberPreviewKeyDown(e);
        }

        private void Name_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBoxEvent.textPreviewKeyDown(e);
        }

        private void LastName_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBoxEvent.textPreviewKeyDown(e);
        }

        private void Telephone_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBoxEvent.numberPreviewKeyDown(e);
        }
    }
}
