using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using demo.Context;
using demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo;

public partial class MainWindow : Window
{
    private List<Partner> partners = Helper.Database.Partners
        .Include(x => x.PartnerType)
        .Include(x => x.PartnerProducts)
        .ThenInclude(x => x.Product).ToList();
    public MainWindow()
    {
        InitializeComponent();

        PartnerListBox.ItemsSource = partners;
    }

    private void Button_OnClick_History(object? sender, RoutedEventArgs e)
    {
        var partner = PartnerListBox.SelectedItem as Partner;
        if (partner != null)
        {
            HistoryWindow historyWindow = new HistoryWindow(partner);
            historyWindow.ShowDialog(this);
        }
    }
    
    private void Button_OnClick_Add(object? sender, RoutedEventArgs e)
    {
        PartnerWindow clientWindow = new PartnerWindow();
        clientWindow.Show();
        Close();
    }

    private void InputElement_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        var partner = PartnerListBox.SelectedItem as Partner;
        if (partner != null)
        {
            PartnerWindow clientWindow = new PartnerWindow(partner);
            clientWindow.Show();
            Close();
        }
    }
}