/*SALE D_FK NOT NULL,
 MONTANT D_MONEY NOT NULL,
  DATE_INCOME D_DATE*/

namespace AppDesktop.RDMS
{
    internal class Income
    {

        internal double GetCashCurrentYear() { return new Generic().GetDouble("GET_CASH_CURRENT_YEAR"); }

        internal int SetIncome(int cleVente, double argent, System.DateTime d)
        {
            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_INCOME";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("SELLING", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = cleVente;
                pc.Add("MONTANT", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = argent;
                pc.Add("DATEDUE", FirebirdSql.Data.FirebirdClient.FbDbType.Date, 0).Value = d;
               
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
    }
}
