using System.Windows;

namespace ProjectForCurs.View ;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.WindowState = WindowState.Maximized; 
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

        LoginWindow loginWindow = new()
        {
            Width = this.Width,
            Height = this.ActualHeight,
            WindowState = WindowState.Maximized
            
        };
        
        loginWindow.Show();
        this.Close();
    }
}

