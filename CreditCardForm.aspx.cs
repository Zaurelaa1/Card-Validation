using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CreditCard
{
   
   
    public partial class CreditCardForm : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
        protected void btnCheck_Click(object sender, EventArgs e)
        {

            try
            {
                custCardNumber.IsValid = CardNumberValid(txtCardNo.Text);
                custValidExpire.IsValid = ValidExpiration();
                custValidCVV.IsValid = ValidateCVVCode();
                lblCardType.Text = GetCardType(txtCardNo.Text).ToString();


            }
            catch (FormatException)
            {
                custCardNumber.ErrorMessage = "Invalid Card Number";
                custValidExpire.ErrorMessage = "Invalid Expire Date";
                custValidCVV.ErrorMessage = "Invalid CVV Code";

            }

        }


        public  bool CardNumberValid(string cardNumber)
        {
            int i, checkSum = 0;

            // Compute checksum of every other digit starting from right-most digit
            for (i = cardNumber.Length - 1; i >= 0; i -= 2)
                checkSum += (cardNumber[i] - '0');

            // Now take digits not included in first checksum, multiple by two,
            // and compute checksum of resulting digits
            for (i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int val = ((cardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    checkSum += (val % 10);
                    val /= 10;
                }
            }

            // Number is valid if sum of both checksums MOD 10 equals 0
            return ((checkSum % 10) == 0);
        }

        // CARD TYPE
        public enum CardType
        {
            Unknown = 0,
            MasterCard = 1,
            VISA = 2,
            Amex = 3,
            Discover = 4,
            DinersClub = 5,
            JCB = 6,
            enRoute = 7
        }

        // Class to hold credit card type information
        private class CardTypeInfo
        {
            public CardTypeInfo(string regEx, int length, CardType type)
            {
                RegEx = regEx;
                Length = length;
                Type = type;
            }

            public string RegEx { get; set; }
            public int Length { get; set; }
            public CardType Type { get; set; }
        }

        // Array of CardTypeInfo objects.
        // Used by GetCardType() to identify credit card types.
        private static CardTypeInfo[] _cardTypeInfo =
        {
  new CardTypeInfo("^(51|52|53|54|55)", 16, CardType.MasterCard),
  new CardTypeInfo("^(4)", 16, CardType.VISA),
  new CardTypeInfo("^(4)", 13, CardType.VISA),
  new CardTypeInfo("^(34|37)", 15, CardType.Amex),
  new CardTypeInfo("^(6011)", 16, CardType.Discover),
  new CardTypeInfo("^(300|301|302|303|304|305|36|38)",
                   14, CardType.DinersClub),
  new CardTypeInfo("^(3)", 16, CardType.JCB),
  new CardTypeInfo("^(2131|1800)", 15, CardType.JCB),
  new CardTypeInfo("^(2014|2149)", 15, CardType.enRoute),
};

        public static CardType GetCardType(string cardNumber)
        {
            foreach (CardTypeInfo info in _cardTypeInfo)
            {
                if (cardNumber.Length == info.Length &&
                    Regex.IsMatch(cardNumber, info.RegEx))
                    return info.Type;
            }

            return CardType.Unknown;
        }

        //SECOND PART OF THE CODE
        //strat ValidExpiration()
        public bool ValidExpiration()
        {
            string[] date = Regex.Split(txtExpire.Text, "/");
            string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yyyy"), "/");
            int compareYears = string.Compare(date[1], currentDate[1]);
            int compareMonths = string.Compare(date[0], currentDate[0]);

            //if expiration date is in MM/YYYY format
            if (Regex.Match(txtExpire.Text, @"^\d{2}/\d{4}$").Success)
            {
                //if month is "01-12" and year starts with "20"
                if (Regex.Match(date[0], @"^[0][1-9]|[1][0-2]$").Success)
                {
                    //if expiration date is after current date
                    if ((compareYears == 1) || (compareYears == 0 && (compareMonths == 1)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }//end ValidExpiration()


        //start ValidateCVVCode() 
        public bool ValidateCVVCode()
        {
            bool isValid = Regex.Match(txtCVV.Text, @"^\d{3}$").Success;
            return isValid;
        }//end ValidateCVVCode()
    }
}