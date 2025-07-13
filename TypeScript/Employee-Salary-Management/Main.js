var Department;
(function (Department) {
    Department["HR"] = "HR";
    Department["IT"] = "IT";
    Department["Sales"] = "Sales";
})(Department || (Department = {}));
var EmployeeManagement = /** @class */ (function () {
    function EmployeeManagement() {
        this.employees = [];
    }
    EmployeeManagement.prototype.addEmployee = function (e) {
        this.employees.push(e);
    };
    EmployeeManagement.prototype.CalculateNetSalary = function (e) {
        var bonus = 0;
        switch (e.department) {
            case Department.HR:
                bonus = 0.10;
                break;
            case Department.IT:
                bonus = 0.15;
                break;
            case Department.Sales:
                bonus = 0.12;
                break;
        }
        return e.BaseSalary + (e.BaseSalary * bonus);
    };
    EmployeeManagement.prototype.categorizeEmployee = function (netSalary) {
        if (netSalary >= 80000) {
            return "High Earner";
        }
        else if (netSalary >= 50000) {
            return "Mid Earner";
        }
        else {
            return "Low Earner";
        }
    };
    EmployeeManagement.prototype.displayReport = function () {
        for (var _i = 0, _a = this.employees; _i < _a.length; _i++) {
            var emp = _a[_i];
            var netSalary = this.CalculateNetSalary(emp);
            var category = this.categorizeEmployee(netSalary);
            console.log("Employee Name: ".concat(emp.EmployeeName));
            console.log("Age: ".concat(emp.Age));
            console.log("Department: ".concat(emp.department));
            console.log("Base Salary: \u20B9".concat(emp.BaseSalary));
            console.log("Net Salary (with bonus): \u20B9".concat(netSalary));
            console.log("Category: ".concat(category));
            console.log('------------------------');
        }
    };
    return EmployeeManagement;
}());
var manager = new EmployeeManagement();
manager.addEmployee({ EmployeeName: "Ravi", Age: 28, department: Department.IT, BaseSalary: 60000 });
manager.addEmployee({ EmployeeName: "Priya", Age: 32, department: Department.HR, BaseSalary: 8000 });
manager.addEmployee({ EmployeeName: "Arjun", Age: 26, department: Department.Sales, BaseSalary: 85000 });
manager.displayReport();
