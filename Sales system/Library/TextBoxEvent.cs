using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace Sales_system.Library
{
    public static class TextBoxEvent
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static void textPreviewKeyDown(KeyRoutedEventArgs e)
        {
            var code = e.KeyStatus;

            //Solo alfanumericos
            if(71 <= code.ScanCode && 83 > code.ScanCode 
                || 2 <= code.ScanCode && 11 >= code.ScanCode)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public static void numberPreviewKeyDown(KeyRoutedEventArgs e)
        {
            var code = e.KeyStatus;

            //Solo numeros
            if (71 <= code.ScanCode && 83 > code.ScanCode 
                || 2 <= code.ScanCode && 11 >= code.ScanCode 
                || 14 == code.ScanCode)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
