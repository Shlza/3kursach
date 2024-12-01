-- Создание таблицы "Employees" для хранения информации о сотрудниках
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Position NVARCHAR(50),
    Department NVARCHAR(50)
);

-- Создание таблицы "BusinessTrips" для хранения информации о командировочных удостоверениях
CREATE TABLE BusinessTrips (
    TripID INT PRIMARY KEY,
    EmployeeID INT,
    Destination NVARCHAR(100),
    StartDate DATETIME,
    EndDate DATETIME,
    Purpose NVARCHAR(255),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- Создание таблицы "Users" для хранения информации о пользователях системы
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(50),
    Password NVARCHAR(255),
    Role NVARCHAR(50)
);
