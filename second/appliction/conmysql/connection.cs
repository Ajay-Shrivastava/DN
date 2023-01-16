namespace connection;
using student;
using MySql.Data.MySqlClient;
public class DBConnection {

    public static String conString = "server=localhost; port=3306; user=root; password=root12345; database=student";

    public static List<Student> getAll() {

        List<Student> list = new List<Student>();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;

        try{
                con.Open();
                //fire query to database
                MySqlCommand cmd=new MySqlCommand();
                cmd.Connection=con;
                string query="SELECT * FROM stu";
                cmd.CommandText=query;
                MySqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read()){
                    int Rollno = int.Parse(reader["rollno"].ToString());
                    string Name = reader["name"].ToString();
                    int Marks = int.Parse(reader["marks"].ToString());

            Student stu = new Student {
                    rollno = Rollno,
                    name = Name,
                    marks = Marks
                };

                list.Add(stu);
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            finally{
                    con.Close();
            }
            return list;
    }
}