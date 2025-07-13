import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CourseComponent } from './course/course';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CourseComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'Casestudy6';
}
