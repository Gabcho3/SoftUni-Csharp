namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tests
    {
        private UniversityLibrary universityLibrary;
        private TextBook book;
        [SetUp]
        public void Setup()
        {
            universityLibrary = new UniversityLibrary();
            book = new TextBook("Pod Igoto", "Ivan Vazov", "Roman");
            book.Holder = "Gabcho";
            universityLibrary.AddTextBookToLibrary(book);
        }

        [Test]
        public void Test_ConstructorWorksProperly()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            List<TextBook> textBooks = new List<TextBook>();
            Assert.AreEqual(textBooks, universityLibrary.Catalogue, "Constructor does not work properly");
        }

        [Test]
        public void Test_AddingTextBookSetCorrectInventoryNumberToBook()
        {
            Assert.AreEqual(1, book.InventoryNumber, "Setting inventory number wrong");
        }

        [Test]
        public void Test_AddingTextIncreaseCatalogueCount()
        {
            Assert.AreEqual(1, universityLibrary.Catalogue.Count, "Count does not increase when adding a book");
        }

        [Test]
        public void Test_AddingTextBookReturnCorrectResult()
        {
            string result = universityLibrary.AddTextBookToLibrary(book);
            string expectedResult = $"Book: {book.Title} - {book.InventoryNumber}" + Environment.NewLine +
                $"Category: {book.Category}" + Environment.NewLine +
                $"Author: {book.Author}";

            Assert.AreEqual(expectedResult, result, "Result is not correct");
        }

        [Test]
        public void Test_TryingToLoanBookWhichIsStillInHolder()
        {
            string returned = universityLibrary.LoanTextBook(1, "Gabcho");
            TextBook book = universityLibrary.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1);
            string expectedReturn = $"Gabcho still hasn't returned {book.Title}!";
            Assert.AreEqual(expectedReturn, returned, "Can loan book which is still in holder");
        }

        [Test]
        public void Test_LoanBookSetNewHolderToBook()
        {
            universityLibrary.LoanTextBook(1, "Vikcho");
            TextBook book = universityLibrary.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1);
            Assert.AreEqual("Vikcho", book.Holder, "Setting book holder wrong");
        }

        [Test]
        public void Test_LoanBookWorksProperly()
        {
            string returned = universityLibrary.LoanTextBook(1, "Vikcho");
            TextBook book = universityLibrary.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1);
            string expectedReturn = $"{book.Title} loaned to Vikcho.";
            Assert.AreEqual(expectedReturn, returned, "Loan Book does not work properly");
        }

        [Test]
        public void Test_ReturnTextBookRemoveBookHolder()
        {
            universityLibrary.ReturnTextBook(1);
            TextBook book = universityLibrary.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1);
            Assert.AreEqual(string.Empty, book.Holder, "When returning the book, holder does not remove");
        }

        [Test]
        public void Test_ReturnTextBookWorksProperly()
        {
            string returned = universityLibrary.ReturnTextBook(1);
            TextBook book = universityLibrary.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1);
            string expectedReturn = $"{book.Title} is returned to the library.";
            Assert.AreEqual(expectedReturn, returned, "Return Book does not work properly");
        }
    }
}