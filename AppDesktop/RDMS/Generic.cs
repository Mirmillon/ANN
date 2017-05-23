

namespace AppDesktop.RDMS
{
   internal  class Generic
   {
        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetReferencesSimples(string sql)
        {
            System.Collections.Generic.List<Classes.ReferencesSimples> l = new System.Collections.Generic.List<Classes.ReferencesSimples>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.ReferencesSimples b = new Classes.ReferencesSimples();
                            b.Cle = (int)reader[0];
                            b.Label = (string)reader[1];
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

        internal double GetDouble(string sql)
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = sql;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    double income = (double)commande.ExecuteScalar();
                    conn.Close();
                    return income;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return -1;
                }
            }
        }

        internal int GetNombre(string sql)
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = sql;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    int income = (int)commande.ExecuteScalar();
                    conn.Close();
                    return income;
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
