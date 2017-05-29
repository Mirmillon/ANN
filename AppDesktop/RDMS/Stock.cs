

namespace AppDesktop.RDMS
{
    class Stock
    {
        internal int SetBundleInStock(int cleBundle, int cleProvider,System.DateTime dateAchat, double prix)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_BUNDLE_IN_STOCK";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("BUNDLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleBundle;
                pc.Add("PROVIDER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleProvider;
                pc.Add("DATE", FirebirdSql.Data.FirebirdClient.FbDbType.Date, 0).Value = dateAchat;
                pc.Add("PRIX", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = prix;
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

        internal System.Collections.Generic.List<Classes.Stocks> GetStocks()
        {
            System.Collections.Generic.List<Classes.Stocks> l = new System.Collections.Generic.List<Classes.Stocks>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_STOCKS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Stocks b = new Classes.Stocks();
                            b.CleStock = (int)reader[0];
                            b.Cle = (int)reader[1];
                            b.CleProvider = (int)reader[2];
                            b.DateAchat = System.Convert.ToDateTime(reader[3]);
                            b.Prix = (double)reader[4];
                            if (!(reader[5] == System.DBNull.Value))
                            {
                                b.NbItems = (int)reader[5];
                            }
                            b.CleBrand = (int)reader[6];
                            b.Label =(string)reader[7];
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
