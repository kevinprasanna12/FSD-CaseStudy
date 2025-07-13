import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../../models/book.model';

@Component({
  selector: 'app-book-details',
  imports: [CommonModule],
  templateUrl: './book-details.html',
  styleUrls: ['./book-details.scss']
})
export class BookDetails {
  private route = inject(ActivatedRoute);
  book: Book | undefined;

  ngOnInit() {
    const books: Book[] = [
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

    const bookId = Number(this.route.snapshot.paramMap.get('id'));
    this.book = books.find(book => book.id === bookId);
  }
}
