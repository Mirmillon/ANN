
namespace AppDesktop.RDMS
{
    internal class Credit
    {
        internal int SetCredit(int cleClient, int cleSelling, System.DateTime dateDue,double montant)
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
                pc.Add("MONTANT", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = montant;
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
                            b.CleVente = (int)reader[1];
                            b.CleClient = (int)reader[2];
                            b.DateDue = System.Convert.ToDateTime(reader[3]);
                            b.MontantDu = (double)reader[4];
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
