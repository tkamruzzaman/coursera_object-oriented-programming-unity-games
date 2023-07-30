namespace Exercise
{
    internal class Exercise2
    {
        static void Main(string[] args)
        {
            // read from the text file
            StreamReader inputFile = null;
            List<string> lineList = new List<string>();
            try
            {
                // create stream reader object
                inputFile = File.OpenText("sample_input.txt");

                // read and echo lines until end of file
                string line = inputFile.ReadLine();
                while (line != null)
                {
                    lineList.Add(line);
                    Console.WriteLine(line);
                    line = inputFile.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // close input file
                if (inputFile != null)
                {
                    inputFile.Close();
                }
            }

            // write to a text file
            StreamWriter outputFile = null;
            try
            {
                // create stream writer object
                outputFile = File.CreateText("sample_output.txt");

                // write a event numbered lines
                for (int i = 0; i < lineList.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        outputFile.WriteLine(lineList[i]);
                        Console.WriteLine(lineList[i]);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // close output file
                if (outputFile != null)
                {
                    outputFile.Close();
                }
            }
        }
    }
}

