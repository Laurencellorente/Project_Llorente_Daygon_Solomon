# Database Overview (`lycevm.db`)

SQLite database for managing employees, customers, and support tickets.

## Tables

### Departments
* **Id** (Primary Key)
* **Name** (Text)

### Employees
* **Id** (Primary Key)
* **FirstName** (Text)
* **LastName** (Text)
* **Email** (Text)
* **DepartmentId** (Foreign Key -> Departments)

### Customers
* **Id** (Primary Key)
* **FullName** (Text)
* **Email** (Text)

### Tickets
* **Id** (Primary Key)
* **Title** (Text)
* **Description** (Text)
* **Status** (Open, In Progress, Closed)
* **Priority** (Low, Normal, High)
* **CustomerId** (Foreign Key -> Customers)
* **AssignedEmployeeId** (Foreign Key -> Employees)