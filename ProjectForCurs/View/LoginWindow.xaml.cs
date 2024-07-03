using System.Windows;
using ProjectForCurs.ViewModel;

namespace ProjectForCurs.View;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();

        DataContext = new LoginViewModel(this);
    }
}
