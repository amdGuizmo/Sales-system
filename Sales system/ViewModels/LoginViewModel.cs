﻿using Sales_system.Library;
using Sales_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Connection;
using Models;


namespace Sales_system.ViewModels
{
    public class LoginViewModel : UserModel
    {
        private ICommand _command;
        private TextBox _textBoxEmail;
        private PasswordBox _textBoxPass;
        private ProgressRing _progressRing;
        private string date = DateTime.Now.ToString("dd/MM//yyy");
        private Frame rootFrame = Window.Current.Content as Frame;
        private Connections _conn;
        //private SQLiteConnections _sqlite;

        public LoginViewModel(object[] campos)
        {
            _textBoxEmail = (TextBox)campos[0];
            _textBoxPass = (PasswordBox)campos[1];
            _progressRing = (ProgressRing)campos[2];
            _conn = new Connections();
            //_sqlite = new SQLiteConnections();
            //var pass = Encrypt.EncryptData("1234", "AMD.GUIZMO@GMAIL.COM");
        }

        public ICommand IniciarCommand
        {
            get
            {
                return _command ?? (_command = new CommandHandler(async () =>
                {
                    await iniciarAsync();
                }));
            }
        }

        private async Task iniciarAsync()
        {
            if (Email == null || Email.Equals(""))
            {
                EmailMessage = "Ingrese el email";
                _textBoxEmail.Focus(FocusState.Programmatic);
            }
            else
            {
                if (TextBoxEvent.IsValidEmail(Email))
                {
                    if (Password == null || Password.Equals(""))
                    {
                        PasswordMessage = "Ingrese el password";
                        _textBoxPass.Focus(FocusState.Programmatic);
                    }
                    else
                    {
                        try
                        {
                            var user = _conn.TUsers.Where(u => u.Email.Equals(Email)).ToList();

                            if (0 < user.Count)
                            {
                                _progressRing.IsActive = true;
                                var pass = Encrypt.DecryptData(user[0].Password, Email);
                                if (pass.Equals(Password))
                                {
                                    var dataUser = user.ElementAt(0);
                                    dataUser.Date = DateTime.Now.ToString("dd/MMM/yyy");
                                    SQLiteConnections.AddData(dataUser);
                                    rootFrame.Navigate(typeof(MainPage));
                                }
                                else
                                {
                                    _progressRing.IsActive = false;
                                    Message = "Contraseña o email incorrectos";
                                }
                            }
                            else
                            {
                                _progressRing.IsActive = false;
                                Message = "Contraseña o email incorrectos";
                            }
                        }
                        catch (Exception ex)
                        {
                            Message = ex.Message;
                        }
                        finally
                        {
                            _progressRing.IsActive = false;
                        }
                    }
                }
                else
                {
                    EmailMessage = "El email no es valido";
                    _textBoxEmail.Focus(FocusState.Programmatic);
                }

            }
        }
    }
}
