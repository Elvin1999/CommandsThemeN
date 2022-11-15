using Commands.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MessageCommand MessageCommand { get; set; }
        //public SendCommand SendCommand { get; set; }

        //public string SomeText
        //{
        //    get { return (string)GetValue(SomeTextProperty); }
        //    set { SetValue(SomeTextProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SomeText.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SomeTextProperty =
        //    DependencyProperty.Register("SomeText", typeof(string), typeof(MainWindow));


        //public MainWindow()
        //{
        //    InitializeComponent();

        //    SomeText = string.Empty;
        //    this.DataContext = this;

        //    MessageCommand = new MessageCommand(() =>
        //    {
        //        MessageBox.Show("Message Displaying");
        //    });

        //    SendCommand = new SendCommand(() =>
        //    {
        //        MessageBox.Show("Message was sent successfully");
        //    }, SomeText);
        //}





        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(MainWindow));



        public RelayCommand ShowCommand { get; set; }
        public RelayCommand UsernameEnterCommand { get; set; }
        public RelayCommand PasswordEnterCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //ShowCommand = new RelayCommand((e) =>
            //{
            //    MessageBox.Show("Hello World");
            //});


            ShowCommand = new RelayCommand((e) =>
            {
                MessageBox.Show("Hello World");
            }, p =>
            {
                return Age >= 18;
            });





            UsernameEnterCommand = new RelayCommand((e) =>
            {
                var myStackPanel = e as StackPanel;
                var usernameTxtB = myStackPanel.Children[0] as TextBox;
                if (usernameTxtB.Text.Trim() == String.Empty)
                {
                    usernameTxtB.BorderBrush = Brushes.Red;
                    usernameTxtB.BorderThickness = new Thickness(6);
                }
                else
                {
                    usernameTxtB.BorderThickness = new Thickness(2);
                    usernameTxtB.BorderBrush = Brushes.SpringGreen;
                    var passwordTxtB = myStackPanel.Children[1] as TextBox;
                    passwordTxtB.Focus();
                }
                //var txtB = e as TextBox;
                //txtB.Focus();
            });


            PasswordEnterCommand = new RelayCommand((e) =>
            {
                var btn = e as Button;
                btn.Focus();
            });

            this.DataContext = this;


        }

    }
}
