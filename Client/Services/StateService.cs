using System;

public class StateContainer
{
    private bool showDrawer;
    private string appTitle;
    private string currentPage;

    public Boolean ShowDrawer
    {
        get => showDrawer;
        set
        {
            showDrawer = value;
            NotifyStateChanged();
        }
    }

    public String AppTitle
    {
        get => appTitle;
        set
        {
            appTitle = value;
            NotifyStateChanged();
        }
    }

    public String CurrentPage
    {
        get => currentPage;
        set
        {
            currentPage = value;
            NotifyStateChanged();
        }
    }

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}