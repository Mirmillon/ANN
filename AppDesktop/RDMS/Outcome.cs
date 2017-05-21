
namespace AppDesktop.RDMS
{
    class Outcome
    {
        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetKindOutcome()
        {
            return new Generic().GetReferencesSimples("GET_OUTCOME_KINDS");
        }
    }
}
