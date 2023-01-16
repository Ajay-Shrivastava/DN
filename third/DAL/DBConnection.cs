namespace DBConnection;
using MySql.Data.MySqlClient;
using student;

public class DBConnection{

public static String conString = "host=localhost; user=root; password=root12345; database=student";

public static List<Student> getAll() {
    List<Student> list = new List<Student>();

    MySqlConnection con = new MySqlConnection();
    con.ConnectionString = conString;

    try{
        con.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;

        String query = "Select * from stu";
        cmd.CommandText =query;

        MySqlDataReader data = cmd.ExecuteReader();

        while(data.Read()) {
            int Rollno = int.Parse(data["rollno"].ToString());
            string Name = data["name"].ToString();
            int Marks = int.Parse(data["marks"].ToString());

            Student stu = new Student{
                rollno = Rollno,
                name = Name,
                marks = Marks
            };

            list.Add(stu);
        }

    }
    catch(Exception e){
        Console.WriteLine(e);
    }
    finally{
        con.Close();
    }

return list;
} 

}