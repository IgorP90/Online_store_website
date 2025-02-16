

using Dapper;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace microservice.Models;


public class CRUDHandler : IDBHandler
{
    private readonly Context context;

    public CRUDHandler(Context context) => this.context = context;

    public void Create(User user)
    {
        using SqlConnection db = new SqlConnection(context.ConnectionString);
        string sqlQuery = $"USE Auth_For_Online_shop.TestTable1 INSERT INTO (Email, Password, IsAdmin) VALUES({user.Email}, {user.Password}, {user.IsAdmin})";
        db.Execute(sqlQuery, user);
    }

    public void Delete()
    {

    }

    public string Read(int id)
    {
        using SqlConnection db = new SqlConnection(context.ConnectionString);
        return db.QueryFirstOrDefault<string>($"USE Auth_For_Online_shop SELECT email FROM TestTable1 WHERE id = {id}");
    }

    public void Update()
    {

    }
}

