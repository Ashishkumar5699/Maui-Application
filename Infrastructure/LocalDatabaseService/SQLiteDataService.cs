using Sonaar.Models.Auth;
using Sonaar.Resources.Constant;
using SQLite;
using Punjab_Ornaments.Models;

namespace Sonaar.Infrastructure.Database
{
    public partial class SQLiteDataService : IDataService
    {
        #region initialization
        private static readonly Lazy<SQLiteAsyncConnection> LazyInitializer = new(() =>
        {
            return new SQLiteAsyncConnection(DatabaseConstant.DatabasePath, DatabaseConstant.Flags);
        });
        private static SQLiteAsyncConnection Database => LazyInitializer.Value;

        public void Initialize()
        {
            var database = new SQLiteConnection(DatabaseConstant.DatabasePath);
            CreateTables(database);
        }
        private static void CreateTables(SQLiteConnection database)
        {
            database.CreateTable<Models.Auth.LoginUser>();
        }
        #endregion

        public async Task<ResponseResult<LoginUser>> LoginUser(string username, string password)
        {
            await Task.Delay(100);

            var result = new ResponseResult<LoginUser>
            {
                HasErrors = false,
                Data = new LoginUser
                {
                    UserName = username,
                    Password = password,
                }
            };

            return result;
        }
    }
}