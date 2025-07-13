import { Component } from '@angular/core';
import { Student } from '../models/student.models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student.html',
  styleUrl: './student.scss'
})
export class StudentComponent {

  students : Student[] = [
  { name: 'John Doe', marks: 75, isActive: true },
  { name: 'Jane Smith', marks: 45, isActive: false },
  { name: 'Alice Johnson', marks: 90, isActive: true }]  

  getStatus(marks: number): string {
    return marks >= 50 ? ' Pass' : 'Fail';
  }

}
