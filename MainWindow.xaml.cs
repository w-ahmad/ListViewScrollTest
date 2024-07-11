using Microsoft.UI.Xaml;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ListViewScrollTest;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var items = GetItems();
        listView.ItemsSource = Enumerable.Range(0, 2).SelectMany(x => items);
    }

    private static List<DataItem> GetItems()
    {
        return Enumerable.Range(1, 55).Select(x => new DataItem($"Item {x:N00}")).ToList();
    }

    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var item = listView.Items[100];
        listView.ScrollIntoView(item);
        listView.SelectedItem = item;
    }
}

public class DataItem(string name)
{
    public string Name { get; } = name;
}
