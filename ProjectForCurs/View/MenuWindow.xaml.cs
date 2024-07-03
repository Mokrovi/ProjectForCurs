using ProjectForCurs.View;
using System.Windows;
using System.Windows.Documents;

namespace ProjectForCurs;

public partial class MenuWindow : Window
{
    private int NowWindow = 0;
    public MenuWindow()
    {
        InitializeComponent();        
        
        Arrow.Visibility = Visibility.Hidden;
    }

    private void Promocode_Click(object sender, RoutedEventArgs e)
    {
        var page = new PagePromocode();        
        ContentFrame.Navigate(page);
    }
    private void Content_Click(object sender, RoutedEventArgs e)
    {
        var page = new PageContent1();
        ContentFrame.Navigate(page);
    }
    private void Subscribe_Click(object sender, RoutedEventArgs e)
    {
        var page = new PageSubs();
        ContentFrame.Navigate(page);
    }
    private void User_Click(object sender, RoutedEventArgs e)
    {
        var page = new PageUser();
        ContentFrame.Navigate(page);
    }
    private void Worker_Click(object sender, RoutedEventArgs e)
    {
        var page = new PageWorker();
        ContentFrame.Navigate(page);
    }
    private void Arrow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        Arrow.Visibility = Visibility.Hidden;
        NowWindow = 0;
    }

}
