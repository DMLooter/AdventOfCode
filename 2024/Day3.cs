namespace _2024
{
	public class Day3
	{
		public static int Part1()
		{
			string lines = File.ReadAllText("C:\\Users\\Michael\\AdventOfCode\\2024\\Input\\Day3.txt");

			int total = 0;
			int index = 0;
			while (index < lines.Length)
			{
				total += findMul(lines, ref index);
			}
			return (total);
		}

		public static int Part2()
		{
			string lines = File.ReadAllText("C:\\Users\\Michael\\AdventOfCode\\2024\\Input\\Day3.txt");

			int total = 0;
			bool enabled = true;
			int index = 0;
			while (index < lines.Length)
			{
				if (index < lines.Length - 3 && lines.Substring(index, 4) == "do()")
				{
					enabled = true;
					index += 4;
				}
				else if (index < lines.Length-6 && lines.Substring(index, 7) == "don't()")
				{
					enabled = false;
					index += 7;

				}
				if (enabled)
				{
					total += findMul(lines, ref index);
				}
				else
				{
					index++;
				}
			}
			return (total);
		}

		public static int findMul(string input, ref int index)
		{
			if (input[index] != 'm')
			{
				index++;
				return 0;
			}
			index++;
			if (input[index] != 'u')
			{
				return 0;
			}
			index++;
			if (input[index] != 'l')
			{
				return 0;
			}
			index++;
			if (input[index] != '(')
			{
				return 0;
			}
			index++;
			// Now we look for a number
			int startNum = index;

			while (input[index] >= '0' && input[index] <= '9')
			{
				index++;
			}
			if (startNum == index)
			{
				// No digits found
				return 0;
			}
			int num1 = int.Parse(input.Substring(startNum, index - startNum));

			if (input[index] != ',')
			{
				return 0;
			}
			index++;

			//look for a second number
			startNum = index;

			while (input[index] >= '0' && input[index] <= '9')
			{
				index++;
			}
			if (startNum == index)
			{
				// No digits found
				return 0;
			}
			int num2 = int.Parse(input.Substring(startNum, index - startNum));

			if (input[index] != ')')
			{
				return 0;
			}
			index++;
			return (num1 * num2);
		}
	}
}
