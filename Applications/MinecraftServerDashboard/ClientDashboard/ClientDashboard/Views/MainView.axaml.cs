using Avalonia.Controls;

namespace ClientDashboard.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainView();
    }
}