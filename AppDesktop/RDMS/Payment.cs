﻿

namespace AppDesktop.RDMS
{
    internal class Payment
    {
        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetKindPayment()
        {
            return new Generic().GetReferencesSimples("GET_PAYMENT_KINDS");
        }

        internal int SetPayment(int sale, int credit, double money, System.DateTime d)
        {
            int cle = -1;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_PAYMENT";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("SALE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = sale;
                pc.Add("CREDIT", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = credit;
                pc.Add("CASH", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = money;
                pc.Add("DATE", FirebirdSql.Data.FirebirdClient.FbDbType.Date, 0).Value = d;
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
    }
}
