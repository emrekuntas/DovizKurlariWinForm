using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dövizKurları
{
    class Doviz
    {
        
        private string currencyCode;

        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        private string currencyName;

        public string CurrencyName
        {
            get { return currencyName; }
            set { currencyName = value; }
        }


        private decimal forexBuying;

        public decimal ForexBuying
        {
            get { return forexBuying; }
            set { forexBuying = value; }
        }

        private decimal forexSelling;

        public decimal ForexSelling
        {
            get { return forexSelling; }
            set { forexSelling = value; }
        }


        public override string ToString()
        {
            return CurrencyName;
        }

    }
}
