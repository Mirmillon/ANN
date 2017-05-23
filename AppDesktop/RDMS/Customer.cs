

namespace AppDesktop.RDMS
{
    internal class Customer
    {
        internal int SetCustomer(string name, string middleName, string lastName, string phone)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_PROVIDER";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("NAME", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = name;
                pc.Add("MNANE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = middleName;
                pc.Add("LNAME", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = lastName;
                pc.Add("PHONE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 11).Value = phone;
                try
                {
                    conn.Open();
                    cle = (System.Int32)commande.ExecuteScalar();
                    return cle;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return -1;
                }
            }

        }
    }
}
