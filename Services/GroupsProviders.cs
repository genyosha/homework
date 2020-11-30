using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HomeworkProject.Models;
using HomeworkProject.Services;

namespace HomeworkProject.Services
{
    class GroupsProviders
    {
        private SqlConnection _connection;

        public GroupsProviders(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Group> GetAll()
        {
            List<Group> result = new List<Group>();

            try
            {
                _connection.Open();
                var command = new SqlCommand(cmdText: @"
                SELECT [Groups].[id], [Groups].[name], [Groups].[year],
                [specialty_id], [Specialties].[name], [Specialties].[code]
                FROM [Groups]
                LEFT JOIN [Specialties]
                ON [Groups].[specialty_id] = [Specialties].[id];",
                connection: _connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var group = new Group
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Year = reader.GetInt32(2),
                            SpecialtyId = reader.GetInt32(3)
                        };

                        var specialty = new Specialty 
                        {
                            Id = reader.GetInt32(4),
                            Name = reader.GetString(5),
                            Code = reader.GetString(6)
                        };

                        group.Specialty = specialty;
                        result.Add(group); 
                    }
                }

            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public bool Add(Group group)
        {
            bool result = false;
            try
            {
                _connection.Open();

                var command = new SqlCommand(
                    cmdText: @"
                    INSERT INTO [Groups]
                        ([name], [year], [specialty_id])
                    VALUES 
                        (@Name, @Year, @SpecialtyId)
                    ",
                    _connection
                    );

                command.Parameters.AddWithValue("@Name", group.Name);
                command.Parameters.AddWithValue("@Year", group.Year);
                command.Parameters.AddWithValue("@SpecialtyId", group.SpecialtyId);

                int affected = command.ExecuteNonQuery();
                result = affected > 0;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public bool Update(int id, Group group)
        {
            bool result = false;
            try
            {
                _connection.Open();
                var command = new SqlCommand(
                    @"
                        UPDATE [Groups]
                        SET 
                            [name] = @Name,
                            [year] = @Year,
                            [specialty_id] = @SpecialtyId
                        WHERE 
                            [id] = @Id
                        ",
                        _connection
                 );
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", group.Name);
                command.Parameters.AddWithValue("@Year", group.Year);
                command.Parameters.AddWithValue("@SpecialtyId", group.SpecialtyId);

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
                        DELETE FROM [Groups]
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
