using System;

namespace Jayremnt.Winform {
  public partial class Member {
    private string name;
    private string dateOfBirth;
    private string studentID;
    private string className;
    private string phoneNumber;
    private string email;
    private string checkedOutBooks;

    public Member(string Name = "", string DateOfBirth = "", string StudentID = "", string ClassName = "", string PhoneNumber = "", string Email = "", string CheckedOutBooks = "") {
      this.name = Name;
      this.dateOfBirth = DateOfBirth;
      this.studentID = StudentID;
      this.className = ClassName;
      this.phoneNumber = PhoneNumber;
      this.email = Email;
      this.checkedOutBooks = CheckedOutBooks;
    }

    public string Name {
      get { return name; }
      set { name = value; }
    }

    public string DateOfBirth {
      get { return dateOfBirth; }
      set { dateOfBirth = value; }
    }

    public string StudentID {
      get { return studentID; }
      set { studentID = value; }
    }

    public string ClassName {
      get { return className; }
      set { className = value; }
    }

    public string PhoneNumber {
      get { return phoneNumber; }
      set { phoneNumber = value; }
    }

    public string Email {
      get { return email; }
      set { email = value; }
    }

    public string CheckedOutBooks {
      get { return checkedOutBooks; }
      set { checkedOutBooks = value; }
    }

    public static bool IsMemberExists(List<Member> members, string memberStudentID) {
      bool isMemberExists = false;

      for (int i = 0; i < members.Count; i++) {
        if (members[i].StudentID == memberStudentID) {
          isMemberExists = true;
          break;
        }
      }

      return isMemberExists;
    }
  }
}
