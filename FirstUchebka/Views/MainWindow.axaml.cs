using Avalonia.Controls;
using FirstUchebka.Data;
using FirstUchebka.ViewModels;

namespace FirstUchebka.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            MainContentControl.Content = new NewUserControl();
        }

        private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var createdChangeUserWindow = new CreateAndChangeWindow();
            await createdChangeUserWindow.ShowDialog(this);

            var viewModel = DataContext as MainWindowViewModel;
            viewModel.RefreshData();
        }

        private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var selectedUser = MainDataGridUsers.SelectedItem as User;
            if (selectedUser == null) return;

            var createdChangeUserWindow = new CreateAndChangeWindow(selectedUser);
            await createdChangeUserWindow.ShowDialog(this);

            var viewModel = DataContext as MainWindowViewModel;
            viewModel.RefreshData();
        }
    }
}