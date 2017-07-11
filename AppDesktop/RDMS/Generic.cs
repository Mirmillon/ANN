

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
            double d;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = sql;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    d = (double)commande.ExecuteScalar();
                    conn.Close();
                    return d;
                    
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

        internal int   SetReferenceSimple(string sql,string name)
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = sql;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("LABEL", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = name;
                try
                {
                    conn.Open();
                    int cle = (System.Int32)commande.ExecuteScalar();
                    conn.Close();
                    return (int)cle;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return 0;
                }
            }
        }

        internal  int  GetReferenceSimple(string sql, string name)
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = sql;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("LABEL", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = name;
                try
                {
                    conn.Open();
                    int cle = (System.Int32)commande.ExecuteScalar();
                    conn.Close();
                    return (int)cle;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return 0;
                }
            }
        }
    }
}
