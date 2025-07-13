enum Department {
    HR = "HR",
    IT = "IT",
    Sales = "Sales"
}

interface Employee {
    EmployeeName: string;
    Age: number;
    department: Department;
    BaseSalary: number;
}

class EmployeeManagement {

    private employees: Employee[] = [];

    addEmployee(e: Employee): void {
        this.employees.push(e);
    }

    CalculateNetSalary(e: Employee): number {
        let bonus = 0;

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
    }

    categorizeEmployee(netSalary: number): string {
        if (netSalary >= 80000) {
            return "High Earner";
        } else if (netSalary >= 50000) {
            return "Mid Earner";
        } else {
            return "Low Earner";
        }
    }

    displayReport(): void {
        for (const emp of this.employees) {
            const netSalary = this.CalculateNetSalary(emp);
            const category = this.categorizeEmployee(netSalary);
            console.log(`Employee Name: ${emp.EmployeeName}`);
            console.log(`Age: ${emp.Age}`);
            console.log(`Department: ${emp.department}`);
            console.log(`Base Salary: ₹${emp.BaseSalary}`);
            console.log(`Net Salary (with bonus): ₹${netSalary}`);
            console.log(`Category: ${category}`);
            console.log('------------------------');
        }
    }
}

const manager = new EmployeeManagement();
manager.addEmployee({ EmployeeName: "Ravi", Age: 28, department: Department.IT, BaseSalary: 60000 });
manager.addEmployee({ EmployeeName: "Priya", Age: 32, department: Department.HR, BaseSalary: 8000 });
manager.addEmployee({ EmployeeName: "Arjun", Age: 26, department: Department.Sales, BaseSalary: 85000 });

manager.displayReport();
