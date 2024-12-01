public class BusinessTrip
{
    public int TripID { get; set; }
    public int EmployeeID { get; set; }
    public string Destination { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Purpose { get; set; }
    public Employee Employee { get; set; } // Связь с сотрудником
}
