using Answer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.IO;

namespace TechIo
{
    [TestClass]
    public class ModuloTest
    {
        private bool shouldShowHint = false;
        private int level = 0;

        [TestMethod]
        public void VerifyModuloEasy()
        {
            level = 1;
            shouldShowHint = true;
            Assert.AreEqual("pair", ModuloStubEasy.EvenOrOdd(12));
            Assert.AreEqual("impair", ModuloStubEasy.EvenOrOdd(15));
            Assert.AreEqual("impair", ModuloStubEasy.EvenOrOdd(int.MaxValue));
            Assert.AreEqual("pair", ModuloStubEasy.EvenOrOdd(0));
            shouldShowHint = false;
        }

        [TestMethod]
        public void VerifyModuloMedium()
        {
            level = 2;
            shouldShowHint = true;
            Assert.AreEqual(false, ModuloStubMedium.IsLeapYear(2018));
            Assert.AreEqual(true, ModuloStubMedium.IsLeapYear(2008));
            Assert.AreEqual(true, ModuloStubMedium.IsLeapYear(2000));
            Assert.AreEqual(false, ModuloStubMedium.IsLeapYear(1900));
            shouldShowHint = false;
        }

        [TestMethod]
        public void VerifyModuloHard()
        {
            level = 3;
            shouldShowHint = true;
            Assert.AreEqual(false, ModuloStubHard.IsPrime(1));
            Assert.AreEqual(false, ModuloStubHard.IsPrime(9));
            Assert.AreEqual(true, ModuloStubHard.IsPrime(19));
            Assert.AreEqual(true, ModuloStubHard.IsPrime(29));
            Assert.AreEqual(false, ModuloStubHard.IsPrime(39));
            shouldShowHint = false;
        }

        [TestCleanup()]
        public void Cleanup()
        {
            switch (level)
            {
                case 1:
                    if (shouldShowHint)
                    {
                        // On Failure
                        PrintMessage("Hint 💡", "Avez-vous testé les 2 cas ? 🤔");
                    }
                    else
                    {
                        // On success
                        PrintMessage("Bien joué 🌟", "Arrivez-vous également à tout faire sur une seule ligne ?");
                    }
                    break;

                case 2:
                    if (shouldShowHint)
                    {
                        // On Failure
                        PrintMessage("Hint 💡", "Pour être bissextile, une année doit dans tous les cas être divisible par 4 ; 🤔");
                        PrintMessage("Hint 💡", "mais si c'est une année de centenaire (comme 1800, 1900, etc.), elle doit en complément être divisible par 400. ? 🤔");
                    }
                    else
                    {
                        // On success
                        PrintMessage("Au top ! 🌟", "Le saviez-vous ?");
                        PrintMessage("Au top ! 🌟", "");
                        PrintMessage("Au top ! 🌟", "Ce calcul indique qu'une année moyenne dure 365,2425 jours");
                        PrintMessage("Au top ! 🌟", "ce qui est encore un peu trop long (par rapport aux 365,2422 jours de l’année tropique)");
                        PrintMessage("Au top ! 🌟", "mais il n'engendre qu'un retard de trois jours en dix mille ans ! 🤔");
                    }
                    break;

                case 3:
                    if (shouldShowHint)
                    {
                        // On Failure
                        PrintMessage("Hint 💡", "Attention: 1 n'est pas un nombre premier 🤔");
                    }
                    else
                    {
                        // On success
                        PrintMessage("Bravo ! 🌟", "La solution simple consiste à tester tous les nombres de 2 à number...");
                        PrintMessage("Bravo ! 🌟", "... mais vous avez trouvé une solution plus futée non ?");
                    }
                    break;

                default:
                    PrintMessage("Niveau inconnu 💡", "Mais qu'avez-vous fait ?");
                    break;
            }
            
        }


        /****
            TOOLS
        *****/
        // Display a custom message in a custom channel
        private static void PrintMessage(String channel, String message)
        {
            Console.WriteLine($"TECHIO> message --channel \"{channel}\" \"{message}\"");
        }

        // You can manually handle the success/failure of a testcase using this function
        private static void Success(Boolean success)
        {
            Console.WriteLine($"TECHIO> success {success}");
        }

        // Check the user code looking for a keyword
        private static Boolean ExistsInFile(String path, String keyword)
        {
            return File.ReadAllText(path).Contains(keyword);
        }
    }
}