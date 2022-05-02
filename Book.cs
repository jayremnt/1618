using System;

namespace Jayremnt.Winform {
  public partial class Book {
    private int index;
    private string title;
    private string author;
    private string publicationDate;
    private string category;
    private string code;
    private string status;

    public Book(int Index = 0, string Title = "", string Author = "", string PublicationDate = "", string Category = "", string Code = "", string Status = "Available") {
      this.author = Author;
      this.publicationDate = PublicationDate;
      this.category = Category;
      this.code = Code;
      this.index = Index;
      this.title = Title;
      this.status = Status;
    }

    public int Index {
      get { return index; }
      set { index = value; }
    }

    public string Title {
      get { return title; }
      set { title = value; }
    }

    public string Author {
      get { return author; }
      set { author = value; }
    }

    public string PublicationDate {
      get { return publicationDate; }
      set { publicationDate = value; }
    }

    public string Category {
      get { return category; }
      set { category = value; }
    }

    public string Code {
      get { return code; }
      set { code = value; }
    }

    public string Status {
      get { return status; }
      set { status = value; }
    }

    public bool IsBookExists(Book[] books, int booksLength, string BookCode) {
      bool isBookExists = false;

      for (int i = 0; i < booksLength; i++) {
        if (books[i].Code == BookCode) {
          isBookExists = true;
          break;
        }
      }

      return isBookExists;
    }

    public bool IsBooksCheckedOut(Book[] books, int booksLength, string booksToCheckedOut) {
      string[] subs = booksToCheckedOut.Split(' ');

      for (int i = 0; i < subs.Count(); i++) {
        for (int j = 0; j < booksLength; j++) {
          if (subs[i].ToLower() == books[j].Code.ToLower()) {
            if (books[j].status == "Checked out") return true;
          }
        }
      }

      return false;
    }

    public Book[] checkOutBooks(Book[] books, int booksLength, string booksToCheckedOut) {
      string[] subs = booksToCheckedOut.Split(' ');

      for (int i = 0; i < subs.Count(); i++) {
        for (int j = 0; j < booksLength; j++) {
          if (subs[i].ToLower() == books[j].Code.ToLower()) {
            books[j].status = "Checked out";
            break;
          }
        }
      }

      return books;
    }

    public Book[] returnBooks(Book[] books, int booksLength, string booksToReturn) {
      string[] subs = booksToReturn.Split(' ');

      for (int i = 0; i < subs.Count(); i++) {
        for (int j = 0; j < booksLength; j++) {
          if (subs[i].ToLower() == books[j].Code.ToLower()) {
            books[j].status = "Available";
            break;
          }
        }
      }

      return books;
    }

    public List<Book> findBooks(Book[] books, int booksLength, string titleKey = "", string authorKey = "", string categoryKey = "", string publicationDateKey = "") {
      List<Book> results = new List<Book>();

      for (int i = 0; i < booksLength; i++) {
        if (books[i].Title.ToLower().Contains(titleKey.ToLower())
          && books[i].Author.ToLower().Contains(authorKey.ToLower())
          && books[i].Category.ToLower().Contains(categoryKey.ToLower())
          && books[i].PublicationDate.ToLower().Contains(publicationDateKey.ToLower())) {
          results.Add(books[i]);
        }
      }

      return results;
    }
  }
}
