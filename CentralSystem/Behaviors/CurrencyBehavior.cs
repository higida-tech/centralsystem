using System.Globalization;
using System.Text.RegularExpressions;

namespace CentralSystem.Behaviors
{
    public class CurrencyBehavior : Behavior<Entry>
    {
        private static string _empty = "0" + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator + "00";

        protected override void OnAttachedTo(Entry entry)
        {
            entry.Text = _empty;
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            Regex rx1 = new Regex(@",*");
            Regex rx2 = new Regex(@"^0*");

            string old_value = rx2.Replace(
                rx1.Replace(args.OldTextValue, string.Empty),
                string.Empty
                );
            
            string new_value = rx2.Replace(
                rx1.Replace(args.NewTextValue, string.Empty),
                string.Empty
                );

            if (old_value == new_value) return;
            if (string.IsNullOrEmpty(new_value)) return;
            
            entry.Text = string.Format("{0:0.00}", double.Parse(new_value) / 100);
        }
    }
}
