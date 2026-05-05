using System.Collections.ObjectModel;
using System.Linq;
using _1RM.Utils;

namespace _1RM.View.Workbench;

public class WorkbenchViewModel : NotifyPropertyChangedBaseScreen
{
    private bool _isSideBarVisible = true;
    private bool _isBottomPanelVisible;
    private string _activeActivityKey = "explorer";

    public ObservableCollection<WorkbenchActivityItem> Activities { get; } =
    [
        new WorkbenchActivityItem("explorer", "Explorer"),
        new WorkbenchActivityItem("search", "Search"),
        new WorkbenchActivityItem("tags", "Tags"),
        new WorkbenchActivityItem("connections", "Connections"),
        new WorkbenchActivityItem("settings", "Settings")
    ];

    public bool IsSideBarVisible
    {
        get => _isSideBarVisible;
        set => SetAndNotifyIfChanged(ref _isSideBarVisible, value);
    }

    public bool IsBottomPanelVisible
    {
        get => _isBottomPanelVisible;
        set => SetAndNotifyIfChanged(ref _isBottomPanelVisible, value);
    }

    public string ActiveActivityKey
    {
        get => _activeActivityKey;
        set
        {
            if (SetAndNotifyIfChanged(ref _activeActivityKey, value))
            {
                foreach (var item in Activities)
                    item.IsActive = item.Key == value;
            }
        }
    }

    public WorkbenchViewModel()
    {
        var first = Activities.FirstOrDefault();
        if (first != null)
            ActiveActivityKey = first.Key;
    }

    public void ToggleSideBar()
    {
        IsSideBarVisible = !IsSideBarVisible;
    }

    public void ToggleBottomPanel()
    {
        IsBottomPanelVisible = !IsBottomPanelVisible;
    }

    public void ActivateActivity(string key)
    {
        if (!string.IsNullOrWhiteSpace(key))
            ActiveActivityKey = key;
    }
}
