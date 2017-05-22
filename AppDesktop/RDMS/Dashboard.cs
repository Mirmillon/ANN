

namespace AppDesktop.RDMS
{
    internal class Dashboard
    {
        internal double GetIncome()
        {
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "GET_INCOME";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    double income   = (double)commande.ExecuteScalar();
                    conn.Close();
                    return income;
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
