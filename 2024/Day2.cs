using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024
{
	public class Day2
	{
		public static int Part1()
		{
			string[] lines = File.ReadAllLines("C:\\Users\\Michael\\AdventOfCode\\2024\\Input\\Day2.txt");

			int[][] reports = new int[lines.Length][];

			for (int i = 0; i < lines.Length; i++)
			{
				string[] parts = lines[i].Split(" ");
				reports[i] = new int[parts.Length];
				for (int j = 0; j < parts.Length; j++)
				{
					reports[i][j] = int.Parse(parts[j]);
				}
			}

			int numSafe = 0;
			for (int i = 0; i < reports.Length; i++)
			{
				if (isReportSafe(reports[i]))
				{
					numSafe++;
				}
			}

			return (numSafe);
		}

		public static int Part2()
		{
			string[] lines = File.ReadAllLines("C:\\Users\\Michael\\AdventOfCode\\2024\\Input\\Day2.txt");

			int[][] reports = new int[lines.Length][];

			for (int i = 0; i < lines.Length; i++)
			{
				string[] parts = lines[i].Split(" ");
				reports[i] = new int[parts.Length];
				for (int j = 0; j < parts.Length; j++)
				{
					reports[i][j] = int.Parse(parts[j]);
				}
			}

			int numSafe = 0;
			for (int i = 0; i < reports.Length; i++)
			{
				if (isReportSafe(reports[i]))
				{
					numSafe++;
				}
				else if (isReportSafeSansLevel(reports[i]))
				{
					numSafe++;
				}
			}

			return (numSafe);
		}

		public static bool isReportSafe(int[] report)
		{
			bool safe = true;
			int dir = 0;
			for (int j = 0; j < report.Length - 1; j++)
			{
				int diff = report[j] - report[j + 1];
				int absDiff = Math.Abs(diff);
				int dirDiff = Math.Sign(diff);
				if (absDiff < 1 || absDiff > 3)
				{
					safe = false;
				}

				if (dir == 0)
				{
					dir = dirDiff;
				}
				else if (dir != dirDiff)
				{
					safe = false;
				}
			}
			return (safe);
		}

		public static bool isReportSafeSansLevel(int[] report)
		{
			for (int i = 0; i < report.Length; i++)
			{
				int[] trimmed = new int[report.Length - 1];
				for (int j = 0; j < report.Length; j++)
				{
					// skip the ith spot
					if (j == i)
					{
						j++;
						if (j == report.Length)
						{
							break;
						}
					}
					trimmed[j > i ? j - 1 : j] = report[j];
				}
				if (isReportSafe(trimmed))
				{
					return (true);
				}
			}
			return (false);
		}
	}
}
