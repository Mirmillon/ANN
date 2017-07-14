

namespace AppDesktop.RDMS
{
    internal class Data
    {
        internal System.Collections.Generic.List<Classes.DataClothes> GetDataCurrentMonth()
        {
            System.Collections.Generic.List<Classes.DataClothes> l = new System.Collections.Generic.List<Classes.DataClothes>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_SALES_CLOTHES_MONTH";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.DataClothes b = new Classes.DataClothes();
                            b.Mois = (int)reader[0];
                            b.Amount = (double)reader[1];
                            b.Nombre = (int)reader[2];
                            b.Moyenne = (double)reader[3];
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

        internal System.Collections.Generic.List<Classes.DataClothes> GetDataClothesMonth()
        {
            System.Collections.Generic.List<Classes.DataClothes> l = new System.Collections.Generic.List<Classes.DataClothes>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_DATA_CLOTHES_MONTH";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.DataClothes b = new Classes.DataClothes();
                            b.ClePrix = (int)reader[0];
                            b.Nombre = (int)reader[1];
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

    //GET_DATA_CLOTHES_MONTH


}
