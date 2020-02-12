using System;
using System.Linq;
using System.Text;

namespace M7.Framework_Fundamentals
{
    public static class BigNumbers
    {
        public static string GetSum(string n1, string n2)
        {
            if (n1.Length == 0 && n2.Length == 0)
                return "0";
            var result = new StringBuilder();
            n1 = Reverse(n1);
            n2 = Reverse(n2);
            if (n1.Contains("-") ^ n2.Contains("-"))
            {
                return SumDifSignsNumbers(n1, n2);
            }
            else
            {
                return SumSameSignslNumbers(n1, n2);
            }
        }

        private static string Reverse(string input)
        {
            var symbols = input.ToCharArray();
            Array.Reverse(symbols);
            return new string(symbols);
        }

        private static string SumSameSignslNumbers(string rev_n1, string rev_n2)
        {
            var result = new StringBuilder();
            var remainder = 0;
            var sum = 0;
            var isNegative = false;
            if (rev_n1.Contains("-") && rev_n2.Contains("-"))
            {
                rev_n1 = rev_n1.Substring(0, rev_n1.Length - 1);
                rev_n2 = rev_n2.Substring(0, rev_n2.Length - 1);
                isNegative = true;
            }

            for (var i = 0; i < Math.Max(rev_n1.Length, rev_n2.Length); i++)
            {
                sum = i >= rev_n1.Length ? 0 : rev_n1[i] - '0';
                sum += i >= rev_n2.Length ? 0 : rev_n2[i] - '0';
                sum += remainder;
                if (sum > 9)
                {
                    remainder = 1;
                    sum -= 10;
                }
                else
                    remainder = 0;

                result.Append(sum);
            }

            if (remainder == 1)
                result.Append(remainder);
            if (isNegative)
                result.Append("-");
            return Reverse(result.ToString());
        }

        private static string SumDifSignsNumbers(string n1, string n2)
        {
            var result = new StringBuilder();
            var loan = 0; //заём
            var diff = 0;//разность
            var multiLevel_Loan = false;
            var rev_n1 = "";
            var rev_n2 = "";
            if (n1.Contains("-"))
                rev_n1 = n1.Substring(0, n1.Length - 1);
            else rev_n1 = n1;

            if (n2.Contains("-"))
                rev_n2 = n2.Substring(0, n2.Length - 1);
            else rev_n2 = n2;

            if (rev_n1.Length >= rev_n2.Length)//если уменьшаемое (по длине) больше или равно вычитаемого
            {
                for (var i = 0; i < Math.Max(rev_n1.Length, rev_n2.Length); i++)
                {
                    if (i < rev_n2.Length)
                    {
                        diff = rev_n1[i] - rev_n2[i] - loan;

                        if (multiLevel_Loan)//если нельзя занять у следующего разряда (он = 0)
                        {
                            if (diff < 0)
                            {
                                diff += 9;
                                if (i < rev_n1.Length - 1 && rev_n1[i + 1] > 0)
                                {
                                    loan = 1;
                                    multiLevel_Loan = false;
                                }
                                else loan = 0;
                            }
                            else loan = 0;
                        }
                        else
                        {
                            if (diff < 0)
                            {
                                diff += 10;
                                loan = 1;
                                if (i < rev_n1.Length - 1 && rev_n1[i + 1] == '0')
                                    multiLevel_Loan = true;
                            }
                            else loan = 0;
                        }

                        result.Append(diff);
                    }
                    else if (i == rev_n2.Length && loan == 1)
                        if (rev_n1[i] != '0')
                            result.Append(rev_n1[i] - 1 - '0');
                        else
                        {
                            multiLevel_Loan = true;
                            if (multiLevel_Loan)//если нельзя занять у следующего разряда (он = 0)
                            {
                                if (i < rev_n1.Length - 1 && rev_n1[i + 1] != '0')
                                {
                                    loan = 1;
                                    multiLevel_Loan = false;
                                }
                                else loan = 0;
                                result.Append(9);

                            }
                        }
                    else if (multiLevel_Loan)
                    {
                        if (i == rev_n1.Length - 2 && rev_n1[i + 1] != '0')
                        {
                            loan = 1;
                            multiLevel_Loan = false;
                        }
                        result.Append(9);
                    }

                    else result.Append(rev_n1[i] - '0' - loan);
                }
            }
            else//если уменьшаемое (по длине) меньше вычитаемого
            {
                for (var i = 0; i < Math.Max(rev_n1.Length, rev_n2.Length); i++)
                {
                    if (i < rev_n1.Length)
                    {
                        diff = rev_n2[i] - rev_n1[i] - loan;

                        if (multiLevel_Loan)//если нельзя занять у следующего разряда (он = 0)
                        {
                            if (diff < 0)
                            {
                                diff += 9;
                                if (i < rev_n2.Length - 1 && rev_n2[i + 1] > 0)
                                {
                                    loan = 1;
                                    multiLevel_Loan = false;
                                }
                                else loan = 0;
                            }
                            else loan = 0;
                        }
                        else
                        {
                            if (diff < 0)
                            {
                                diff += 10;
                                loan = 1;
                                if (i < rev_n2.Length - 1 && rev_n2[i + 1] == '0')
                                    multiLevel_Loan = true;
                            }
                            else loan = 0;
                        }

                        result.Append(diff);
                    }
                    else if (i == rev_n1.Length && loan == 1)
                        if (rev_n2[i] != '0')
                            result.Append(rev_n2[i] - 1 - '0');
                        else
                        {
                            multiLevel_Loan = true;
                            if (multiLevel_Loan)//если нельзя занять у следующего разряда (он = 0)
                            {
                                if (i < rev_n2.Length - 1 && rev_n2[i + 1] != '0')
                                {
                                    loan = 1;
                                    multiLevel_Loan = false;
                                }
                                else loan = 0;
                                result.Append(9);
                            }
                        }
                    else if (multiLevel_Loan)
                    {
                        if (i == rev_n2.Length - 2 && rev_n2[i + 1] != '0')
                        {
                            loan = 1;
                            multiLevel_Loan = false;
                        }
                        result.Append(9);
                    }

                    else result.Append(rev_n2[i] - '0' - loan);
                }
            }

            while (result.Length > 0 && result[result.Length - 1] == '0')
            {
                result.Remove(result.Length - 1, 1);
            }
            if (result.Length == 0)
                return "0";

            if ((n1.Length > n2.Length && n1.Contains('-')) || (n1.Length < n2.Length && n2.Contains('-')))
                result.Append('-');
            if (rev_n1.Length == rev_n2.Length)
            {
                for (var j = rev_n1.Length; j <= 0; j--)
                    if (rev_n1[j] - '0' < rev_n2[j] - '0')
                    {
                        result.Append('-');
                        break;
                    }
            }
            return Reverse(result.ToString());
        }
    }
}
