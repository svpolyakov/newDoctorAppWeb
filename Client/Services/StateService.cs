using System;
using DoctorAppWeb.Shared.DataModel.Application;
using DoctorAppWeb.Shared.DataModel.MedOrganization;
public class StateContainer
{
    private bool showDrawer;
    private string appTitle = "";
    private string currentPage;
    private Patient currentPatient = null;
    private Patient prevPatient = null;
    private InfoWindow info = null;
    private InfoWindow prevInfo = null;
    private int personsFilterType = 0;
    private string userName = "";

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

    public InfoWindow InfoWindow
    {
        get => info; set
        {
            info = value;
            if (value != null)
            {
                prevInfo = value;
            }
            NotifyStateChanged();
        }
    }

    public int PersonsFilterType
    {
        get => personsFilterType; set
        {
            personsFilterType = value;
            NotifyStateChanged();
        }
    }

    public string UserName
    {
        get => userName; set
        {
            userName = value;
            NotifyStateChanged();
        }
    }

    public InfoWindow PrevInfoWindow
    {
        get => prevInfo;
    }

    public Patient PreviousPatient
    {
        get => prevPatient;
    }

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}