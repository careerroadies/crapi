using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using System.Data.Entity;
using DataService.Migrations;

namespace DataService
{
    public class EntityFrameworkDataService: IDataSerivce, IDisposable
    {
        DataServiceDatabase _connection;

        public DataServiceDatabase dbConnection
        {
            get { return _connection; }
        }

        public void CommitTransaction(Boolean closeConnection)
        {
            dbConnection.SaveChanges();
        }

        public void RollbackTransaction(Boolean closeSession)
        {

        }

        public void CreateSession()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataServiceDatabase, Configuration>()); 
            _connection = new DataServiceDatabase();
        }

        public void BeginTransaction() { }

        public void CloseSession() { }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
