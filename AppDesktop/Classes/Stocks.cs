

namespace AppDesktop.Classes
{
    internal class Stocks : Bundles
    {
    
        int cleStock;
        double costItems;
        

  
        public int CleStock1 { get => cleStock; set => cleStock = value; }
        public double CostItems {
            get
            {
                if(NbItems > 0)
                {
                    return System.Math.Round (Prix / NbItems,2);
                }
                else
                {
                    return 0;
                }

            }
                

            set => costItems = value;
        }
    }
}
