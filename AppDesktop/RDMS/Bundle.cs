
namespace AppDesktop.RDMS
{
    internal class Bundle
    {
        internal int SetBundle(int cleBrand, int cleKind, int cleCountry, string label, int weight, string note)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_BUNDLE";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("BRAND", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleBrand;
                pc.Add("KIND", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleKind;
                pc.Add("COUNTRY", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleCountry;
                pc.Add("WEIGHT", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = weight;
                pc.Add("LABEL", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 60).Value = label;
                pc.Add("NOTE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 300).Value = note;
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

        internal System.Collections.Generic.List<Classes.Bundles> GetBundles()
        {
            System.Collections.Generic.List<Classes.Bundles> l = new System.Collections.Generic.List<Classes.Bundles>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_BUNDLE";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Bundles b = new Classes.Bundles();
                            b.Cle = (int)reader[0];
                            b.CleBrand = (int)reader[1];
                            b.Label = (string)reader[2];
                            b.Weight = (int)reader[3];
                            if (!(reader[4] == System.DBNull.Value))
                            {
                                b.Note = (string)reader[4];
                            }
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

        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetKindBundles()
        {
           return  new Generic().GetReferencesSimples("GET_KINDS");
        }


        internal int SetBundleProvider(int cleProvider, int cleBundle, double price, string note)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_BUNDLE_PROVIDER";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("PROVIDER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleProvider;
                pc.Add("BUNDLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleBundle;
                pc.Add("PRICE", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = price;
                pc.Add("NOTE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 300).Value = note;
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
                    return int;
                }

            }
        }
    }
}
