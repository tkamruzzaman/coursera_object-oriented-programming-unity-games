
namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a integer number (2,147,483,647): ");
                int input = int.Parse(Console.ReadLine());
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("Input is not an Interger value!");
            }
            catch (OverflowException overflowException)
            {
                Console.WriteLine("Input is out of range!");
            }
            finally
            {
                Console.WriteLine("Finally block: All done!");
            }
        }
    }
}