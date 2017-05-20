

namespace AppDesktop.RDMS
{
    internal class Brand
    {
        public System.Collections.Generic.List<Classes.Brands> GetBrands()
        {
            System.Collections.Generic.List<Classes.Brands> l = new System.Collections.Generic.List<Classes.Brands>();

            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_BRANDS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Brands b = new Classes.Brands();
                            b.Cle = (int)reader[0];
                            b.CleCountry = (int)reader[1];
                            b.Label = (string)reader[2];
                            if (!(reader[3] == System.DBNull.Value))
                            {
                                b.Note = (string)reader[3];
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

        public System.Collections.Generic.List<Classes.Brands> GetBrandsByName(string name)
        {
            System.Collections.Generic.List<Classes.Brands> l = new System.Collections.Generic.List<Classes.Brands>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_BRANDS_BY_NAME";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = cmd.Parameters;
                pc.Add("NAME", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = name;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Brands b = new Classes.Brands();
                            b.Cle = (int)reader[0];
                            b.Label = (string)reader[1];
                            if (!(reader[2] == System.DBNull.Value))
                            {
                                b.Note = (string)reader[2];
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

        public int SetBrand(int cleCountry,string name, string note)
        {
            int cleBrand  = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_BRAND";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("COUNTRY", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleCountry;
                pc.Add("LABEL", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = name;
                pc.Add("NOTE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 300).Value = note;
                try
                {
                    conn.Open();
                    cleBrand = (System.Int32)commande.ExecuteScalar();
                    return cleBrand;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return -1;
                }
                
            }
        }


        public int UpdBrand(int cle ,string name, string note)
        {
            int i = -1;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "UPD_BRAND";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cle;
                pc.Add("LABEL", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = name;
                pc.Add("NOTE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 300).Value = note;
                try
                {
                    conn.Open();
                    i = (System.Int32)commande.ExecuteScalar();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return -1;
                }
                return i;
            }
        }

        public int DelBrand(int cle)
        {
            int i = -1;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "DEL_BRAND";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cle;
                try
                {
                    conn.Open();
                    i = (System.Int32)commande.ExecuteScalar();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return -1;
                }
                return i;
            }

        }
    }
}
