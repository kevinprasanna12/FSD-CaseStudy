import { Component } from '@angular/core';
import {CommonModule} from '@angular/common'
import {RouterModule} from '@angular/router';
import { Book } from '../../models/book.model';

@Component({
  selector: 'app-book-list',
  imports: [CommonModule,RouterModule],
  templateUrl: './book-list.html',
  styleUrls: ['./book-list.scss']
})
export class BookList {
  books: Book[] = [
    {
      id: 1,
      title: 'Angular Basics',
      author: 'John Doe',
      price: 399,
      description: 'Learn the fundamentals of Angular framework'
    },
    {
      id: 2,
      title: 'TypeScript Mastery',
      author: 'Max Programmer',
      price: 499,
      description: 'Deep dive into TypeScript and type safety'
    },
    {
      id: 3,
      title: 'RxJS Deep Dive',
      author: 'Jane Smith',
      price: 599,
      description: 'Master reactive programming with RxJS'
    }
  ];
}
