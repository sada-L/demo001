using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using demo.Context;
using demo.Models;

namespace demo;

public partial class PartnerWindow : Window
{
    private Partner CurrentPartner;

    public PartnerWindow()
    {
        InitializeComponent();
        CurrentPartner = new Partner();
        PartnerPanel.DataContext = CurrentPartner;
        TypeBox.ItemsSource = Helper.Database.PartnerTypes;
        TypeBox.SelectedIndex = 0;
    }

    public PartnerWindow(Partner partner)
    {
        InitializeComponent();
        CurrentPartner = partner;
        PartnerPanel.DataContext = CurrentPartner;
        TypeBox.ItemsSource = Helper.Database.PartnerTypes;
        TypeBox.SelectedItem = CurrentPartner.PartnerType;
    }

    private void Button_OnClick_Save(object? sender, RoutedEventArgs e)
    {
        CurrentPartner.PartnerType = TypeBox.SelectedItem as PartnerType;
        
        if (CurrentPartner.Rate > 0)
        {
            if (CurrentPartner.PartnerId == 0)
            {
                Helper.Database.Partners.Add(CurrentPartner);
                Helper.Database.SaveChanges();
            }
            else
            {
                Helper.Database.Partners.Update(CurrentPartner);
                Helper.Database.SaveChanges();
            }
             
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
        else
        {
            Error.Text = "Ошибка";
        }
    }
    
    private void Button_OnClick_Back(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}