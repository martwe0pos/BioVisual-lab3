using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace lab3;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public ObservableCollection<Employee> Employees { get; } = [];
    
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    
    public async void addEm(object sender, RoutedEventArgs e)
    {
        var dod = new dodaj(this);
        await dod.ShowDialog<Employee>(this); 
    }

    public void delEm(object sender, RoutedEventArgs e)
    {
        var select = Grid.SelectedItem as Employee;
        Employees.Remove(select);
        foreach (var employee in Employees)
        {
            if (employee.Id > select.Id) employee.Id--;
        }
    }
    
    private async void saveCSV(object sender, RoutedEventArgs e) {
        var saveFileDialog = new SaveFileDialog();
        var res = await saveFileDialog.ShowAsync(this);
        if (res != null)
        {
            using (var stream = new StreamWriter(res)) { 
                foreach (var em in Employees) { 
                    await stream.WriteLineAsync($"{em.Id},{em.Name},{em.Surname},{em.Age},{em.Position}");
                }
            }
        }
    }
    private async void loadCSV(object sender, RoutedEventArgs e) {
        Employees.Clear();
        var OpenFileDialog = new OpenFileDialog(); 
        var result = await OpenFileDialog.ShowAsync(this);
        if (result != null)
        {
            string file;
            using (var stream = new StreamReader(result[0])) { 
                while ((file = await stream.ReadLineAsync()) != null)
                {
                    var dane = file.Split(',');
                    var newEm = new Employee {
                        Id = Convert.ToInt32(dane[0]), 
                        Name = dane[1], 
                        Surname = dane[2], 
                        Age = dane[3],
                        Position = dane[4]
                    };
                    Employees.Add(newEm);
                }
            }
        }
    }
}