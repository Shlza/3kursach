using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using System.Linq;

public class LoginViewModel : ViewModelBase
{
    private readonly AppDbContext dbContext;

    public string Username { get; set; }
    public string Password { get; set; }
    public ICommand LoginCommand { get; set; }

    public LoginViewModel()
    {
        dbContext = new AppDbContext();
        LoginCommand = new RelayCommand(Login);
    }

    private void Login()
    {
        var user = dbContext.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
        if (user != null)
        {
            MessageBox.Show("Успешный вход!", "Авторизация");
            // Логика для открытия главного окна после успешной авторизации
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закрыть окно авторизации
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w is LoginWindow)?.Close();
        }
        else
        {
            MessageBox.Show("Неверные учетные данные", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
