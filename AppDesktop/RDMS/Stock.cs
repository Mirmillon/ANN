

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

        internal System.Collections.Generic.List<Classes.Price> GetPrices()
        {
            System.Collections.Generic.List<Classes.Price> l = new System.Collections.Generic.List<Classes.Price>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_PRICES";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Price b = new Classes.Price();
                            b.ClePrix = (int)reader[0];
                            if (!(reader[1] == System.DBNull.Value))
                            {
                                b.Code = (string)reader[1];
                            } 
                            b.Prix = (double)reader[2];
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

        //internal System.Collections.Generic.List<Classes.Valeurs> GetValeurs()
        //{
        //    System.Collections.Generic.List<Classes.Valeurs> l = new System.Collections.Generic.List<Classes.Valeurs>();
        //    FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
        //    using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = "GET_VALUES";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        try
        //        {
        //            conn.Open();
        //            FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    Classes.Valeurs b = new Classes.Valeurs();
        //                    b.CleBundle = (int)reader[0];
        //                    b.Code = (string)reader[1];
                          
        //                    b.NbItems = (int)reader[2];
        //                    l.Add(b);
        //                }
        //                conn.Close();
        //                return l;
        //            }
        //            conn.Close();
        //            return null;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            System.Windows.Forms.MessageBox.Show(ex.ToString());
        //            conn.Close();
        //            return null;
        //        }
        //    }
        //}

        internal int  SetValeurs(int cleBundle, string codePrix, int nombreItems)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_VALUES";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = cmd.Parameters;
                pc.Add("BUNDLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleBundle;
                pc.Add("CODE", FirebirdSql.Data.FirebirdClient.FbDbType.Char, 1).Value = codePrix;
                pc.Add("NB", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = nombreItems;

                try
                {
                    conn.Open();
                    cle = (System.Int32)cmd.ExecuteScalar();
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

        internal int UptValeurs(int cleBundle, string codePrix, int nombreItems)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPD_VALUES";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = cmd.Parameters;
                pc.Add("BUNDLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleBundle;
                pc.Add("CODE", FirebirdSql.Data.FirebirdClient.FbDbType.Char, 1).Value = codePrix;
                pc.Add("NB", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = nombreItems;

                try
                {
                    conn.Open();
                    cle = (System.Int32)cmd.ExecuteScalar();
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

        internal System.Collections.Generic.List<Classes.Valeurs> GetValeursTotal()
        {
            System.Collections.Generic.List<Classes.Valeurs> l = new System.Collections.Generic.List<Classes.Valeurs>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_VALUES_TOTAL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Valeurs b = new Classes.Valeurs();
                            b.ClePrix = (int)reader[0];
                            b.NbItems = (int)reader[1];
                            b.Prix = (double)reader[2];
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

        internal int  GetNombreItemsInStock()
        {
            int valeurs;
            System.Collections.Generic.List<Classes.Valeurs> l = new System.Collections.Generic.List<Classes.Valeurs>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_ITEMS_TOTAL_STOCK";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    valeurs = (int)cmd.ExecuteScalar();
                    return valeurs;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    conn.Close();
                    return 0;
                }
            }
        }


        internal System.Collections.Generic.List<Classes.ItemsSale> GetItemsSaleByCode()
        {
            System.Collections.Generic.List<Classes.ItemsSale> l = new System.Collections.Generic.List<Classes.ItemsSale>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_ITEM_CODE_SALE_TOTAL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.ItemsSale b = new Classes.ItemsSale();
                            b.Code = (string)reader[0];
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

        ////Nbs items en stock après les ventes
        //internal System.Collections.Generic.List<Classes.Valeurs> GetItemsStocks()
        //{
        //    System.Collections.Generic.List<Classes.Valeurs> l = new System.Collections.Generic.List<Classes.Valeurs>();

        //    //Récupération de liste des items par code prix dans les bundles (base du calcul)
        //    System.Collections.Generic.List<Classes.Valeurs> listeItemsInAllBundles = GetValeursTotal();
        //    //Récupération de liste des items vendus par code
        //    System.Collections.Generic.List<Classes.ItemsSale> listeItemsSoldByCodePrix = GetItemsSaleByCode();
        //    //Création d'une nouvelle liste

        //    foreach(Classes.Valeurs v in listeItemsInAllBundles)
        //    {
        //        Classes.Valeurs valeur = new Classes.Valeurs();
        //        if(listeItemsSoldByCodePrix.Count >0)
        //        {
        //            foreach (Classes.ItemsSale item in listeItemsSoldByCodePrix)
        //            {

        //                if (v.Code == item.Code)
        //                {

        //                    valeur.Code = item.Code;
        //                    valeur.Prix = item.Prix;
        //                    valeur.NbItems = v.NbItems - item.Nombre;
        //                    l.Add(valeur);
        //                }
        //                else
        //                {
        //                    valeur.Code = v.Code;
        //                    valeur.Prix = v.Prix;
        //                    valeur.NbItems = v.NbItems;
        //                    l.Add(valeur);
        //                }
        //            }
        //        }
        //        else { return listeItemsInAllBundles; }
              
        //    }


        //    return l;
        //}







    }
}
