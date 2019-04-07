Task1:
1. Implement a type Book encapsulating a book with the following fields: ISBN, Author, Title, Publisher, Publication year, and Price. 
There should be also developed a mechanism for reading and writing a collection of Books from and to a binary file, using only BinaryReader and BinaryWriter for IO operations. 
For the aforementioned collection, the following operations must be implemented:
 -AddBook, which adds a Book to the collection if the Book is not already there and throws an exception otherwise;
 -RemoveBook, which removes a present Book from the collection and throws an exception if the Book is not present in the collection;
 -SortBooksByTag, which sorts the collection in the order of a specified tag;
 -FindBookByTag, which returns the first Book with a specified value of a specified tag; if no such book exists, an exception is thrown.
2. Test using console application.

Task2:
1.Develop a type system for describing work with a bank account. Account is determined by its number, data on the account holder (name, surname), amount on the account and some bonus points that increase / decrease
each time when the account is refilled / debited from the account for values different for replenishment and write-off and calculated depending on some values
values of the "value" of the balance sheet and the "cost" of replenishment. 
The value of "cost" balance and “cost” of replenishment are integer values and depend on the gradation of the account, which may be, for example, Base, Gold, Platinum.
2. Test using console application.
