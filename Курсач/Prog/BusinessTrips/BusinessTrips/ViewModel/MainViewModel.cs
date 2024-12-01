using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

public class MainViewModel : ViewModelBase
{
    private readonly AppDbContext dbContext;

    public ObservableCollection<BusinessTrip> BusinessTrips { get; set; }
    public ICommand AddBusinessTripCommand { get; set; }

    public MainViewModel()
    {
        dbContext = new AppDbContext();
        BusinessTrips = new ObservableCollection<BusinessTrip>(dbContext.BusinessTrips.ToList());
        AddBusinessTripCommand = new RelayCommand(AddBusinessTrip);
    }

    private void AddBusinessTrip()
    {
        var newTrip = new BusinessTrip
        {
            Destination = "Новое место",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(5),
            Purpose = "Новая цель",
            EmployeeID = 1 // Пример данных
        };

        dbContext.BusinessTrips.Add(newTrip);
        dbContext.SaveChanges();
        BusinessTrips.Add(newTrip); // Обновляем коллекцию в интерфейсе
    }
}
