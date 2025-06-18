using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo.Models;

namespace demo;

public partial class HistoryWindow : Window
{
    public HistoryWindow()
    {
        InitializeComponent();
    }
    
    public HistoryWindow(Partner partner)
    {
        InitializeComponent();
        HistoryListBox.ItemsSource = partner.PartnerProducts;
    }

    public double Calk(int productid, int materialid,int count, double param1, double param2)
    {
        return productid * materialid + count * param1 + param2 * param2;
    }
}