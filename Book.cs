using System;

namespace Jayremnt.Winform {
  public partial class Book {
    private string title;
    private string author;
    private string publicationDate;
    private string category;
    private string code;
    private string status;
    private string borrower;

    public Book(string Title = "", string Author = "", string PublicationDate = "", string Category = "", string Code = "", string Status = "Available", string Borrower = "None") {
      this.author = Author;
      this.publicationDate = PublicationDate;
      this.category = Category;
      this.code = Code;
      this.title = Title;
      this.status = Status;
      this.borrower = Borrower;
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

    public string Borrower {
      get { return borrower; }
      set { borrower = value; }
    }

    public static bool IsBooksExists(List<Book> books, string bookCodesToCheck) {
      if (bookCodesToCheck == null || bookCodesToCheck == "") return true;

      string[] bookCodes = bookCodesToCheck.Split(' ');

      bool isBookExists = false;
      for (int i = 0; i < bookCodes.Length; i++) {
        for (int j = 0; j < books.Count; j++) {
          if (books[j].Code == bookCodes[i]) {
            isBookExists = true;
            break;
          }
        }

        if (!isBookExists) {
          return false;
        }

        isBookExists = false;
      }

      return true;
    }

    public static bool IsBooksCheckedOut(List<Book> books, string booksToCheckedOut, string exceptionBorrower = "") {
      string[] checkedBooks = booksToCheckedOut.Split(' ');

      for (int i = 0; i < checkedBooks.Length; i++) {
        for (int j = 0; j < books.Count; j++) {
          if (checkedBooks[i].ToLower() == books[j].Code.ToLower()) {
            if (books[j].Status == "Checked out") {
              if (exceptionBorrower != "") {
                if (books[j].Borrower != exceptionBorrower) {
                  return true;
                }
              }
              else return true;
            }
          }
        }
      }

      return false;
    }

    public static List<Book> CheckOutBooks(List<Book> books, string booksToCheckedOut, string borrower) {
      string[] checkedOutBooks = booksToCheckedOut.Split(' ');

      for (int i = 0; i < books.Count; i++) {
        // First, return books checked out by this borrower 
        if (books[i].Borrower == borrower) {
          books[i].Status = "Available";
          books[i].Borrower = "None";
        }
        
        // Check out books
        for (int j = 0; j < checkedOutBooks.Length; j++) {
          if (checkedOutBooks[j].ToLower() == books[i].Code.ToLower()) {
            books[i].Status = "Checked out";
            books[i].Borrower = borrower;
            break;
          }
        }
      }

      return books;
    }

    public static List<Book> FindBooks(List<Book> books, string titleKey = "", string authorKey = "", string categoryKey = "", string publicationDateKey = "") {
      List<Book> results = new();

      for (int i = 0; i < books.Count; i++) {
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
