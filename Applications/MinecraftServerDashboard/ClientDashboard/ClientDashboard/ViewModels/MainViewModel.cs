using System;
using System.Reactive;
using Avalonia.Interactivity;
using ButtonData;
using ReactiveUI;

namespace ClientDashboard.ViewModels;

public class MainViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static

    private EnhancedList<string> LogLines = new();
    
    public MainViewModel()
    {
        LogLines.ItemAdded += OnLogDataAdded;
        
    }

    
    private void OnTestButtonClick()
    {
        Console.WriteLine("Test");
        
    }

    private void OnLogDataAdded(object? sender, DataEventArgs e)
    {
        if (LogLines.Count > 1000)
        {
            LogLines.RemoveAt(0);
        }
    }
}