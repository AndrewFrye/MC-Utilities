using System;
using ButtonData;

namespace ClientApplication.ViewModels;

public class MainViewModel : ViewModelBase
{
    private EnhancedList<string> ConsoleLog { get; }
    public MainViewModel()
    {
        ConsoleText = "The Text Block is Empty";
        ConsoleLog = new();
        ConsoleLog.ItemAdded += OnLogDataAdded;
    }

    private void OnLogDataAdded(object? sender, DataEventArgs e)
    {
        if (ConsoleLog.Count > 1000)
        {
            ConsoleLog.RemoveAt(0);
        }
        UpdateConsoleText();
    }

    public void OnTestButtonClick()
    {
        ConsoleLog.Add("Test");
    }

    public string ConsoleText => UpdateConsoleText();

    private string UpdateConsoleText()
    {
        var str = "";
        for (int i = 0; i < ConsoleLog.Count; i++)
        {
            str += ConsoleLog.GetAt(i) + "\n";
        }

        return str;
    }
}