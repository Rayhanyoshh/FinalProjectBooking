using Realta.Persistence.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.RepositoryContext
{
    public class AdoDbContext : IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        private bool _isDisposed;

        public AdoDbContext(string sqlConnection)
        {
            _sqlConnection = new SqlConnection(sqlConnection);
        }

        public void Dispose()
        {
            Dispose(_isDisposed);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sqlConnection.Dispose();
                _isDisposed = true;
            }
        }
        public void DisposeAsync()
        {
            DisposeAsync(_isDisposed);
        }

        public void DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                _sqlConnection.DisposeAsync();
                _isDisposed = true;
            }
        }


        public void ExecuteNonQuery(SqlCommandModel model)
        {
            SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
            sqlCommand.CommandType = model.CommandType;
            foreach (SqlCommandParameterModel parameter in model.CommandParameters)
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = parameter.ParameterName,
                    DbType = parameter.DataType,
                    Value = parameter.Value
                });
            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public int ExecuteNonQueryReturn(SqlCommandModel model)
        {
            SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
            sqlCommand.CommandType = model.CommandType;
            foreach (SqlCommandParameterModel parameter in model.CommandParameters)
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = parameter.ParameterName,
                    DbType = parameter.DataType,
                    Value = parameter.Value
                });
            _sqlConnection.Open();

            var rowsAffected = sqlCommand.ExecuteNonQuery();

            //var rowsAffected = Convert.ToInt32(sqlCommand.Parameters["@RowCount"].Value);
            _sqlConnection.Close();
            return rowsAffected;
        }

        public void ExecuteNonQueryAsync(SqlCommandModel model)
        {
            SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
            sqlCommand.CommandType = model.CommandType;
            foreach (SqlCommandParameterModel parameter in model.CommandParameters)
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = parameter.ParameterName,
                    DbType = parameter.DataType,
                    Value = parameter.Value
                });
            _sqlConnection.OpenAsync();
            sqlCommand.ExecuteNonQueryAsync();
            _sqlConnection.CloseAsync();
        }



        public T ExecuteScalar<T>(SqlCommandModel model)
        {
            SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
            sqlCommand.CommandType = model.CommandType;
            foreach (SqlCommandParameterModel parameter in model.CommandParameters)
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = parameter.ParameterName,
                    DbType = parameter.DataType,
                    Value = parameter.Value
                });
            _sqlConnection.Open();
            T data = (T)sqlCommand.ExecuteScalar();
            _sqlConnection.Close();
            return data;
        }

        public async Task<T> ExecuteScalarAsync<T>(SqlCommandModel model)
        {
            SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
            sqlCommand.CommandType = model.CommandType;
            foreach (SqlCommandParameterModel parameter in model.CommandParameters)
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = parameter.ParameterName,
                    DbType = parameter.DataType,
                    Value = parameter.Value
                });
            await _sqlConnection.OpenAsync();
            T data = (T)await sqlCommand.ExecuteScalarAsync();
            await _sqlConnection.CloseAsync();
            return data;
        }



        public IEnumerator<T> ExecuteReader<T>(string sql)
        {
            Type TypeT = typeof(T);
            ConstructorInfo ctor = TypeT.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
            {
                throw new InvalidOperationException($"Type {TypeT.Name} does not have a default constructor.");
            }
            _sqlConnection.Open();
            IEnumerator data = new SqlCommand(sql, _sqlConnection).ExecuteReader().GetEnumerator();
            while (data.MoveNext())
            {
                T newInst = (T)ctor.Invoke(null);
                DbDataRecord record = (DbDataRecord)data.Current;
                int fieldCount = Properties.GetFieldCount((DbDataRecord)data.Current);
                for (int i = 0; i < fieldCount; i++)
                {
                    string propertyName = record.GetName(i);
                    PropertyInfo propertyInfo = TypeT.GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        object value = record[i];
                        if (value == DBNull.Value)
                            propertyInfo.SetValue(newInst, null);
                        else
                            propertyInfo.SetValue(newInst, value);
                    }
                }
                yield return newInst;
            }
            _sqlConnection.Close();
        }

        public IEnumerator<T> ExecuteReader<T>(SqlCommandModel model)
        {
            Type TypeT = typeof(T);
            ConstructorInfo ctor = TypeT.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
            {
                throw new InvalidOperationException($"Type {TypeT.Name} does not have a default constructor.");
            }
            SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
            sqlCommand.CommandType = model.CommandType;
            foreach (SqlCommandParameterModel parameter in model.CommandParameters)
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = parameter.ParameterName,
                    DbType = parameter.DataType,
                    Value = parameter.Value
                });
            _sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T newInst = (T)ctor.Invoke(null);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string propertyName = reader.GetName(i);
                        PropertyInfo propertyInfo = TypeT.GetProperty(propertyName);
                        if (propertyInfo != null)
                        {
                            object value = reader[i];
                            if (value == DBNull.Value)
                                propertyInfo.SetValue(newInst, null);
                            else propertyInfo.SetValue(newInst, value);
                        }
                    }
                    yield return newInst;
                }
            }
            _sqlConnection.Close();
        }

        public async IAsyncEnumerator<T> ExecuteReaderAsync<T>(SqlCommandModel model)
        {
            Type TypeT = typeof(T);
            ConstructorInfo ctor = TypeT.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
            {
                throw new InvalidOperationException($"Type {TypeT.Name} does not have a default constructor.");
            }
            SqlCommand sqlCommand = new(model.CommandText, _sqlConnection);
            sqlCommand.CommandType = model.CommandType;
            foreach (SqlCommandParameterModel parameter in model.CommandParameters)
                sqlCommand.Parameters.Add(new SqlParameter()
                {
                    ParameterName = parameter.ParameterName,
                    DbType = parameter.DataType,
                    Value = parameter.Value
                });
            await _sqlConnection.OpenAsync();
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T newInst = (T)ctor.Invoke(null);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string propertyName = reader.GetName(i);
                        PropertyInfo propertyInfo = TypeT.GetProperty(propertyName);
                        if (propertyInfo != null)
                        {
                            object value = reader[i];
                            if (value == DBNull.Value)
                                propertyInfo.SetValue(newInst, null);
                            else propertyInfo.SetValue(newInst, value);
                        }
                    }
                    yield return newInst;
                }
            }
            await _sqlConnection.CloseAsync();
        }


        // method direct query, if you want just only query use this, not recommended for large dataset
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                _sqlConnection.Open();
                return new SqlCommand(sql, _sqlConnection).ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
        }


        public async Task<int> ExecuteNonQueryAsync(string sql)
        {
            try
            {
                await _sqlConnection.OpenAsync();
                return new SqlCommand(sql, _sqlConnection).ExecuteNonQuery();
            }
            finally
            {
                await _sqlConnection.CloseAsync();
            }
        }

        public T ExecuteScalar<T>(string sql)
        {
            try
            {
                _sqlConnection.Open();

                var result = (T)new SqlCommand(sql, _sqlConnection).ExecuteScalar();
                //return (T)new SqlCommand(sql, _sqlConnection).ExecuteScalar();
                return result;
            }
            finally
            {
                _sqlConnection.Close();
            }

        }

    }
}
