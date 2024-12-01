using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024
{
	public class Day1
	{
		public static int Part1()
		{
			string[] lines = File.ReadAllLines("C:\\Users\\Michael\\AdventOfCode\\2024\\Day1.txt");
			int[] leftList = new int[lines.Length];
			int[] rightList = new int[lines.Length];

			for (int i = 0; i < lines.Length; i++)
			{
				string[] parts = lines[i].Split("   ");
				leftList[i] = int.Parse(parts[0]);
				rightList[i] = int.Parse(parts[1]);
			}

			Array.Sort(leftList);
			Array.Sort(rightList);
			int total = 0;
			for (int i = 0; i < leftList.Length; i++)
			{
				total += Math.Abs(leftList[i] - rightList[i]);
			}

			return (total);
		}


		public static int Part2()
		{
			string[] lines = File.ReadAllLines("C:\\Users\\Michael\\AdventOfCode\\2024\\Day1.txt");
			int[] leftList = new int[lines.Length];
			int[] rightList = new int[lines.Length];

			for (int i = 0; i < lines.Length; i++)
			{
				string[] parts = lines[i].Split("   ");
				leftList[i] = int.Parse(parts[0]);
				rightList[i] = int.Parse(parts[1]);
			}

			Array.Sort(leftList);
			Array.Sort(rightList);
			int total = 0;
			for (int i = 0; i < leftList.Length; i++)
			{
				total += leftList[i] * rightList.Count(r => r == leftList[i]);
			}

			return (total);
		}
	}
}
