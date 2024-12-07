using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AreaCirculoAppMvvm.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public const double PI = 3.1415926535897931;

    private string? _radio;
    private string? _resultado;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string? Radio
    {
        get => _radio;
        set
        {
            _radio = value;
            OnPropertyChanged();
        }
    }

    public string? Resultado
    {
        get => _resultado;
        set
        {
            _resultado = value;
            OnPropertyChanged();
        }
    }

    public ICommand CalcularAreaCommand { get; }
    public ICommand LimpiarCommand { get; }

    public MainViewModel()
    {
        CalcularAreaCommand = new Command(CalcularArea);
        LimpiarCommand = new Command(Limpiar);
    }

    private void CalcularArea()
    {
        if (double.TryParse(Radio, out double radio) && radio > 0)
        {
            double area = PI * Math.Pow(radio, 2);
            Resultado = $"Área: {area:F2}";
        }
        else
        {
            Resultado = "Por favor, ingrese un número válido.";
        }
    }

    private void Limpiar()
    {
        Radio = string.Empty;
        Resultado = string.Empty;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
