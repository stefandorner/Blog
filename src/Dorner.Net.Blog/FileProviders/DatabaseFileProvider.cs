using Microsoft.Extensions.Primitives;
using System;

namespace Microsoft.Extensions.FileProviders
{
    public class DatabaseFileProvider : IFileProvider
    {
        private string _ConnectionString;

        public DatabaseFileProvider(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            throw new NotImplementedException();
        }
        public IFileInfo GetFileInfo(string subpath)
        {
            var result = new DatabaseFileInfo(_ConnectionString, subpath);
            return result.Exists ? result as IFileInfo : new NotFoundFileInfo(subpath);
        }
        public IChangeToken Watch(string filter)
        {
            return new DatabaseChangeToken(_ConnectionString, filter);
        }
    }
}
