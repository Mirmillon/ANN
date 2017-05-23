
namespace AppDesktop.RDMS
{
    internal class Credit
    {
        internal int SetCredit(int cleClient, int cleSelling, System.DateTime dateDue)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_CREDIT";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("CLIENT", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleClient;
                pc.Add("SELLING", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleSelling;
                pc.Add("DATEDUE", FirebirdSql.Data.FirebirdClient.FbDbType.Date, 0).Value = dateDue;
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

        internal System.Collections.Generic.List<Classes.Credits> GetCredit()
        {
            System.Collections.Generic.List<Classes.Credits> l = new System.Collections.Generic.List<Classes.Credits>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "GET_CREDIT";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = commande.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Credits b = new Classes.Credits();
                            b.Cle = (int)reader[0];
                            b.Vente.Cle = (int)reader[1];
                            b.Client.Cle = (int)reader[2];
                            b.DateDue = System.Convert.ToDateTime(reader[4]);
                            b.Vente.Credit = (double)reader[5];
                            b.MontantPaye = (double)reader[6];
                            l.Add(b);
                        }
                        conn.Close();
                        return l;
                    }
                    conn.Close();
                    return null;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return null;
                }
            }
        }
    }
}
