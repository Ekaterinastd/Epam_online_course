using System.Globalization;

namespace M7.Framework_Fundamentals
{
    public class Customer
    {
        public string Name;
        public string ContactPhone;
        public decimal Revenue;

        //добавить форматирование для дохода и телефона
        public override string ToString()
        {
            var nfi = new NumberFormatInfo() { NumberGroupSeparator = ",", NumberDecimalDigits=2, NumberDecimalSeparator="." };
            if (Name == null)
                if (ContactPhone == null)
                    return string.Format("Customer record: {0}",Revenue.ToString("N", nfi));
                else return string.Format("Customer record: {0:+# (###) ###-####}", ContactPhone);
            else 
            {
                if (ContactPhone == null)
                    if (Revenue==0)
                        return string.Format("Customer record: {0}", Name);
                    else return string.Format("Customer record: {0}, {1}", Name, Revenue);
                else
                {
                    if (Revenue == 0)
                       return string.Format("Customer record: {0}, {1:+# (###) ###-####}", Name, ContactPhone);
                    else return string.Format("Customer record: {0}, {1}, {2:+# (###) ###-####}", Name, Revenue.ToString("N", nfi), ContactPhone);

                }
            }            
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj.ToString());
        }
    }
}
