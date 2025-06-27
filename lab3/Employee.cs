using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3;

public class Employee : INotifyPropertyChanged
{
    public string _name, _surname, _age, _position;
    public int _id;
    public int Id
    {
        get => _id; 
        set { _id = value; OnPropertyChanged(); }
    }

    public string Name
    {
        get => _name; 
        set { _name = value; OnPropertyChanged(); }
    }

    public string Surname
    {
        get => _surname; 
        set{ _surname = value; OnPropertyChanged(); }
    }

    public string Age
    {
        get => _age; 
        set{ _age = value; OnPropertyChanged(); }
    }
    public string Position
    {
        get => _position; 
        set{ _position = value; OnPropertyChanged(); }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}