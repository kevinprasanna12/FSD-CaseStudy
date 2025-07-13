import { Component } from '@angular/core';
import { ICourse } from '../models/Course.models';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-course',
  standalone:true,
  imports: [CommonModule],
  templateUrl: './course.html',
  styleUrls: ['./course.scss']
})
export class CourseComponent {
  courses : ICourse[] = 
  [
    {
      title: "Angular Mastery",
      instructor: "John Doe",
      date: new Date("2025-08-01"),
      price: 199.99,
      description: "Learn Angular from basics to advanced with hands-on projects."
  },
  {
      title: "TypeScript Essentials",
      instructor: "Jane Smith",
      date: new Date("2025-07-15"),
      price: 99.99,
      description: "A complete guide to mastering TypeScript for scalable web apps."
  },
  {
      title: "Web API Development",
      instructor: "Kevin Prasanna",
      date: new Date("2025-09-05"),
      price: 149.99,
      description: "Build secure and clean Web APIs using .NET Core and best practices."
  }

  ]
}
