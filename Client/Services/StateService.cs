using System;
using DoctorAppWeb.Shared.DataModel.MedOrganization;
public class StateContainer
{
    private bool showDrawer;
    private string appTitle = "";
    private string currentPage;
    private Patient currentPatient = null;
    private Patient prevPatient = null;

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

    public Patient CurrentPatient
    {
        get => currentPatient;
        set
        {
            currentPatient = value;
            if (value != null)
            {
                prevPatient = value;
            }
            NotifyStateChanged();
        }
    }

    public Patient PreviousPatient
    {
        get => prevPatient;
    }

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}