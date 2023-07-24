using System;

namespace Projecto_Libro_Study
{
    internal class Program
    {
        private static bool exit;
        private static bool selection;

        static void Main(string[] args)
        {
            LibraryManagement LM =new LibraryManagement();
            LM.Run();
        }
    }
}
