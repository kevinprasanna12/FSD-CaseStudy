import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { BookDetails } from './components/book-details/book-details';
import { BookList } from './components/book-list/book-list';

export const routes: Routes = [
    { path: '', component: Home, title: 'Home' },
    { path: 'books', component: BookList, title: 'Book List' },
    { path: 'books/:id', component: BookDetails, title: 'Book Details' },
    { path: '**', redirectTo: '' }
];
