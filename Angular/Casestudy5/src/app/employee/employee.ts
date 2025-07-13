import { Component } from '@angular/core'
import { IEmployee } from '../models/employee.models'
import { CommonModule } from '@angular/common'

@Component({
  selector: 'app-employee',
  imports: [CommonModule],
  templateUrl: './employee.html',
  styleUrls: ['./employee.scss']
})
export class EmployeeComponent {
  employees : IEmployee [] = [
    { name: 'Alice', department: 'IT', isPresent: true, workfromhome: false },
    { name: 'Bob', department: 'HR', isPresent: false, workfromhome: true },
    { name: 'Charlie', department: 'Sales', isPresent: false, workfromhome: false }
  ]
}
