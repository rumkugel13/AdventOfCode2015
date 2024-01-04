using System.Drawing;
using System.Text;

namespace AdventOfCode2015
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AoC2015");
            Console.Write("Day 01 Part 01: "); Day01Part01();
            Console.Write("Day 01 Part 02: "); Day01Part02();
            Console.Write("Day 02 Part 01: "); Day02Part01();
            Console.Write("Day 02 Part 02: "); Day02Part02();
            Console.Write("Day 03 Part 01: "); Day03Part01();
            Console.Write("Day 03 Part 02: "); Day03Part02();
            Console.Write("Day 04 Part 01: "); int d04p1 = Day04Part01();
            Console.Write("Day 04 Part 02: "); Day04Part02(d04p1);
            Console.Write("Day 05 Part 01: "); Day05Part01();
            Console.Write("Day 05 Part 02: "); Day05Part02();
            Console.Write("Day 06 Part 01: "); Day06Part01();
            Console.Write("Day 06 Part 02: "); Day06Part02();
            Console.Write("Day 07 Part 01: "); ushort d07p1 = Day07Part01();
            Console.Write("Day 07 Part 02: "); Day07Part02(d07p1);
            Console.Write("Day 08 Part 01: "); Day08Part01();
            Console.Write("Day 08 Part 02: "); Day08Part02();
            Console.Write("Day 09 Part 01: "); Day09Part01();
            Console.Write("Day 09 Part 02: "); Day09Part02();
            Console.Write("Day 10 Part 01: "); Day10Part01();
            Console.Write("Day 10 Part 02: "); Day10Part02();
            Console.Write("Day 11 Part 01: "); string d11p1 = Day11Part01();
            Console.Write("Day 11 Part 02: "); Day11Part02(d11p1);
            Console.Write("Day 12 Part 01: "); Day12Part01();
            Console.Write("Day 12 Part 02: "); Day12Part02();
            Console.Write("Day 13 Part 01: "); Day13Part01();
            Console.Write("Day 13 Part 02: "); Day13Part02();
            Console.Write("Day 14 Part 01: "); Day14Part01();
            Console.Write("Day 14 Part 02: "); Day14Part02();
            Console.Write("Day 15 Part 01: "); Day15Part01();
            Console.Write("Day 15 Part 02: "); Day15Part02();
            Console.Write("Day 16 Part 01: "); Day16Part01();
            Console.Write("Day 16 Part 02: "); Day16Part02();
            //Console.Write("Day 17 Part 01: "); Day17Part01();
            //Console.Write("Day 17 Part 02: "); Day17Part02();
        }

        static void Day01Part01()
        {
            int floor = 0;
            string input = File.ReadAllText("input/01.txt");
            foreach (char c in input)
            {
                floor += c == '(' ? 1 : -1;
            }

            Console.WriteLine(floor);
        }

        static void Day01Part02()
        {
            int floor = 0;
            string input = File.ReadAllText("input/01.txt");
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                floor += c == '(' ? 1 : -1;
                if (floor == -1)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        static void Day02Part01()
        {
            string[] input = File.ReadAllLines("input/02.txt");
            int squareFeet = 0;

            foreach (string box in input)
            {
                var sides = box.Split('x');
                int[] lengths = new int[3] { int.Parse(sides[0]), int.Parse(sides[1]), int.Parse(sides[2]) };

                squareFeet += 2 * lengths[0] * lengths[1] + 2 * lengths[1] * lengths[2] + 2 * lengths[2] * lengths[0];
                squareFeet += Math.Min(lengths[0] * lengths[1], Math.Min(lengths[1] * lengths[2], lengths[2] * lengths[0]));
            }

            Console.WriteLine(squareFeet);
        }

        static void Day02Part02()
        {
            string[] input = File.ReadAllLines("input/02.txt");
            int feet = 0;

            foreach (string box in input)
            {
                var sides = box.Split('x');
                int[] lengths = new int[3] { int.Parse(sides[0]), int.Parse(sides[1]), int.Parse(sides[2]) };

                feet += Math.Min(2 * (lengths[0] + lengths[1]), Math.Min(2 * (lengths[1] + lengths[2]), 2 * (lengths[2] + lengths[0])));
                feet += lengths[0] * lengths[1] * lengths[2];
            }

            Console.WriteLine(feet);
        }

        static void Day03Part01()
        {
            Point pos = Point.Empty;
            HashSet<Point> visited = new HashSet<Point>();
            visited.Add(pos);

            string input = File.ReadAllText("input/03.txt");
            foreach (char c in input)
            {
                switch (c)
                {
                    case '^': pos.Y--; break;
                    case 'v': pos.Y++; break;
                    case '<': pos.X--; break;
                    case '>': pos.X++; break;
                }

                visited.Add(pos);
            }

            Console.WriteLine(visited.Count);
        }

        static void Day03Part02()
        {
            Point pos = Point.Empty;
            Point posRobo = Point.Empty;
            HashSet<Point> visited = new HashSet<Point>();
            visited.Add(pos);
            visited.Add(posRobo);

            string input = File.ReadAllText("input/03.txt");
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (i % 2 == 0)
                {
                    switch (c)
                    {
                        case '^': pos.Y--; break;
                        case 'v': pos.Y++; break;
                        case '<': pos.X--; break;
                        case '>': pos.X++; break;
                    }

                    visited.Add(pos);
                }
                else
                {
                    switch (c)
                    {
                        case '^': posRobo.Y--; break;
                        case 'v': posRobo.Y++; break;
                        case '<': posRobo.X--; break;
                        case '>': posRobo.X++; break;
                    }

                    visited.Add(posRobo);
                }
            }

            Console.WriteLine(visited.Count);
        }

        static int Day04Part01()
        {
            string input = File.ReadAllText("input/04.txt");

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                for (int i = 1; ; i++)
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input + i);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    if (hashBytes[2] <= 0xF && hashBytes[1] == 0 && hashBytes[0] == 0)
                    {
                        Console.WriteLine(i);
                        return i;
                    }
                }
            }
        }

        static void Day04Part02(int start)
        {
            string input = File.ReadAllText("input/04.txt");

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                for (int i = start; ; i++)
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input + i);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    if (hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] == 0)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
        }

        static void Day05Part01()
        {
            string[] input = File.ReadAllLines("input/05.txt");
            int nice = 0;

            foreach (string line in input)
            {
                int vowels = 0;
                bool twice = false;
                bool naughty = false;

                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            vowels++;
                            break;
                    }

                    if (i < line.Length - 1 && line[i] == line[i + 1])
                        twice = true;

                    if (i < line.Length - 1 && (
                        (line[i] == 'a' && line[i + 1] == 'b')
                        || (line[i] == 'c' && line[i + 1] == 'd')
                        || (line[i] == 'p' && line[i + 1] == 'q')
                        || (line[i] == 'x' && line[i + 1] == 'y')))
                    {
                        naughty = true;
                        break;
                    }
                }

                if (vowels >= 3 && twice && !naughty)
                    nice++;
            }

            Console.WriteLine(nice);
        }

        static void Day05Part02()
        {
            string[] input = File.ReadAllLines("input/05.txt");
            int nice = 0;

            foreach (string line in input)
            {
                bool twicePair = false;
                bool inBetween = false;

                for (int i = 0; i < line.Length; i++)
                {
                    if (i < line.Length - 1)
                    {
                        string pair = line.Substring(i, 2);
                        if (line.LastIndexOf(pair) > i + 1)
                            twicePair = true;
                    }

                    if (i > 0 && i < line.Length - 1 && line[i - 1] == line[i + 1])
                    {
                        inBetween = true;
                    }
                }

                if (twicePair && inBetween)
                    nice++;
            }

            Console.WriteLine(nice);
        }

        static void Day06Part01()
        {
            string[] input = File.ReadAllLines("input/06.txt");
            bool[,] lights = new bool[1000, 1000];

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                int[] coords = new int[4]
                {
                    int.Parse(parts[parts.Length-3].Split(',')[0]),
                    int.Parse(parts[parts.Length-3].Split(',')[1]),
                    int.Parse(parts[parts.Length-1].Split(',')[0]),
                    int.Parse(parts[parts.Length-1].Split(',')[1])
                };

                for (int x = coords[0]; x <= coords[2]; x++)
                {
                    for (int y = coords[1]; y <= coords[3]; y++)
                    {
                        switch (line[6])
                        {
                            case 'n': lights[x, y] = true; break;
                            case 'f': lights[x, y] = false; break;
                            case ' ': lights[x, y] = !lights[x, y]; break;
                        }
                    }
                }
            }

            int count = 0;
            foreach (var some in lights)
            {
                if (some) count++;
            }

            Console.WriteLine(count);
        }

        static void Day06Part02()
        {
            string[] input = File.ReadAllLines("input/06.txt");
            int[,] lights = new int[1000, 1000];

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                int[] coords = new int[4]
                {
                    int.Parse(parts[parts.Length-3].Split(',')[0]),
                    int.Parse(parts[parts.Length-3].Split(',')[1]),
                    int.Parse(parts[parts.Length-1].Split(',')[0]),
                    int.Parse(parts[parts.Length-1].Split(',')[1])
                };

                for (int x = coords[0]; x <= coords[2]; x++)
                {
                    for (int y = coords[1]; y <= coords[3]; y++)
                    {
                        switch (line[6])
                        {
                            case 'n': lights[x, y] += 1; break;
                            case 'f': lights[x, y] = Math.Max(0, lights[x, y] - 1); break;
                            case ' ': lights[x, y] += 2; break;
                        }
                    }
                }
            }

            int count = 0;
            foreach (var some in lights)
            {
                count += some;
            }

            Console.WriteLine(count);
        }

        static ushort Day07Part01()
        {
            string[] input = File.ReadAllLines("input/07.txt");
            Dictionary<string, ushort> values = new Dictionary<string, ushort>();
            Queue<string> gates = new Queue<string>();

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                if (parts.Length == 3 && ushort.TryParse(parts[0], out ushort num))
                {
                    values[parts[2]] = num;
                }
                else
                {
                    gates.Enqueue(line);
                }
            }

            while (gates.Count > 0)
            {
                var gate = gates.Dequeue();
                var parts = gate.Split(' ');

                if (parts.Length > 4)
                {
                    if ((ushort.TryParse(parts[0], out ushort val1) || values.TryGetValue(parts[0], out val1))
                        && (ushort.TryParse(parts[2], out ushort val2) || values.TryGetValue(parts[2], out val2)))
                    {
                        switch (parts[1])
                        {
                            case "AND": values[parts[4]] = (ushort)(val1 & val2); break;
                            case "OR": values[parts[4]] = (ushort)(val1 | val2); break;
                            case "LSHIFT": values[parts[4]] = (ushort)(val1 << val2); break;
                            case "RSHIFT": values[parts[4]] = (ushort)(val1 >> val2); break;
                        }
                    }
                    else
                    {
                        gates.Enqueue(gate);
                    }
                }
                else if (parts.Length > 3)
                {
                    if (values.TryGetValue(parts[1], out ushort val))
                    {
                        values[parts[3]] = (ushort)~val;
                    }
                    else
                    {
                        gates.Enqueue(gate);
                    }
                }
                else
                {
                    if (values.ContainsKey(parts[0]))
                    {
                        values[parts[2]] = values[parts[0]];
                    }
                    else
                    {
                        gates.Enqueue(gate);
                    }
                }
            }

            Console.WriteLine(values["a"]);
            return values["a"];
        }

        static void Day07Part02(ushort part1)
        {
            string[] input = File.ReadAllLines("input/07.txt");
            Dictionary<string, ushort> values = new Dictionary<string, ushort>();
            Queue<string> gates = new Queue<string>();

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                if (parts.Length == 3 && ushort.TryParse(parts[0], out ushort num))
                {
                    values[parts[2]] = num;
                }
                else
                {
                    gates.Enqueue(line);
                }
            }

            values["b"] = part1;

            while (gates.Count > 0)
            {
                var gate = gates.Dequeue();
                var parts = gate.Split(' ');

                if (parts.Length > 4)
                {
                    if ((ushort.TryParse(parts[0], out ushort val1) || values.TryGetValue(parts[0], out val1))
                        && (ushort.TryParse(parts[2], out ushort val2) || values.TryGetValue(parts[2], out val2)))
                    {
                        switch (parts[1])
                        {
                            case "AND": values[parts[4]] = (ushort)(val1 & val2); break;
                            case "OR": values[parts[4]] = (ushort)(val1 | val2); break;
                            case "LSHIFT": values[parts[4]] = (ushort)(val1 << val2); break;
                            case "RSHIFT": values[parts[4]] = (ushort)(val1 >> val2); break;
                        }
                    }
                    else
                    {
                        gates.Enqueue(gate);
                    }
                }
                else if (parts.Length > 3)
                {
                    if (values.TryGetValue(parts[1], out ushort val))
                    {
                        values[parts[3]] = (ushort)~val;
                    }
                    else
                    {
                        gates.Enqueue(gate);
                    }
                }
                else
                {
                    if (values.ContainsKey(parts[0]))
                    {
                        values[parts[2]] = values[parts[0]];
                    }
                    else
                    {
                        gates.Enqueue(gate);
                    }
                }
            }

            Console.WriteLine(values["a"]);
        }

        static void Day08Part01()
        {
            string[] input = File.ReadAllLines("input/08.txt");
            int codeCount = 0;
            int memCount = 0;

            foreach (string line in input)
            {
                codeCount += line.Length;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\\')
                    {
                        if (line[i + 1] == 'x')
                        {
                            i += 3;
                            memCount++;
                        }
                        else
                        {
                            i++;
                            memCount++;
                        }
                    }
                    else
                    {
                        memCount++;
                    }
                }

                memCount -= 2;
            }

            Console.WriteLine(codeCount - memCount);
        }

        static void Day08Part02()
        {
            string[] input = File.ReadAllLines("input/08.txt");
            int codeCount = 0;
            int encodedCount = 0;

            foreach (string line in input)
            {
                codeCount += line.Length;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\"' || line[i] == '\\')
                    {
                        encodedCount += 2;
                    }
                    else
                        encodedCount++;
                }
                encodedCount += 2;
            }

            Console.WriteLine(encodedCount - codeCount);
        }

        static void Day09Part01()
        {
            string[] input = File.ReadAllLines("input/09.txt");
            HashSet<string> allCities = new HashSet<string>();
            Dictionary<string, int> distances = new Dictionary<string, int>();

            List<List<string>> permutations = new List<List<string>>();
            Stack<List<string>> temp = new Stack<List<string>>();

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                string city1 = parts[0];
                string city2 = parts[2];
                int distance = int.Parse(parts[4]);
                if (allCities.Add(city1))
                {
                    temp.Push(new List<string>() { city1 });
                }
                if (allCities.Add(city2))
                {
                    temp.Push(new List<string>() { city2 });
                }

                distances.TryAdd(city1.CompareTo(city2) > 0 ? city1 + city2 : city2 + city1, distance);
            }

            while (temp.Count > 0)
            {
                var perm = temp.Pop();
                if (perm.Count == allCities.Count)
                {
                    permutations.Add(perm);
                    continue;
                }

                foreach (string city in allCities)
                {
                    if (perm.Contains(city)) continue;
                    var t = new List<string>(perm) { city };
                    temp.Push(t);
                }
            }

            int min = int.MaxValue;

            foreach (var permutation in permutations)
            {
                int permSum = 0;
                for (int i = 0; i < permutation.Count - 1; i++)
                {
                    permSum += distances[permutation[i].CompareTo(permutation[i + 1]) > 0
                        ? permutation[i] + permutation[i + 1]
                        : permutation[i + 1] + permutation[i]];
                }

                min = Math.Min(min, permSum);
            }

            Console.WriteLine(min);
        }

        static void Day09Part02()
        {
            string[] input = File.ReadAllLines("input/09.txt");
            HashSet<string> allCities = new HashSet<string>();
            Dictionary<string, int> distances = new Dictionary<string, int>();

            List<List<string>> permutations = new List<List<string>>();
            Stack<List<string>> temp = new Stack<List<string>>();

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                string city1 = parts[0];
                string city2 = parts[2];
                int distance = int.Parse(parts[4]);
                if (allCities.Add(city1))
                {
                    temp.Push(new List<string>() { city1 });
                }
                if (allCities.Add(city2))
                {
                    temp.Push(new List<string>() { city2 });
                }

                distances.TryAdd(city1.CompareTo(city2) > 0 ? city1 + city2 : city2 + city1, distance);
            }

            while (temp.Count > 0)
            {
                var perm = temp.Pop();
                if (perm.Count == allCities.Count)
                {
                    permutations.Add(perm);
                    continue;
                }

                foreach (string city in allCities)
                {
                    if (perm.Contains(city)) continue;
                    var t = new List<string>(perm) { city };
                    temp.Push(t);
                }
            }

            int max = int.MinValue;

            foreach (var permutation in permutations)
            {
                int permSum = 0;
                for (int i = 0; i < permutation.Count - 1; i++)
                {
                    permSum += distances[permutation[i].CompareTo(permutation[i + 1]) > 0
                        ? permutation[i] + permutation[i + 1]
                        : permutation[i + 1] + permutation[i]];
                }

                max = Math.Max(max, permSum);
            }

            Console.WriteLine(max);
        }

        static void Day10Part01()
        {
            string input = File.ReadAllText("input/10.txt");
            StringBuilder result = new StringBuilder(input);

            for (int i = 0; i < 40; i++)
            {
                string previous = result.ToString();
                result.Clear();
                int count = 1;

                for (int c = 0; c < previous.Length; c++)
                {
                    if (c < previous.Length - 1 && previous[c] == previous[c + 1])
                    {
                        count++;
                        continue;
                    }

                    result.Append(count);
                    result.Append(previous[c]);
                    count = 1;
                }
            }

            Console.WriteLine(result.Length);
        }

        static void Day10Part02()
        {
            string input = File.ReadAllText("input/10.txt");

            StringBuilder result = new StringBuilder(input);

            for (int i = 0; i < 50; i++)
            {
                string previous = result.ToString();
                result.Clear();
                int count = 1;

                for (int c = 0; c < previous.Length; c++)
                {
                    if (c < previous.Length - 1 && previous[c] == previous[c + 1])
                    {
                        count++;
                        continue;
                    }

                    result.Append(count);
                    result.Append(previous[c]);
                    count = 1;
                }
            }

            Console.WriteLine(result.Length);
        }

        static string Day11Part01()
        {
            string input = File.ReadAllText("input/11.txt");

            while (true)
            {
                char[] temp = input.ToCharArray();
                bool carry = false;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    char c = input[i];

                    if (i == input.Length - 1 || carry)
                    {
                        c = (char)(c + 1);
                        if (c > 'z')
                        {
                            c = 'a';
                            carry = true;
                        }
                        else
                            carry = false;

                        temp[i] = c;
                    }
                    else
                    {
                        input = new string(temp);
                        break;
                    }
                }

                bool validChar = true;
                char firstPair = ' ';
                bool pairValid = false;
                byte incCount = 1;
                bool incValid = false;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == 'i' || input[i] == 'o' || input[i] == 'j')
                    {
                        validChar = false;
                        break;
                    }

                    if (i < input.Length - 1 && input[i] == input[i + 1] - 1)
                    {
                        incCount++;
                    }
                    else
                    {
                        if (incCount >= 3) incValid = true;
                        incCount = 1;
                    }

                    if (i < input.Length - 1 && input[i] == input[i + 1])
                    {
                        if (firstPair == ' ')
                            firstPair = input[i];
                        else if (firstPair != input[i])
                            pairValid = true;
                    }
                }

                if (validChar && incValid && pairValid)
                    break;
            }

            Console.WriteLine(input);
            return input;
        }

        static void Day11Part02(string part1)
        {
            string input = part1;

            while (true)
            {
                char[] temp = input.ToCharArray();
                bool carry = false;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    char c = input[i];

                    if (i == input.Length - 1 || carry)
                    {
                        c = (char)(c + 1);
                        if (c > 'z')
                        {
                            c = 'a';
                            carry = true;
                        }
                        else
                            carry = false;

                        temp[i] = c;
                    }
                    else
                    {
                        input = new string(temp);
                        break;
                    }
                }

                bool validChar = true;
                char firstPair = ' ';
                bool pairValid = false;
                byte incCount = 1;
                bool incValid = false;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == 'i' || input[i] == 'o' || input[i] == 'j')
                    {
                        validChar = false;
                        break;
                    }

                    if (i < input.Length - 1 && input[i] == input[i + 1] - 1)
                    {
                        incCount++;
                    }
                    else
                    {
                        if (incCount >= 3) incValid = true;
                        incCount = 1;
                    }

                    if (i < input.Length - 1 && input[i] == input[i + 1])
                    {
                        if (firstPair == ' ')
                            firstPair = input[i];
                        else if (firstPair != input[i])
                            pairValid = true;
                    }
                }

                if (validChar && incValid && pairValid)
                    break;
            }

            Console.WriteLine(input);
        }

        static void Day12Part01()
        {
            string input = File.ReadAllText("input/12.txt");

            int sum = 0;
            bool isNeg = false;
            int temp = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    isNeg = true;
                }
                else if (char.IsDigit(input[i]))
                {
                    temp *= 10;
                    temp += (int)(input[i] - '0');
                }
                else
                {
                    sum += isNeg ? -temp : temp;
                    temp = 0;
                    isNeg = false;
                }
            }

            Console.WriteLine(sum);
        }

        static void Day12Part02()
        {
            string input = File.ReadAllText("input/12.txt");

            Stack<int> sums = new Stack<int>();
            HashSet<int> discardDepth = new HashSet<int>();
            Stack<bool> isArray = new Stack<bool>();

            int sum = 0;
            bool isNeg = false;
            int temp = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    isNeg = true;
                }
                else if (char.IsDigit(input[i]))
                {
                    temp *= 10;
                    temp += (int)(input[i] - '0');
                }
                else
                {
                    sum += isNeg ? -temp : temp;
                    temp = 0;
                    isNeg = false;
                }

                if (i < input.Length - 2 && input[i] == 'r' && input[i + 1] == 'e' && input[i + 2] == 'd' && !isArray.Peek())
                {
                    discardDepth.Add(sums.Count);
                }
                else if (input[i] == '[')
                {
                    isArray.Push(true);
                }
                else if (input[i] == ']')
                {
                    isArray.Pop();
                }
                else if (input[i] == '{')
                {
                    sums.Push(sum);
                    sum = 0;
                    isArray.Push(false);
                }
                else if (input[i] == '}')
                {
                    if (!discardDepth.Contains(sums.Count))
                    {
                        sum += sums.Pop();
                    }
                    else
                    {
                        discardDepth.Remove(sums.Count);
                        sum = sums.Pop();
                    }

                    isArray.Pop();
                }
            }

            Console.WriteLine(sum);
        }

        static void Day13Part01()
        {
            string[] input = File.ReadAllLines("input/13.txt");
            HashSet<string> attendees = new();
            Dictionary<string, int> happinessAmounts = new();

            List<List<string>> permutations = new List<List<string>>();
            Stack<List<string>> temp = new Stack<List<string>>();

            foreach (var line in input)
            {
                var parts = line.Split(' ');
                string person1 = parts[0];
                int amount = parts[2].Equals("gain") ? +int.Parse(parts[3]) : -int.Parse(parts[3]);
                string person2 = parts[10].Substring(0, parts[10].Length - 1);
                happinessAmounts.Add(person1 + person2, amount);
                attendees.Add(person1);
                attendees.Add(person2);

                if (temp.Count == 0)
                    temp.Push(new List<string>() { person1 });
            }

            string first = temp.Peek()[0];

            while (temp.Count > 0)
            {
                var perm = temp.Pop();
                if (perm.Count == attendees.Count)
                {
                    permutations.Add(perm);
                    continue;
                }

                foreach (string person in attendees)
                {
                    if (perm.Contains(person) || person == first) continue;
                    var t = new List<string>(perm) { person };
                    temp.Push(t);
                }
            }

            int max = int.MinValue;

            foreach (var permutation in permutations)
            {
                int permSum = 0;
                for (int i = 0; i < permutation.Count; i++)
                {
                    permSum += happinessAmounts[permutation[i] + permutation[(i + 1) % permutation.Count]]
                        + happinessAmounts[permutation[(i + 1) % permutation.Count] + permutation[i]];
                }

                max = Math.Max(max, permSum);
            }

            Console.WriteLine(max);
        }

        static void Day13Part02()
        {
            string[] input = File.ReadAllLines("input/13.txt");
            HashSet<string> attendees = new();
            Dictionary<string, int> happinessAmounts = new();

            List<List<string>> permutations = new List<List<string>>();
            Stack<List<string>> temp = new Stack<List<string>>();

            foreach (var line in input)
            {
                var parts = line.Split(' ');
                string person1 = parts[0];
                int amount = parts[2].Equals("gain") ? +int.Parse(parts[3]) : -int.Parse(parts[3]);
                string person2 = parts[10].Substring(0, parts[10].Length - 1);
                happinessAmounts.Add(person1 + person2, amount);
                attendees.Add(person1);
                attendees.Add(person2);
            }

            string myself = "Manuel";
            temp.Push(new List<string>() { myself });

            foreach (var person in attendees)
            {
                happinessAmounts.Add(person + myself, 0);
                happinessAmounts.Add(myself + person, 0);
            }

            attendees.Add(myself);

            while (temp.Count > 0)
            {
                var perm = temp.Pop();
                if (perm.Count == attendees.Count)
                {
                    permutations.Add(perm);
                    continue;
                }

                foreach (string person in attendees)
                {
                    if (perm.Contains(person) || person == myself) continue;
                    var t = new List<string>(perm) { person };
                    temp.Push(t);
                }
            }

            int max = int.MinValue;

            foreach (var permutation in permutations)
            {
                int permSum = 0;
                for (int i = 0; i < permutation.Count; i++)
                {
                    permSum += happinessAmounts[permutation[i] + permutation[(i + 1) % permutation.Count]]
                        + happinessAmounts[permutation[(i + 1) % permutation.Count] + permutation[i]];
                }

                max = Math.Max(max, permSum);
            }

            Console.WriteLine(max);
        }

        static void Day14Part01()
        {
            string[] input = File.ReadAllLines("input/14.txt");
            int max = int.MinValue;

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                string name = parts[0];
                int topSpeed = int.Parse(parts[3]);
                int speedTime = int.Parse(parts[6]);
                int restTime = int.Parse(parts[13]);
                int cycle = speedTime + restTime;

                const int stopTime = 2503;

                int n = stopTime / cycle;
                int rest = stopTime % cycle;

                int distance = (n * speedTime + Math.Min(rest, speedTime)) * topSpeed;
                max = Math.Max(max, distance);
            }

            Console.WriteLine(max);
        }

        static void Day14Part02()
        {
            string[] input = File.ReadAllLines("input/14.txt");
            Dictionary<string, int> distances = new();
            Dictionary<string, int> points = new();

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                string name = parts[0];
                distances.Add(name, 0);
                points.Add(name, 0);
            }

            for (int i = 0; i < 2503; i++)
            {
                int max = int.MinValue;

                foreach (string line in input)
                {
                    var parts = line.Split(' ');
                    string name = parts[0];
                    int topSpeed = int.Parse(parts[3]);
                    int speedTime = int.Parse(parts[6]);
                    int restTime = int.Parse(parts[13]);
                    int cycle = speedTime + restTime;

                    int n = i / cycle;
                    int rest = i % cycle;

                    distances[name] += rest < speedTime ? topSpeed : 0;
                    max = Math.Max(max, distances[name]);
                }

                foreach (string line in input)
                {
                    var parts = line.Split(' ');
                    string name = parts[0];

                    if (distances[name] == max)
                        points[name]++;
                }
            }

            int result = int.MinValue;
            foreach (var val in points.Values)
            {
                result = Math.Max(result, val);
            }

            Console.WriteLine(result);
        }

        static void Day15Part01()
        {
            string[] input = File.ReadAllLines("input/15.txt");
            List<int[]> ingredients = new();

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                ingredients.Add(new int[] { int.Parse(parts[2].Split(',')[0]), int.Parse(parts[4].Split(',')[0]), int.Parse(parts[6].Split(',')[0]), int.Parse(parts[8].Split(',')[0]), int.Parse(parts[10]) });
            }

            // taken from https://10xlearner.com/2019/11/04/advent-of-code-science-for-hungry-people-puzzle-15/
            List<List<int>> PossiblePermutations(int teaspoons, int ingredient)
            {
                if (ingredient == 1) return new() { new List<int> { teaspoons } };

                List<List<int>> result = new();
                for (int i = 1; i < teaspoons; i++) // for all teaspoons left
                {
                    var possible = PossiblePermutations(i, ingredient - 1);
                    foreach (var p in possible)
                    {
                        List<int> list = new List<int>(p);
                        p.Add(teaspoons - i);
                        result.Add(p);
                    }
                }
                return result;
            }

            var possible = PossiblePermutations(100, ingredients.Count);

            int max = int.MinValue;
            foreach (var teaspoons in possible)
            {
                int total = 1;
                for (int property = 0; property < 4; property++)
                {
                    int propScore = 0;
                    for (int ingredient = 0; ingredient < ingredients.Count; ingredient++)
                    {
                        propScore += ingredients[ingredient][property] * teaspoons[ingredient];
                    }
                    if (propScore < 0) total = 0;
                    total *= propScore;
                }


                max = Math.Max(max, total);
            }

            Console.WriteLine(max);
        }

        static void Day15Part02()
        {
            string[] input = File.ReadAllLines("input/15.txt");
            List<int[]> ingredients = new();

            foreach (string line in input)
            {
                var parts = line.Split(' ');
                ingredients.Add(new int[] { int.Parse(parts[2].Split(',')[0]), int.Parse(parts[4].Split(',')[0]), int.Parse(parts[6].Split(',')[0]), int.Parse(parts[8].Split(',')[0]), int.Parse(parts[10]) });
            }

            // taken from https://10xlearner.com/2019/11/04/advent-of-code-science-for-hungry-people-puzzle-15/
            List<List<int>> PossiblePermutations(int teaspoons, int ingredient)
            {
                if (ingredient == 1) return new() { new List<int> { teaspoons } };

                List<List<int>> result = new();
                for (int i = 1; i < teaspoons; i++) // for all teaspoons left
                {
                    var possible = PossiblePermutations(i, ingredient - 1);
                    foreach (var p in possible)
                    {
                        List<int> list = new List<int>(p);
                        p.Add(teaspoons - i);
                        result.Add(p);
                    }
                }
                return result;
            }

            var possible = PossiblePermutations(100, ingredients.Count);

            int max = int.MinValue;
            foreach (var teaspoons in possible)
            {
                int total = 1;
                for (int property = 0; property < 5; property++)
                {
                    int propScore = 0;
                    for (int ingredient = 0; ingredient < ingredients.Count; ingredient++)
                    {
                        propScore += ingredients[ingredient][property] * teaspoons[ingredient];
                    }
                    if (propScore < 0 || (property == 4 && propScore != 500))
                    {
                        total = 0;
                        break;
                    }

                    if (property < 4)
                        total *= propScore;
                }

                max = Math.Max(max, total);
            }

            Console.WriteLine(max);
        }

        static void Day16Part01()
        {
            string[] input = File.ReadAllLines("input/16.txt");
            string[] compare = File.ReadAllLines("input/16message.txt");
            Dictionary<string, int> goal = new();

            foreach (var line in compare)
            {
                var parts = line.Replace(":", "").Split(' ');
                goal.Add(parts[0], int.Parse(parts[1]));
            }

            foreach (var line in input)
            {
                var parts = line.Replace(":", "").Replace(",", "").Split(' ');
                int aunt = int.Parse(parts[1]);

                bool found = true;
                for (int i = 2; i < parts.Length; i += 2)
                {
                    string type = parts[i];
                    int number = int.Parse(parts[i + 1]);
                    if (goal[type] != number)
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    Console.WriteLine(aunt);
                    break;
                }
            }
        }

        static void Day16Part02()
        {
            string[] input = File.ReadAllLines("input/16.txt");
            string[] compare = File.ReadAllLines("input/16message.txt");
            Dictionary<string, int> goal = new();

            foreach (var line in compare)
            {
                var parts = line.Replace(":", "").Split(' ');
                goal.Add(parts[0], int.Parse(parts[1]));
            }

            foreach (var line in input)
            {
                var parts = line.Replace(":", "").Replace(",", "").Split(' ');
                int aunt = int.Parse(parts[1]);

                bool found = true;
                for (int i = 2; i < parts.Length; i += 2)
                {
                    string type = parts[i];
                    int number = int.Parse(parts[i + 1]);

                    switch (type)
                    {
                        case "cats":
                        case "trees":
                            if (goal[type] >= number)
                            {
                                found = false;
                            }
                            break;
                        case "pomeranians":
                        case "goldfish":
                            if (goal[type] <= number)
                            {
                                found = false;
                            }
                            break;
                        default:
                            if (goal[type] != number)
                            {
                                found = false;
                            }
                            break;
                    }
                }

                if (found)
                {
                    Console.WriteLine(aunt);
                    break;
                }
            }
        }

        //static void Day17Part01()
        //{
        //    string input = Input.Day17;
        //    const int liters = 150;
        //    List<int> containers = new();

        //    foreach (var line in input.Split("\r\n"))
        //    {
        //        containers.Add(int.Parse(line));
        //    }

        //    containers.Sort();

        //    List<List<int>> combinations = new();

        //    for (int i = 0; i < containers.Count; i++)
        //    {
        //        HashSet<int> used = new() { containers[i] };
        //        HashSet<int> ignored = new();

        //        for (int j = i + 1; j < containers.Count; j++)
        //        {
        //            if (ignored.Contains(j))
        //                continue;

        //            used.Add(containers[j]);

        //            if (used.Sum() >= liters)
        //            {
        //                if (used.Sum() == liters)
        //                    combinations.Add(new List<int>(used));

        //                used.Remove(containers[j]);
        //                ignored.Add(j);
        //                j--;
        //            }
        //        }
        //    }

        //    Console.WriteLine(combinations.Count);
        //}

        //static void Day17Part02()
        //{

        //}
    }
}