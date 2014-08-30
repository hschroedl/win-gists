﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uploader.Request;

namespace Uploader.Test
{
    [TestClass]
    public class FileReaderTest
    {
        [TestMethod]
        public void ReadFile(){
            const string filepath = @"..\..\testfiles\TestFile.txt";
            String content = FileReader.GetContent(filepath);
            Assert.IsTrue(content.Equals("TestFileContent"));
        }

        [TestMethod]
        public void ReadEmptyFile(){
            const string filepath = @"..\..\testfiles\EmptyFile.txt";
            String content = FileReader.GetContent(filepath);
            Assert.IsTrue(content.Equals(""));
        }

        [TestMethod]
        public void GetFileName(){
            const string filepath = @"..\..\testfiles\TestFile.txt";
            String fileName = FileReader.GetFileName(filepath);
            Assert.IsTrue(fileName == "TestFile.txt");
        }

        [TestMethod]
        public void GetFileDescription(){
            const string filepath = @"..\..\testfiles\TestFile.txt";
            String fileDescription = FileReader.GetFileDescription(filepath);
            Assert.IsTrue(fileDescription == "File TestFile.txt, uploaded by WinGists.");
        }
    }
}