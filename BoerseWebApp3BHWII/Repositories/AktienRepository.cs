using BoerseWebApp3BHWII.Models;
using Npgsql;

namespace BoerseWebApp3BHWII.Repositories;

public class AktienRepository
{
    private NpgsqlConnection ConnectToDb()
    {

        string connectionString = "Host=localhost;" +
        "Database=Boerse;" +
        "User Id=dbuser;" +
        "Password=dbuser;";

        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        return connection;
    }


    public List<Aktien> GetAllAktien()
    {
        NpgsqlConnection myConnection = ConnectToDb();

        using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Aktien", myConnection);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
        List<Aktien> aktien = new List<Aktien>();
        while (reader.Read())
        {
            Aktien newAktien = new Aktien();
            newAktien.aktienid = (int) reader["aktienid"];
            newAktien.aktienkurs = (double) reader["Aktienkurs"];
            newAktien.aktienname = (string) reader["Aktienname"];
            newAktien.kurzzeichen = (string) reader["Kurzzeichen"];
            

            aktien.Add(newAktien);
        }
        myConnection.Close();
        return aktien;
    }
    public void CreateAktien(Aktien aktien)
    {
        NpgsqlConnection myConnection = ConnectToDb();


        using NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO Aktien (aktienkurs, aktienname, kurzzeichen) VALUES (:v1, :v2, :v3)", myConnection);
        cmd.Parameters.AddWithValue("v1", aktien.aktienkurs);
        cmd.Parameters.AddWithValue("v2", aktien.aktienname);
        cmd.Parameters.AddWithValue("v3", aktien.kurzzeichen);
        


        int rowsAffected = cmd.ExecuteNonQuery();

        myConnection.Close();
    }



    public void DeleteAktien(int aktienId)
    {

    }

}