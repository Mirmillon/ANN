
namespace AppDesktop.RDMS
{
    internal class Selling
    {
        internal System.Collections.Generic.List<Classes.Sellings> GetSellings()
        {
            System.Collections.Generic.List<Classes.Sellings> l = new System.Collections.Generic.List<Classes.Sellings>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_SELLINGS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Sellings b = new Classes.Sellings();
                            b.Cle = (int)reader[0];
                            b.DateSelling = System.Convert.ToDateTime(reader[1]);
                            if (!(reader[2] == System.DBNull.Value))
                            {
                                b.NbItems = (int)reader[2];
                            }
                            if (!(reader[3] == System.DBNull.Value))
                            {
                                b.Amount = (double)reader[3];
                            }
                            b.TypePayment = (int)reader[4];
                            if (!(reader[5] == System.DBNull.Value))
                            {
                                b.Cash = (double)reader[5];
                            }
                            if (!(reader[6] == System.DBNull.Value))
                            {
                                b.CleClient = (int)reader[6];
                            }
                            if (!(reader[7] == System.DBNull.Value))
                            {
                                b.DateDue = System.Convert.ToDateTime(reader[7]);
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

        internal double GetTurnOverCurrentYear() { return new Generic().GetDouble("GET_TURNOVER_CURRENT_YEAR"); }

        internal int SetSale(int cleKindPayment, System.DateTime dateSale, int n, double amount, double cash)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_SALE";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("PAYMENT", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleKindPayment;
                pc.Add("DATE", FirebirdSql.Data.FirebirdClient.FbDbType.Date, 0).Value = dateSale;
                pc.Add("NUMBER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = n;
                pc.Add("AMOUNT", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = amount;
                pc.Add("CASH", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = cash;
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
                    return cle;
                }
            }
        }

        internal void SetSaleClothes(int cleVente, int clePrix, int nombre)
        {

            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_SELLING_CLOTHES";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE_VENTE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleVente;
                pc.Add("CLE_TYPE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = clePrix;
                pc.Add("NUMBER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = nombre;
               

                try
                {
                    conn.Open();
                    commande.ExecuteScalar();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                }
            }
        }

        internal void SetSaleOther(int cleVente, int cleTypeItem, int nombre)
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_SELLING_OTHER";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleVente;
                pc.Add("TYPE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleTypeItem;
                pc.Add("NUMBER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = nombre;
                try
                {
                    conn.Open();
                    commande.ExecuteScalar();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                }
            }
        }

        internal System.Collections.Generic.List<Classes.Sales> GetSales()
        {
            System.Collections.Generic.List<Classes.Sales> l = new System.Collections.Generic.List<Classes.Sales>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_SALES";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Sales b = new Classes.Sales();
                            b.CleVente = (int)reader[0];
                            b.DateVente = System.Convert.ToDateTime(reader[1]);
                            b.CleType = (int)reader[2];
                            b.Nombre = (int)reader[3];
                            b.Amount = (double)reader[4];
                            b.Categorie = (string)reader[5];
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

        internal System.Collections.Generic.List<Classes.Sales> GetSalesClothesMonth()
        {
            System.Collections.Generic.List<Classes.Sales> l = new System.Collections.Generic.List<Classes.Sales>();
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
                            Classes.Sales b = new Classes.Sales();
                            b.MoisVente = (int)reader[0];
                            b.Amount = (double)reader[1];
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

        internal System.Collections.Generic.List<Classes.Sales> GetSalesLoadMonth()
        {
            System.Collections.Generic.List<Classes.Sales> l = new System.Collections.Generic.List<Classes.Sales>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_SALES_LOAD_MONTH";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Sales b = new Classes.Sales();
                            b.MoisVente = (int)reader[0];
                            b.Amount = (double)reader[1];
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

        internal System.Collections.Generic.List<Classes.Sales> GetSalesBeautyMonth()
        {
            System.Collections.Generic.List<Classes.Sales> l = new System.Collections.Generic.List<Classes.Sales>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_SALES_BEAUTY_MONTH";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Sales b = new Classes.Sales();
                            b.MoisVente = (int)reader[0];
                            b.Amount = (double)reader[1];
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
