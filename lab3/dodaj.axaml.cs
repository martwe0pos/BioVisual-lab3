using Avalonia.Controls;
using Avalonia.Interactivity;

namespace lab3;
public partial class dodaj : Window
{
    public string posTemp = "";
    private MainWindow win;
    public dodaj(MainWindow mainWindow)
    {
        InitializeComponent();
        win = mainWindow;
    }

    public void posSel(object sender, RoutedEventArgs e)
    {
        if (sender is ComboBox box)
        {
            if (box.SelectedItem is ComboBoxItem item)
            {
                posTemp = item.Content.ToString();
            }
        }
    }
    public void confirm(object sender, RoutedEventArgs e)
    {
        var prac = new Employee
        {
            Id = win.Employees.Count + 1,
            Name = nameBox.Text,
            Surname = surBox.Text,
            Age = ageBox.Text,
            Position = posTemp
        };
        win.Employees.Add(prac);
        Close();
    }
    
    public void cancel(object sender, RoutedEventArgs e)
    {
        Close();
    }
}