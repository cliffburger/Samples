using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BowlingByContract.Game;
using System.Diagnostics.Contracts;

namespace BowlingByContract
{
    public static class Program
    {
        public static void Main(string[] args)
        {   
            try
            {
                var bg = new BowlingGame();
                bg.SetScore(-1); // Should fail at runtime due to invariant protection
            }
            catch (Exception ex)
            {
                // Unfortunately the exception thrown is a RunTime type derived from system.Exception
                Console.WriteLine(ex.Message);
            }

            try
            {
                var bg = new BowlingGame();
                bg.Bowl(-1); // Static checker catches this and you should see a warning in build output.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var frame = new Frame();
                frame.Roll(2);
                frame.Roll(3);
                frame.Roll(1); // Postcondition from contract class should fail
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

    }
}
