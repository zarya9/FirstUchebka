using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FirstUchebka.Data;
using FirstUchebka.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstUchebka;

public partial class CreateAndChangeWindow : Window
{
    User thisSelectedUser;
    public CreateAndChangeWindow(User User)
    {
        InitializeComponent();
        FullNameText.Text = User.Name;
        PhoneNumber.Text= User.PhoneNumber;
        Description.Text = User.Description;
        RoleBox.SelectedItem = User.Role;
        thisSelectedUser = User;
        DataContext = new MainWindowViewModel();
    }
    public CreateAndChangeWindow()
    {
        InitializeComponent();
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var newUser = new User()
        {
            PhoneNumber = PhoneNumber.Text,
            Name = FullNameText.Text,
            Description = Description.Text,
            Role = RoleBox.SelectedItem as Role
        };
        if (thisSelectedUser == null)
        {
            
            App.DbContext.Add(newUser);
        }
        else
        {
            var userDb = App.DbContext.Users.FirstOrDefault(x => x.IdUsers == thisSelectedUser.IdUsers);
            userDb.PhoneNumber = PhoneNumber.Text;
            userDb.Name = FullNameText.Text;
            userDb.Description = Description.Text;
            userDb.Role = RoleBox.SelectedItem as Role;
            
        }
        App.DbContext.SaveChanges();
        this.Close();
    }
}