using Jayremnt.Winform;

namespace librarymanager {
  public partial class LibraryManager : Form {
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();

    public LibraryManager() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      books.Add(new Book("Toi thay hoa vang tren co xanh", "Nguyen Nhat Anh", "18/9/2019", "truyen hay", "GW1001"));
      members.Add(new Member("Bao", "20/06/2003", "GCH210135", "GCH1006", "545342", "432423423", "GW1111 GW2222"));

      dataGridViewBooks.DataSource = books;
      dataGridViewMembers.DataSource = members;

      dataGridViewBooks.Refresh();
      dataGridViewMembers.Refresh();
    }

    private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0) {
        DataGridViewRow row = this.dataGridViewBooks.Rows[e.RowIndex];
        textBoxBookIndex.Text = (e.RowIndex + 1).ToString();
        textBoxBookTitle.Text = row.Cells["Title"].Value.ToString();
        textBoxBookAuthor.Text = row.Cells["Author"].Value.ToString();
        textBoxBookPublicationDate.Text = row.Cells["PublicationDate"].Value.ToString();
        textBoxBookCategory.Text = row.Cells["Category"].Value.ToString();
        textBoxBookCode.Text = row.Cells["Code"].Value.ToString();
      }
    }
    private void dataGridViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0) {
        DataGridViewRow row = this.dataGridViewMembers.Rows[e.RowIndex];
        textBoxMemberIndex.Text = (e.RowIndex + 1).ToString();
        textBoxMemberName.Text = row.Cells["Name"].Value.ToString();
        textBoxMemberDateOfBirth.Text = row.Cells["DateOfBirth"].Value.ToString();
        textBoxMemberStudentID.Text = row.Cells["StudentID"].Value.ToString();
        textBoxMemberClassName.Text = row.Cells["ClassName"].Value.ToString();
        textBoxMemberPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
        textBoxMemberEmail.Text = row.Cells["Email"].Value.ToString();
        textBoxMemberCheckedOutBooks.Text = row.Cells["CheckedOutBooks"].Value.ToString();
      }
    }

    private void btnUpdateBook_Click(object sender, EventArgs e) {
      int index = Int32.Parse(textBoxBookIndex.Text);
      string title = textBoxBookTitle.Text;
      string author = textBoxBookAuthor.Text;
      string publicationDate = textBoxBookPublicationDate.Text;
      string category = textBoxBookCategory.Text;
      string code = textBoxBookCode.Text;

      if (books[index - 1].Code != code) {
        if (new Book().IsBookExists(books, code)) {
          labelHandleBookStatus.Text = "* Book exists";
          labelHandleBookStatus.Visible = true;
          labelHandleBookStatus.ForeColor = Color.Red;
        }
        else {
          books[index - 1] = new Book(title, author, publicationDate, category, code);
          labelHandleBookStatus.Text = "* Updated book";
          labelHandleBookStatus.Visible = true;
          labelHandleBookStatus.ForeColor = Color.Blue;
        }
      }
      else {
        books[index - 1] = new Book(title, author, publicationDate, category, code);
        labelHandleBookStatus.Text = "* Updated book";
        labelHandleBookStatus.Visible = true;
        labelHandleBookStatus.ForeColor = Color.Blue;
      }

    }
    private void btnDeleteBook_Click(object sender, EventArgs e) {
      int bookIndex = Int32.Parse(textBoxBookIndex.Text) - 1;
      books.RemoveAt(bookIndex);
      dataGridViewBooks.DataSource = books;
      dataGridViewBooks.Refresh();
    }
    private void btnDeleteMember_Click(object sender, EventArgs e) {
      int memberIndex = Int32.Parse(textBoxMemberIndex.Text) - 1;
      members.RemoveAt(memberIndex);
      dataGridViewMembers.DataSource = members;
      dataGridViewMembers.Refresh();
    }

    private void btnAddBook_Click(object sender, EventArgs e) {
      string title = textBoxBookTitle.Text;
      string author = textBoxBookAuthor.Text;
      string publicationDate = textBoxBookPublicationDate.Text;
      string category = textBoxBookCategory.Text;
      string code = textBoxBookCode.Text;

      if (title == "" || author == "" || publicationDate == "" || category == "" || code == "") {
        labelHandleBookStatus.Text = "* Please fill out all fields";
        labelHandleBookStatus.Visible = true;
        labelHandleBookStatus.ForeColor = Color.Red;
      }
      else {
        // add book
        if (new Book().IsBookExists(books, code)) {
          labelHandleBookStatus.Text = "* Book exists";
          labelHandleBookStatus.Visible = true;
          labelHandleBookStatus.ForeColor = Color.Red;
        }
        else {
          labelHandleBookStatus.Text = "* Successfully added new book!";
          labelHandleBookStatus.Visible = true;
          labelHandleBookStatus.ForeColor = Color.Blue;
          books.Add(new Book(title, author, publicationDate, category, code));
          dataGridViewBooks.Refresh();
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
        labelHandleMemberStatus.Visible = true;
        labelHandleMemberStatus.ForeColor = Color.Red;
      }
      else {
        // add member
        if (new Member().IsMemberExists(members, studentID)) {
          labelHandleMemberStatus.Text = "* Member exists";
          labelHandleMemberStatus.Visible = true;
          labelHandleMemberStatus.ForeColor = Color.Red;
        }
        else if (new Book().IsBooksCheckedOut(books, checkedOutBooks)) {
          labelHandleMemberStatus.Text = "* Some books were checked out.";
          labelHandleMemberStatus.Visible = true;
          labelHandleMemberStatus.ForeColor = Color.Red;
        }
        else {
          labelHandleMemberStatus.Text = "* Successfully added new member!";
          labelHandleMemberStatus.Visible = true;
          labelHandleMemberStatus.ForeColor = Color.Blue;
          members.Add(new Member(name, dateOfBirth, studentID, className, phoneNumber, email, checkedOutBooks));
          dataGridViewMembers.Refresh();
        }
      }
    }

    private void btnFindBooks_Click(object sender, EventArgs e) {
      string bookTitle = textBoxFindBooksByTitle.Text;
      string bookAuthor = textBoxFindBooksByAuthor.Text;
      string bookCategory = textBoxFindBooksByCategory.Text;
      string bookPublicationDate = textBoxFindBooksByPublicationDate.Text;

      List<Book> results = new Book().findBooks(books, bookTitle, bookAuthor, bookCategory, bookPublicationDate);

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

    private void textBoxBookCode_TextChanged(object sender, EventArgs e) {
      string bookCode = textBoxBookCode.Text;
      if (!string.IsNullOrEmpty(bookCode)) {
        if (!(new Book().IsBookExists(books, bookCode))) {
          btnAddBook.Enabled = true;
        }
        else {
          btnAddBook.Enabled = false;
        }
      }
      else {
        btnAddBook.Enabled = false;
      }
    }
  }
}