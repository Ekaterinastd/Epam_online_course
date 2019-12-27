using System.Diagnostics;

namespace M4.Methods_in_details
{
    public static class NullableExtension
    {
        public static bool IsNull(this object x)
        {
            return x == null;            
        }
    }
}
