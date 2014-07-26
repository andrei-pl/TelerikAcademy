/// <reference path="bower_components/underscore/underscore.js" />
(function () {
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('bower_components/underscore/underscore.js');
    }

    //By a given collection of books, find the most popular author (the author with the highest number of books)

    var Book = (function () {

        function Book(book, author) {
            this.author = author;
            this.book = book;
        }

        return Book;
    }());

    var books = [
            new Book('Lord of the rings', 'J.R.R. Tolkien'),
            new Book('Lord of the rings', 'J.R.R. Tolkien'),
            new Book('Harry Potter and the Philospopher`s Stone', ' J. K. Rowling'),
            new Book('Harry Potter and the Chamber of Secrets', ' J. K. Rowling'),
            new Book('Harry Potter and the Prisoner of Azkaban', ' J. K. Rowling'),
            new Book('Harry Potter and the Goblet of Fire', ' J. K. Rowling'),
            new Book('Harry Potter and the Order of the Phoenix', ' J. K. Rowling'),
            new Book('Harry Potter and the Half-Blood Prince', ' J. K. Rowling'),
            new Book('Harry Potter and the Deathly Hallows', ' J. K. Rowling'),
            new Book('The Kite Runner', ' Khaled Hosseini')
    ];

   // var groupAuthors = _.groupBy(books, "author");
   // var sortAuthors = _.sortBy(groupAuthors, function (author) {
   //     return author.length;
   // });
   // var mostPopularAuthor = _.last(sortAuthors);
   // console.log(mostPopularAuthor[0].author + " is the most popular author");

    var res = _.countBy(books, 'author'),
     maxIndex = _.max(res),
     maxAuthor = _.invert(res)[maxIndex];

    console.log(maxAuthor + ' is the most popular author with ' + maxIndex + ' books in the collection.');
}())