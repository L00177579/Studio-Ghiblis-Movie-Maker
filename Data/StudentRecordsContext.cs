using System.Collections.Generic;
using MySqlConnector;
using StudioGhibliMovieMaker.Models;

namespace StudioGhibliMovieMaker.Data
{
    public class StudentRecordsContext
    {
        public string ConnectionString { get; set; }

        public StudentRecordsContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<StudentRecords> GetAllRecords()
        {
            List<StudentRecords> list = new List<StudentRecords>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from StudentRecords", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StudentRecords()
                        {
                            ID = (int)reader["studentid"],
                            Name = reader["name"].ToString(),
                            DOB = DateTime.Parse(reader["dob"].ToString()),
                            Email = reader["email"].ToString(),
                            PhoneNumber = reader["phone"].ToString(),
                            //CourseIDs = reader["courses"].ToString().Split(",").Select(x => new CourseDetails(int.Parse(x), )).ToList(x),
                            Comments = reader["comments"].ToString()
                        }); ;
                    }
                }
            }
            return list;
        }

        public void SetRecord(StudentRecords record)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from StudentRecords where studentid = '" + record.ID + "'", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    MySqlCommand c;
                    if (reader.HasRows)
                    {
                        //TODO - Finish command for updating records
                        c = new MySqlCommand(
                                "update StudentRecords set name = '" + record.Name +
                                "' where studentid = '" + record.ID + "'", conn);
                    }
                    else
                    {
                        c = new MySqlCommand(
                            "insert into StudentRecords values('" + record.ID +
                            "', '" + record.Name
                            + "', '" + record.DOB.ToString()
                            + "', '" + record.Email
                            + "', '" + record.PhoneNumber
                            + "', '" + string.Join(",", record.CourseIDs.Select(x => x.ToString()))
                            + "', '" + record.Comments
                            + "';", conn);
                    }

                    conn.Close();
                    conn.Open();
                    c.ExecuteNonQuery();
                }
            }
        }
    }

}

