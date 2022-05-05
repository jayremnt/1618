using Jayremnt.Winform;

namespace librarymanager {
  public partial class LibraryManager : Form {
    private List<Book> books = new();
    private List<Member> members = new();

    public LibraryManager() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      this.books.Add(new Book("Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "1"));
      this.books.Add(new Book("Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "2"));
      this.books.Add(new Book("Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "3"));
      this.books.Add(new Book("Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "4"));
      this.books.Add(new Book("Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "5"));
      this.books.Add(new Book("Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "6"));
      this.members.Add(new Member("Bao", "20/06/2003", "GCH210135", "GCH1006", "545342", "432423423"));

      this.RefreshDGVBooks();
      this.RefreshDGVMembers();
    }

    private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0) {
        DataGridViewRow row = this.dataGridViewBooks.Rows[e.RowIndex];
        string index = (e.RowIndex + 1).ToString();
        string title = row.Cells["Title"].Value.ToString();
        string author = row.Cells["Author"].Value.ToString();
        string publicationDate = row.Cells["PublicationDate"].Value.ToString();
        string category = row.Cells["Category"].Value.ToString();
        string code = row.Cells["Code"].Value.ToString();
        string status = row.Cells["Status"].Value.ToString();
        string borrower = row.Cells["Borrower"].Value.ToString();

        this.FillBookTextBoxes(index, title, author, publicationDate, category, code, status, borrower);
      }
    }

    private void dataGridViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0) {
        DataGridViewRow row = this.dataGridViewMembers.Rows[e.RowIndex];
        string index = (e.RowIndex + 1).ToString();
        string name = row.Cells["Name"].Value.ToString();
        string dateOfBirth = row.Cells["DateOfBirth"].Value.ToString();
        string studentID = row.Cells["StudentID"].Value.ToString();
        string className = row.Cells["ClassName"].Value.ToString();
        string phoneNumber = row.Cells["PhoneNumber"].Value.ToString();
        string email = row.Cells["Email"].Value.ToString();
        string checkedOutBooks = row.Cells["CheckedOutBooks"].Value.ToString();

        this.FillMemberTextBoxes(index, name, dateOfBirth, studentID, className, phoneNumber, email, checkedOutBooks);
      }
    }

    private void btnUpdateBook_Click(object sender, EventArgs e) {
      if (textBoxBookIndex.Text != null && textBoxBookIndex.Text != "") {
        int index = Int32.Parse(textBoxBookIndex.Text);
        string title = textBoxBookTitle.Text;
        string author = textBoxBookAuthor.Text;
        string publicationDate = textBoxBookPublicationDate.Text;
        string category = textBoxBookCategory.Text;
        string code = textBoxBookCode.Text;
        string status = textBoxBookStatus.Text;
        string borrower = textBoxBookBorrower.Text;

        if (this.books[index - 1].Code != code && Book.IsBooksExists(this.books, code)) {
          labelHandleBookStatus.Text = "* Book exists";
          labelHandleBookStatus.ForeColor = Color.Red;
        }
        else {
          this.books[index - 1] = new Book(title, author, publicationDate, category, code, status, borrower);
          labelHandleBookStatus.Text = "* Updated book";
          labelHandleBookStatus.ForeColor = Color.Blue;
        }

        this.RefreshDGVBooks();
      }
      else {
        labelHandleBookStatus.Text = "* Can not update this book";
        labelHandleBookStatus.ForeColor = Color.Red;
      }
    }

    private void btnUpdateMember_Click(object sender, EventArgs e) {
      if (textBoxMemberIndex.Text != null && textBoxMemberIndex.Text != "") {
        int index = Int32.Parse(textBoxMemberIndex.Text);
        string name = textBoxMemberName.Text;
        string dateOfBirth = textBoxMemberDateOfBirth.Text;
        string studentID = textBoxMemberStudentID.Text;
        string className = textBoxMemberClassName.Text;
        string phoneNumber = textBoxMemberPhoneNumber.Text;
        string email = textBoxMemberEmail.Text;
        string checkedOutBooks = textBoxMemberCheckedOutBooks.Text;

        if (this.members[index - 1].StudentID != studentID && Member.IsMemberExists(this.members, studentID)) {
          labelHandleMemberStatus.Text = "* Member exists";
          labelHandleMemberStatus.ForeColor = Color.Red;
        }
        else if (!Book.IsBooksExists(this.books, checkedOutBooks)) {
          labelHandleMemberStatus.Text = "* Some books do not exist";
          labelHandleMemberStatus.ForeColor = Color.Red;
        }
        else if (Book.IsBooksCheckedOut(this.books, checkedOutBooks, studentID)) {
          labelHandleMemberStatus.Text = "* Some books were checked out.";
          labelHandleMemberStatus.ForeColor = Color.Red;
        } 
        else {
          this.books = Book.CheckOutBooks(this.books, checkedOutBooks, studentID);
          this.members[index - 1] = new Member(name, dateOfBirth, studentID, className, phoneNumber, email, checkedOutBooks);
          labelHandleMemberStatus.Text = "* Updated member";
          labelHandleMemberStatus.ForeColor = Color.Blue;
        }

        this.RefreshDGVBooks();
        this.RefreshDGVMembers();
      }
      else {
        labelHandleMemberStatus.Text = "* Can not update this member";
        labelHandleMemberStatus.ForeColor = Color.Red;
      }
    }

    private void btnDeleteBook_Click(object sender, EventArgs e) {
      if (textBoxBookIndex.Text != null && textBoxBookIndex.Text != "") {
        int bookIndex = Int32.Parse(textBoxBookIndex.Text) - 1;
        this.books.RemoveAt(bookIndex);

        this.RefreshDGVBooks();
        this.FillBookTextBoxes();
      }
      else {
        labelHandleBookStatus.Text = "* Can not delete this book";
        labelHandleBookStatus.ForeColor = Color.Red;
      }
    }

    private void btnDeleteMember_Click(object sender, EventArgs e) {
      if (textBoxMemberIndex.Text != null && textBoxMemberIndex.Text != "") {
        int memberIndex = Int32.Parse(textBoxMemberIndex.Text) - 1;
        this.members.RemoveAt(memberIndex);

        this.RefreshDGVMembers();
        this.RefreshDGVBooks();
        this.FillMemberTextBoxes();
      }
      else {
        labelHandleBookStatus.Text = "* Can not delete this member";
        labelHandleBookStatus.ForeColor = Color.Red;
      }
    }

    private void btnAddBook_Click(object sender, EventArgs e) {
      string title = textBoxBookTitle.Text;
      string author = textBoxBookAuthor.Text;
      string publicationDate = textBoxBookPublicationDate.Text;
      string category = textBoxBookCategory.Text;
      string code = textBoxBookCode.Text;

      if (title == "" || author == "" || publicationDate == "" || category == "" || code == "") {
        labelHandleBookStatus.Text = "* Please fill out all fields";
        labelHandleBookStatus.ForeColor = Color.Red;
      }
      else {
        // add book
        if (Book.IsBooksExists(this.books, code)) {
          labelHandleBookStatus.Text = "* Book exists";
          labelHandleBookStatus.ForeColor = Color.Red;
        }
        else {
          books.Add(new Book(title, author, publicationDate, category, code, "Available"));

          this.RefreshDGVBooks();

          labelHandleBookStatus.Text = "* Successfully added new book!";
          labelHandleBookStatus.ForeColor = Color.Blue;
        }
      }
    }

    private void btnAddMember_Click(object sender, EventArgs e) {
      string name = textBoxMemberName.Text;
      string dateOfBirth = textBoxMemberDateOfBirth.Text;
      string studentID = textBoxMemberStudentID.Text;
      string className = textBoxMemberClassName.Text;
      string phoneNumber = textBoxMemberPhoneNumber.Text;
      string email = textBoxMemberEmail.Text;
      string checkedOutBooks = textBoxMemberCheckedOutBooks.Text;

      if (name == "" || dateOfBirth == "" || studentID == "" || className == "" || phoneNumber == "" || email == "") {
        labelHandleMemberStatus.Text = "* Please fill out all fields";
        labelHandleMemberStatus.ForeColor = Color.Red;
      }
      else {
        // add member
        if (Member.IsMemberExists(this.members, studentID)) {
          labelHandleMemberStatus.Text = "* Member exists";
          labelHandleMemberStatus.ForeColor = Color.Red;
        }
        else if (!Book.IsBooksExists(this.books, checkedOutBooks)) {
          labelHandleMemberStatus.Text = "* Some books do not exist";
          labelHandleMemberStatus.ForeColor = Color.Red;
        }
        else if (Book.IsBooksCheckedOut(this.books, checkedOutBooks)) {
          labelHandleMemberStatus.Text = "* Some books were checked out.";
          labelHandleMemberStatus.ForeColor = Color.Red;
        }
        else {
          this.members.Add(new Member(name, dateOfBirth, studentID, className, phoneNumber, email, checkedOutBooks));
          this.books = Book.CheckOutBooks(this.books, checkedOutBooks, studentID);

          this.RefreshDGVMembers();
          this.RefreshDGVBooks();
          this.FillMemberTextBoxes();

          labelHandleMemberStatus.Text = "* Successfully added new member!";
          labelHandleMemberStatus.ForeColor = Color.Blue;
        }
      }
    }

    private void btnFindBooks_Click(object sender, EventArgs e) {
      string bookTitle = textBoxFindBooksByTitle.Text;
      string bookAuthor = textBoxFindBooksByAuthor.Text;
      string bookCategory = textBoxFindBooksByCategory.Text;
      string bookPublicationDate = textBoxFindBooksByPublicationDate.Text;

      List<Book> results = Book.FindBooks(this.books, bookTitle, bookAuthor, bookCategory, bookPublicationDate);

      if (results.Count > 0) {
        labelNoResult.Visible = false;
        dataGridViewFindBooks.Visible = true;
        dataGridViewFindBooks.DataSource = results;
        dataGridViewFindBooks.Refresh();
      }
      else {
        labelNoResult.Visible = true;
        dataGridViewFindBooks.Visible = false;
        dataGridViewFindBooks.Refresh();
      }
    }

    private void FillBookTextBoxes(string index = "", string title = "", string author = "", string publicationDate = "", string category = "", string code = "", string status = "", string borrower = "") {
      textBoxBookIndex.Text = index;
      textBoxBookTitle.Text = title;
      textBoxBookAuthor.Text = author;
      textBoxBookPublicationDate.Text = publicationDate;
      textBoxBookCategory.Text = category;
      textBoxBookCode.Text = code;
      textBoxBookStatus.Text = status;
      textBoxBookBorrower.Text = borrower;
    }

    private void FillMemberTextBoxes(string index = "", string name = "", string dateOfBirth = "", string studentID = "", string className = "", string phoneNumber = "", string email = "", string checkedOutBooks = "") {
      textBoxMemberIndex.Text = index;
      textBoxMemberName.Text = name;
      textBoxMemberDateOfBirth.Text = dateOfBirth;
      textBoxMemberStudentID.Text = studentID;
      textBoxMemberClassName.Text = className;
      textBoxMemberPhoneNumber.Text = phoneNumber;
      textBoxMemberEmail.Text = email;
      textBoxMemberCheckedOutBooks.Text = checkedOutBooks;
    }

    private void RefreshDGVBooks() {
      dataGridViewBooks.DataSource = null;
      dataGridViewBooks.DataSource = this.books;
      dataGridViewBooks.Refresh();
    }

    private void RefreshDGVMembers() {
      dataGridViewMembers.DataSource = null;
      dataGridViewMembers.DataSource = this.members;
      dataGridViewMembers.Refresh();
    }
  }
}