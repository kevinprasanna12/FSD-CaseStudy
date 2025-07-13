import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeComponent } from './employee/employee';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,EmployeeComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'Casestudy5';
}
