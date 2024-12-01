public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
    public ICollection<BusinessTrip> BusinessTrips { get; set; }
}
