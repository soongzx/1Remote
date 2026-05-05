using _1RM.Utils;

namespace _1RM.View.Workbench;

public class WorkbenchActivityItem : NotifyPropertyChangedBaseScreen
{
    private bool _isActive;

    public string Key { get; }
    public string Label { get; }

    public bool IsActive
    {
        get => _isActive;
        set => SetAndNotifyIfChanged(ref _isActive, value);
    }

    public WorkbenchActivityItem(string key, string label)
    {
        Key = key;
        Label = label;
    }
}
