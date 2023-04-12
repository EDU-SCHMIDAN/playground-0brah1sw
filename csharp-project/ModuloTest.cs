﻿using Answer;
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
	[TestMethod]
	public void VerifyModuloEasy() 
	{
		shouldShowHint = true;
		Assert.AreEqual ("pair",   ModuloStubEasy.PairImpair(12));
		Assert.AreEqual ("impair",   ModuloStubEasy.PairImpair(15));
		Assert.AreEqual ("impair",   ModuloStubEasy.PairImpair(int.MaxValue));
		Assert.AreEqual ("pair",   ModuloStubEasy.PairImpair(0));
		shouldShowHint = false;
	}

	[TestCleanup()]
    public void Cleanup()
    {		
		if(shouldShowHint)
		{	
			// On Failure
			PrintMessage("Hint 💡", "Avez-vous testé les 2 cas ? 🤔");
		} 
		else
		{
 			// On success
            PrintMessage("Bien joué 🌟", "Est-ce que vous arrivez également à faire tout sur une seule ligne ?");
        }
    }


	/****
		TOOLS
	*****/
	// Display a custom message in a custom channel
	private static void PrintMessage(String channel, String message)
	{		
		Console.WriteLine ($"TECHIO> message --channel \"{channel}\" \"{message}\"");
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
