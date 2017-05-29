
namespace AppDesktop.RDMS
{
    internal class Item
    {
        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetSizes()
        {
            return new Generic().GetReferencesSimples("GET_SIZES");
        }

        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetGenders()
        {
            return new Generic().GetReferencesSimples("GET_GENDERS");
        }

        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetColors()
        {
            return new Generic().GetReferencesSimples("GET_COLORS");
        }

        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetCategories()
        {
            return new Generic().GetReferencesSimples("GET_CATEGORIES");
        }

        internal int SetCategorie(string label)
        {
            return new Generic().SetReferenceSimple("SET_CATEGORIES", label);
        }

        internal int SetColor(string label)
        {
            return new Generic().SetReferenceSimple("SET_COLOR", label);
        }

        internal int SetItem(string refArticle,int categorie, int typeArticle, int size, int genderArticle, int color,  int brand, string description, double prix, string image)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_ITEM_IN_STOCK";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("REFERENCE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 20).Value = refArticle;
                pc.Add("CATEGORIE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = categorie;
                pc.Add("TYPE_BUNDLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = typeArticle;
                pc.Add("SIZE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = size;
                pc.Add("GENDER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = genderArticle;
                pc.Add("COLOR", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = color;
                pc.Add("BRAND", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = brand;
                pc.Add("DESCRIPTION", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 120).Value = description;
                pc.Add("PRIX", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = prix;
                pc.Add("IMAGE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 250).Value = image;
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


        internal System.Collections.Generic.List<Classes.Items> GetItemsInStock()
        {
            System.Collections.Generic.List<Classes.Items> l = new System.Collections.Generic.List<Classes.Items>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "get_items_in_stock";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Items b = new Classes.Items();
                            b.Cle = (int)reader[0];
                            if (!(reader[1] == System.DBNull.Value))
                            {
                                b.RefArticle = (string)reader[1];
                            }
                            if (!(reader[2] == System.DBNull.Value))
                            {
                                b.Categorie = (int)reader[2];
                            }
                            if (!(reader[3] == System.DBNull.Value))
                            {
                                b.TypeArticle = (int)reader[3];
                            }
                            if (!(reader[4] == System.DBNull.Value))
                            {
                                b.Size = (int)reader[4];
                            }
                            if (!(reader[5] == System.DBNull.Value))
                            {
                                b.GenderArticle = (int)reader[5];
                            }
                            if (!(reader[6] == System.DBNull.Value))
                            {
                                b.Color = (int)reader[6];
                            }
                            if (!(reader[7] == System.DBNull.Value))
                            {
                                b.Brand = (int)reader[7];
                            }
                            if (!(reader[8] == System.DBNull.Value))
                            {
                                b.Description = (string)reader[8];
                            }
                            if (!(reader[9] == System.DBNull.Value))
                            {
                                b.Prix = (double)reader[9];
                            }

                            if (!(reader[10] == System.DBNull.Value))
                            {
                                b.ImageSource = (string)reader[10];
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

        internal void  UpdItem(int cleArticle, string refArticle, int typeBundle,  int categorie, int size, int genderArticle, int color, int brand, string description, double prix, string image)
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "UPD_ITEM_IN_STOCK";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleArticle;
                pc.Add("REFERENCE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 20).Value = refArticle;
                pc.Add("CATEGORIE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = categorie;
                pc.Add("TYPE_BUNDLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = typeBundle;
                pc.Add("SIZE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = size;
                pc.Add("GENDER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = genderArticle;
                pc.Add("COLOR", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = color;
                pc.Add("BRAND", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = brand;
                pc.Add("DESCRIPTION", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 120).Value = description;
                pc.Add("PRIX", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = prix;
                pc.Add("IMAGE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 250).Value = image;
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

        internal Classes.Items GetItemsInStockByKey(int cle)
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            Classes.Items b = new Classes.Items();
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "get_items_in_stock_by_key";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = cmd.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cle;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            b.Cle = (int)reader[0];
                            if (!(reader[1] == System.DBNull.Value))
                            {
                                b.RefArticle = (string)reader[1];
                            }
                            if (!(reader[2] == System.DBNull.Value))
                            {
                                b.Categorie = (int)reader[2];
                            }
                            if (!(reader[3] == System.DBNull.Value))
                            {
                                b.TypeArticle = (int)reader[3];
                            }
                            if (!(reader[4] == System.DBNull.Value))
                            {
                                b.Size = (int)reader[4];
                            }
                            if (!(reader[5] == System.DBNull.Value))
                            {
                                b.GenderArticle = (int)reader[5];
                            }
                            if (!(reader[6] == System.DBNull.Value))
                            {
                                b.Color = (int)reader[6];
                            }
                            if (!(reader[7] == System.DBNull.Value))
                            {
                                b.Brand = (int)reader[7];
                            }
                            if (!(reader[8] == System.DBNull.Value))
                            {
                                b.Description = (string)reader[8];
                            }
                            if (!(reader[9] == System.DBNull.Value))
                            {
                                b.Prix = (double)reader[9];
                            }

                            if (!(reader[10] == System.DBNull.Value))
                            {
                                b.ImageSource = (string)reader[10];
                            }
                            
                        }
                        conn.Close();
                        return b;
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
