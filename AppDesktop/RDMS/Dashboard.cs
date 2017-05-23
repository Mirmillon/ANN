

namespace AppDesktop.RDMS
{
    internal class Dashboard
    {
        internal double GetIncome()
        {
            return new Generic().GetDouble("GET_INCOME");
        }

        internal int GetNbItems()
        {
           return new Generic().GetNombre("GET_NB_ITEMS");
        }
    }
}
