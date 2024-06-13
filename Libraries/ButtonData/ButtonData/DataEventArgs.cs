namespace ButtonData;

public class DataEventArgs : EventArgs
{
    public object? Data;

    public DataEventArgs(object? item)
    {
        Data = item;
    }
}