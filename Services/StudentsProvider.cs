using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HomeworkProject.Models;

namespace HomeworkProject.Services
{
    class StudentsProvider
    {
        private SqlConnection _connection;

        public StudentsProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Student> GetAll()
        {
            List<Student> result = new List<Student>();

            try
            {
                _connection.Open();
                var command = new SqlCommand(cmdText: @"
                SELECT [Students].[id], [Students].[name], [Students].[surname],
                [Students].[group_id], [Groups].[name], [Groups].[year]
                FROM [Students]
                LEFT JOIN [Groups]
                ON [Students].[group_id] = [Groups].[id];",
                connection: _connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            GroupId = reader.GetInt32(3)
                        };

                        var group = new Group
                        {
                            Id = reader.GetInt32(4),
                            Name = reader.GetString(5),
                            Year = reader.GetInt32(6)
                        };

                        student.Group = group;
                        result.Add(student);
                    }
                }


            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public bool Add(Student student)
        {
            bool result = false;
            try
            {
                _connection.Open();

                var command = new SqlCommand(
                    cmdText: @"
                    INSERT INTO [Students]
                        ([name], [surname], [group_id])
                    VALUES 
                        (@Name, @Surname, @GroupId)
                    ",
                    _connection
                    );

                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@GroupId", student.GroupId);

                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public bool Update(int id, Student student)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    @"
                        UPDATE [Students]
                        SET 
                            [name] = @Name,
                            [surname] = @Surname,
                            [group_id] = @GroupId
                        WHERE 
                            [id] = @Id
                        ",
                        _connection
                 );
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@GroupId", student.GroupId);

                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    @"
                        DELETE FROM [Students]
                        WHERE [id] = @Id
                     ",
                    _connection
                 );
                command.Parameters.AddWithValue("@Id", id);
                var affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
    }
}   
