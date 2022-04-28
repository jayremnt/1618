using Jayremnt.Winform;

namespace librarymanager {
  public partial class LibraryManager : Form {
    private Book[] books = new Book[1000];
    private Member[] members = new Member[1000];
    private int booksLength = 0;
    private int membersLength = 0;

    public LibraryManager() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      books[0] = new Book(1, "Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "GW1001");
      booksLength++;
      members[0] = new Member(1, "Bao", "20/06/2003", "GCH210135", "GCH1006", "545342", "432423423", "GW1111 GW2222");
      membersLength++;

      dataGridViewBooks.DataSource = books;
      dataGridViewMembers.DataSource = members;
    }

    private void btnAddBook_Click(object sender, EventArgs e) {
      string title = textBoxAddBookTitle.Text;
      string author = textBoxAddBookAuthor.Text;
      string publicationDate = textBoxAddBookPublicationDate.Text;
      string category = textBoxAddBookCategory.Text;
      string code = textBoxAddBookCode.Text;

      if (title == "" || author == "" || publicationDate == "" || category == "" || code == "") {
        labelAddBookStatus.Text = "* Please fill out all fields";
        labelAddBookStatus.Visible = true;
        labelAddBookStatus.ForeColor = Color.Red;
      }
      else {
        // add book
        if (new Book().IsBookExists(books, booksLength, code)) {
          labelAddBookStatus.Text = "* Book exists";
          labelAddBookStatus.Visible = true;
          labelAddBookStatus.ForeColor = Color.Red;
        }
        else {
          labelAddBookStatus.Text = "* Successfully added new book!";
          labelAddBookStatus.Visible = true;
          labelAddBookStatus.ForeColor = Color.Blue;
          books[booksLength] = new Book(++booksLength, title, author, publicationDate, category, code);
        }
      }
    }

    private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0) {
        DataGridViewRow row = this.dataGridViewBooks.Rows[e.RowIndex];
        textBoxAllBookIndex.Text = row.Cells["Index"].Value.ToString();
        textBoxAllBookTitle.Text = row.Cells["Title"].Value.ToString();
        textBoxAllBookAuthor.Text = row.Cells["Author"].Value.ToString();
        textBoxAllBookPublicationDate.Text = row.Cells["PublicationDate"].Value.ToString();
        textBoxAllBookCategory.Text = row.Cells["Category"].Value.ToString();
        textBoxAllBookCode.Text = row.Cells["Code"].Value.ToString();
      }
    }

    private void btnUpdateBook_Click(object sender, EventArgs e) {
      int index = Int32.Parse(textBoxAllBookIndex.Text);
      string title = textBoxAllBookTitle.Text;
      string author = textBoxAllBookAuthor.Text;
      string publicationDate = textBoxAllBookPublicationDate.Text;
      string category = textBoxAllBookCategory.Text;
      string code = textBoxAllBookCode.Text;

      if (books[index - 1].Code != code) {
        if (new Book().IsBookExists(books, booksLength, code)) {
          labelUpdateBookStatus.Text = "* Book exists";
          labelUpdateBookStatus.Visible = true;
          labelUpdateBookStatus.ForeColor = Color.Red;
        }
        else {
          books[index - 1] = new Book(index, title, author, publicationDate, category, code);
          labelUpdateBookStatus.Text = "* Updated book";
          labelUpdateBookStatus.Visible = true;
          labelUpdateBookStatus.ForeColor = Color.Blue;
        }
      }
      else {
        books[index - 1] = new Book(index, title, author, publicationDate, category, code);
        labelUpdateBookStatus.Text = "* Updated book";
        labelUpdateBookStatus.Visible = true;
        labelUpdateBookStatus.ForeColor = Color.Blue;
      }

    }

    private void btnAddMember_Click(object sender, EventArgs e) {
      string name = textBoxAddMemberName.Text;
      string dateOfBirth = textBoxAddMemberDateOfBirth.Text;
      string studentID = textBoxAddMemberStudentID.Text;
      string className = textBoxAddMemberClassName.Text;
      string phoneNumber = textBoxAddMemberPhoneNumber.Text;
      string email = textBoxAddMemberEmail.Text;
      string checkedOutBooks = textBoxAddMemberCheckedOutBooks.Text;

      if (name == "" || dateOfBirth == "" || studentID == "" || className == "" || phoneNumber == "" || email == "") {
        labelAddMemberStatus.Text = "* Please fill out all fields";
        labelAddMemberStatus.Visible = true;
        labelAddMemberStatus.ForeColor = Color.Red;
      }
      else {
        // add member
        if (new Member().IsMemberExists(members, membersLength, studentID)) {
          labelAddMemberStatus.Text = "* Member exists";
          labelAddMemberStatus.Visible = true;
          labelAddMemberStatus.ForeColor = Color.Red;
        }
        else if (new Book().IsBooksCheckedOut(books, booksLength, checkedOutBooks)) {
          labelAddMemberStatus.Text = "* Some books were checked out.";
          labelAddMemberStatus.Visible = true;
          labelAddMemberStatus.ForeColor = Color.Red;
        }
        else {
          labelAddMemberStatus.Text = "* Successfully added new member!";
          labelAddMemberStatus.Visible = true;
          labelAddMemberStatus.ForeColor = Color.Blue;
          members[membersLength] = new Member(++membersLength, name, dateOfBirth, studentID, className, phoneNumber, email, checkedOutBooks);
        }
      }
    }

    private void btnFindBookByTitle_Click(object sender, EventArgs e) {
      string searchText = textBoxFindBooksByTitle.Text;

      List<Book> results = new Book().findBooks(books, booksLength, "Title", searchText);

      if (results.Count > 0) {
        labelNoResult.Visible = false;
        dataGridViewFindBooks.Visible = true;
        dataGridViewFindBooks.DataSource = results;
      }
      else {
        labelNoResult.Visible = true;
        dataGridViewFindBooks.Visible = false;
      }
    }

    private void btnFindBookByAuthor_Click(object sender, EventArgs e) {
      string searchText = textBoxFindBooksByAuthor.Text;

      List<Book> results = new Book().findBooks(books, booksLength, "Author", searchText);

      if (results.Count > 0) {
        labelNoResult.Visible = false;
        dataGridViewFindBooks.Visible = true;
        dataGridViewFindBooks.DataSource = results;
      }
      else {
        labelNoResult.Visible = true;
        dataGridViewFindBooks.Visible = false;
      }
    }

    private void btnFindBookByCategory_Click(object sender, EventArgs e) {
      string searchText = textBoxFindBooksByCategory.Text;

      List<Book> results = new Book().findBooks(books, booksLength, "Category", searchText);

      if (results.Count > 0) {
        labelNoResult.Visible = false;
        dataGridViewFindBooks.Visible = true;
        dataGridViewFindBooks.DataSource = results;
      }
      else {
        labelNoResult.Visible = true;
        dataGridViewFindBooks.Visible = false;
      }
    }

    private void btnFindBookByPublicationDate_Click(object sender, EventArgs e) {
      string searchText = textBoxFindBooksByPublicationDate.Text;

      List<Book> results = new Book().findBooks(books, booksLength, "PublicationDate", searchText);

      if (results.Count > 0) {
        labelNoResult.Visible = false;
        dataGridViewFindBooks.Visible = true;
        dataGridViewFindBooks.DataSource = results;
      }
      else {
        labelNoResult.Visible = true;
        dataGridViewFindBooks.Visible = false;
      }
    }
  }
}