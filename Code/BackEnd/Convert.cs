using System.Numerics;
using System.Text;

namespace OpenKey.BackEnd
{
    public static class Convert
    {
        public static string BigIntegersToString(BigInteger[] bigIntegers)
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < bigIntegers.Length; i++)
            {
                text.Append(bigIntegers[i].ToString() + " ");
            }
            return text.ToString();
        }
    }
}