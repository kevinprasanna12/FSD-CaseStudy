import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentComponent } from './student/student';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,StudentComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'Casestudy4';
}
