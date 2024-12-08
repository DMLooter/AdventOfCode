namespace _2024
{
	public class Day4
	{
		public static int Part1()
		{
			string[] lines = File.ReadAllLines("C:\\Users\\Michael\\AdventOfCode\\2024\\Input\\Day4.txt");

			int count = 0;
			for (int y = 0; y < lines.Length; y++)
			{
				for (int x = 0; x < lines[y].Length; x++)
				{
					if (lines[y][x] == 'X')
					{
						count += checkAllDirections(lines, x, y, "XMAS");
					}
				}
			}
			return (count);
		}

		public static int Part2()
		{
			string[] lines = File.ReadAllLines("C:\\Users\\Michael\\AdventOfCode\\2024\\Input\\Day4.txt");

			int count = 0;
			for (int y = 1; y < lines.Length - 1; y++)
			{
				for (int x = 1; x < lines[y].Length - 1; x++)
				{
					if (lines[y][x] == 'A')
					{
						if (((lines[y - 1][x - 1] == 'M' && lines[y + 1][x + 1] == 'S') ||
							(lines[y - 1][x - 1] == 'S' && lines[y + 1][x + 1] == 'M')) &&
							((lines[y - 1][x + 1] == 'M' && lines[y + 1][x - 1] == 'S') ||
							(lines[y - 1][x + 1] == 'S' && lines[y + 1][x - 1] == 'M')))
						{
							count++;
						}
					}
				}
			}
			return (count);
		}

		public static int checkAllDirections(string[] lines, int x, int y, string word)
		{
			int length = word.Length;
			string[] toCheck = new string[8];
			if (x < lines[y].Length - 3)
			{
				toCheck[0] = lines[y].Substring(x, length);
			}
			if (x < lines[y].Length - (length - 1) && y < lines.Length - (length - 1))
			{
				string a = "";
				for (int i = 0; i < length; i++)
				{
					a += lines[y + i][x + i];
				}
				toCheck[1] = a;
			}
			if (y < lines.Length - (length - 1))
			{
				string a = "";
				for (int i = 0; i < length; i++)
				{
					a += lines[y + i][x];
				}
				toCheck[2] = a;
			}
			if (x > (length - 2) && y < lines.Length - (length - 1))
			{
				string a = "";
				for (int i = 0; i < length; i++)
				{
					a += lines[y + i][x - i];
				}
				toCheck[3] = a;
			}
			if (x > (length - 2))
			{
				toCheck[4] = new String(lines[y].Substring(x - (length - 1), length).Reverse().ToArray());
			}
			if (x > (length - 2) && y > (length - 2))
			{
				string a = "";
				for (int i = 0; i < length; i++)
				{
					a += lines[y - i][x - i];
				}
				toCheck[5] = a;
			}
			if (y > (length - 2))
			{
				string a = "";
				for (int i = 0; i < length; i++)
				{
					a += lines[y - i][x];
				}
				toCheck[6] = a;
			}
			if (x < lines[y].Length - (length - 1) && y > (length - 2))
			{
				string a = "";
				for (int i = 0; i < length; i++)
				{
					a += lines[y - i][x + i];
				}
				toCheck[7] = a;
			}

			int total = 0;
			for (int i = 0; i < 8; i++)
			{
				if (toCheck[i] == word)
				{
					total++;
				}
			}
			return total;
		}
	}
}
