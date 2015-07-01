﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.DATA;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class SuggestionRepositoryTest
    {


        [Test]
        public void GetSuggestionsTest()
        {
            var repo = new SuggestionRepository();
            var suggestions = repo.GetAllSuggestions();
            var suggestion = suggestions.First();
            Assert.AreEqual("Bob", suggestion.EmployeeName);

        }


        [Test]
        public void RemoveSuggestionTest()
        {
            var repo = new SuggestionRepository();
            
            repo.RemoveFile(1);

            var suggestions = repo.GetAllSuggestions();
            Assert.IsFalse(suggestions.Exists(s => s.SuggestionID == 1));

        }
    }
}
