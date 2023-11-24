using System.Globalization;

namespace EMR.WebAPI.ehr.models
{
    public class ClaimMonthlySummary
    {
        public ClaimMonthlySummary()
        {

        }

        public int Month { get; set; }

        public int Year { get; set; }

        public string MonthName
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.Month);
            }
        }

        public int TotalClaims { get; set; }

        public decimal TotalAmount { get; set; }
    }
}