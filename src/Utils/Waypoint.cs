namespace Chloride.RA2.MapExt.Utils;

public static class Waypoint {
    private static readonly List<char> Alphabet = Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => (char)x).ToList();

    public static string ToString(int num)
    {
        List<char> ret = new();
        if (num > 25)
        {
            while (true)
            {
                int d = num / 26;
                int remainder = num % 26;
                if (d <= 26)
                {
                    ret.Insert(0, Alphabet[remainder]);
                    ret.Insert(0, Alphabet[d - 1]);
                    break;
                }
                else
                {
                    ret.Insert(0, Alphabet[remainder]);
                    num = d - 1;
                }
            }
        }
        else
        {
            ret.Add(Alphabet[num]);
        }
        return new string(ret.ToArray());
    }

    public static int ToInt32(string wp)
    {
        wp = wp.ToUpper(); // make sure all in Alphabet.

        int ret = 0;
        if (wp.Length > 1)
        {
            for (int i = 0; i < wp.Length - 1; i++)
            {
                int idx = Alphabet.IndexOf(wp[i]);
                double num = Math.Pow(26, wp.Length - 1) * (idx + 1);
                ret += (int)num;
            }
            ret += Alphabet.IndexOf(wp.Last());
        }
        else
        {
            ret = Alphabet.IndexOf(wp.Last());
        }
        return ret;
    }
}