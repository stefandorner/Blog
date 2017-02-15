using Dorner.Services.Blog.EntityFramework.DbContexts;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace Microsoft.Extensions.FileProviders
{
    public class DatabaseChangeToken : IChangeToken
    {
        private string _ConnectionString;
        private string _viewPath;
        public DatabaseChangeToken(string connectionString, string viewPath)
        {
            _ConnectionString = connectionString;
            _viewPath = viewPath;
        }
        public bool ActiveChangeCallbacks => false;
        public bool HasChanged
        {
            get
            {
                var query = "SELECT LastRequested, LastModified FROM blogfilesystem WHERE Location = @Path;";
                try
                {
                    using (var conn = new MySqlConnection(_ConnectionString))
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Path", _viewPath);
                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                if (reader["LastRequested"] == DBNull.Value)
                                {
                                    return false;
                                }
                                else
                                {
                                    return Convert.ToDateTime(reader["LastModified"]) > Convert.ToDateTime(reader["LastRequested"]);
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public IDisposable RegisterChangeCallback(Action<object> callback, object state) => EmptyDisposable.Instance;
    }
    internal class EmptyDisposable : IDisposable
    {
        public static EmptyDisposable Instance { get; } = new EmptyDisposable();
        private EmptyDisposable() { }
        public void Dispose() { }
    }
}
