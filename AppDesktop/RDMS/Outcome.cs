
namespace AppDesktop.RDMS
{
    class Outcome
    {
        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetKindOutcome()
        {
            return new Generic().GetReferencesSimples("GET_OUTCOME_KINDS");
        }


        internal int SetOutcome(System.DateTime d, int c, double m , string note)
        {

            int cle = 0;
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "SET_OUTCOME";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FirebirdSql.Data.FirebirdClient.FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Direction = System.Data.ParameterDirection.Output;
                pc.Add("DATE", FirebirdSql.Data.FirebirdClient.FbDbType.Date, 0).Value = d;
                pc.Add("OUTCOME", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = c;
                pc.Add("MONTANT", FirebirdSql.Data.FirebirdClient.FbDbType.Double, 0).Value = m;
                pc.Add("NOTE", FirebirdSql.Data.FirebirdClient.FbDbType.VarChar, 300).Value = note;
                

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
