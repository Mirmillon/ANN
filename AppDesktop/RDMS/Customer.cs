

namespace AppDesktop.RDMS
{
    internal class Customer
    {
        internal int SetCustomer(string name, string lastName, string phone)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_CUSTOMER";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("NAME", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = name;
                pc.Add("LNAME", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 30).Value = lastName;
                pc.Add("PHONE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 11).Value = phone;
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

        internal System.Collections.Generic.List<Classes.Customers> GetCustomers()
        {
            System.Collections.Generic.List<Classes.Customers> l = new System.Collections.Generic.List<Classes.Customers>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GET_CUSTOMERS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Customers b = new Classes.Customers();
                            b.Cle = (int)reader[0];
                            b.Name = (string)reader[1];
                            if (!(reader[2] == System.DBNull.Value))
                            {
                                b.MiddleName = (string)reader[2];
                            }
                            b.LastName = (string)reader[3];
                            if (!(reader[4] == System.DBNull.Value))
                            {
                                b.Phone = (string)reader[4];
                            }
                            if (!(reader[5] == System.DBNull.Value))
                            {
                                b.Note = (string)reader[5];
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

        internal void  SetCustomerSale(int cleVente, int cleCustomer)
        {

            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_CUSTOMER_SALE";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("SALE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleVente;
                pc.Add("CUSTOMER", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleCustomer;
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
    }
}
