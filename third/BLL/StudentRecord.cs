namespace BLL;
using student;
using DBConnection;

public class StudentRecord{

    public List<Student> getALL() {
        List<Student> list = DBConnection.getAll();
        return list;
    }

}