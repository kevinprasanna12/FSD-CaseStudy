import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { bootstrapApplication } from '@angular/platform-browser';
import { StudentFeedbackComponent } from './student-feedback/student-feedback';

bootstrapApplication(StudentFeedbackComponent);

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, StudentFeedbackComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'Casestudy7';
}
