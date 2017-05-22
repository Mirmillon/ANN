
namespace AppDesktop.RDMS
{
    internal class Selling
    {
        internal System.Collections.Generic.List<Classes.Sellings> GetSellings()
        {
            /*
              CLE TYPE OF D_PK,
  DATE_SELLING TYPE OF D_DATE,
  NUMBER_ITEMS TYPE OF D_NOMBRE,
  AMOUNT TYPE OF D_MONEY,
  KIND_PAYMENT TYPE OF D_FK,
  CASH TYPE OF D_MONEY,
  CUSTOMER TYPE OF D_FK,
  DATE_DUE TYPE OF D_DATE*/
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
                                b.Customer = (int)reader[6];
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

    }
}
