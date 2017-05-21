

namespace AppDesktop.RDMS
{
    internal class Payment
    {
        internal System.Collections.Generic.List<Classes.ReferencesSimples> GetKindPayment()
        {
            return new Generic().GetReferencesSimples("GET_PAYMENT_KINDS");
        }
    }
}
