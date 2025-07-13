import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface StudentFeedback {
  studentName: string;
  courseName: string;
  rating: number;
  comments: string;
}

@Component({
  selector: 'app-student-feedback',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './student-feedback.html',
  styleUrl: './student-feedback.scss',
})
export class StudentFeedbackComponent {
  feedback: StudentFeedback = {
    studentName: '',
    courseName: '',
    rating: 1,
    comments: ''
  };

  courses: string[] = ['Angular', 'React', 'Node.js', 'Python', 'Java'];
}
