
namespace AppDesktop.RDMS
{
    class Outcome
    {
        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetKindOutcome()   {   return new Generic().GetReferencesSimples("GET_OUTCOME_KINDS"); }

        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetCatagoriesOutcome() { return new Generic().GetReferencesSimples("GET_OUTCOME_CATEGORIES"); }

        internal double  GetOutcomeCurrentYear()   { return new Generic().GetDouble("GET_OUTCOMES_CURRENT_YEAR"); }

        internal double GetInvestmentCurrentYear() { return new Generic().GetDouble("GET_INVESMENT_CURRENT_YEAR"); }

        internal double GetOperatingCurrentYear() { return new Generic().GetDouble("GET_OPERATING_CURRENT_YEAR"); }

        internal int SetOutcome(System.DateTime d, int c, double m , string note, int categorie)
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
                pc.Add("CATEGORIE", FirebirdSql.Data.FirebirdClient.FbDbType.Integer, 0).Value = categorie;
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

        internal System.Collections.Generic.List<Classes.Outcomes> GetOutcome()
        {
            System.Collections.Generic.List<Classes.Outcomes> l = new System.Collections.Generic.List<Classes.Outcomes>();
            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection(new Connexion().ChaineConnection());
            using (FirebirdSql.Data.FirebirdClient.FbCommand commande = conn.CreateCommand())
            {
                commande.CommandText = "GET_OUTCOMES";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    FirebirdSql.Data.FirebirdClient.FbDataReader reader = commande.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Classes.Outcomes b = new Classes.Outcomes();
                            b.Cle = (int)reader[0];
                            b.DateOutcome = System.Convert.ToDateTime(reader[1]);
                            b.CleTypeOutcome = (int)reader[2];
                            b.Montant = (double)reader[3];
                            if (!(reader[4] == System.DBNull.Value))
                            {
                                b.Note = (string)reader[4];
                            }
                            b.Categorie = (int)reader[5];
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
