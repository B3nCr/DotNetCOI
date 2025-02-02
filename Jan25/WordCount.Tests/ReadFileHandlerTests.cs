using System.IO;
using Xunit;

namespace WordCount.Tests
{
    public class ReadFileHandlerTests
    {
        [Fact]
        public void ReadFile_ShouldPrintLineCount_WhenLineFlagIsTrue()
        {
            // Arrange
            var filePath = "testfile.txt";
            File.WriteAllText(filePath, "Line1\nLine2\nLine3");
            var fileInfo = new FileInfo(filePath);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // ACT
                ReadFileHandler.ReadFile(fileInfo, countLines: true);

                // Assert
                var result = sw.ToString().Trim();

                Assert.Equal($"File {filePath} has 3 lines.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_ShouldPrintDoneNothing_WhenLineFlagIsFalse()
        {
            // Arrange
            var filePath = "testfile.txt";
            File.WriteAllText(filePath, "Line1\nLine2\nLine3");
            var fileInfo = new FileInfo(filePath);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // ACT
                ReadFileHandler.ReadFile(fileInfo, countLines: false);

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal("Done Nothing.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_ShouldPrintByteCount_WhenByteFlagIsTrue()
        {
            // Arrange
            var filePath = "testfile.txt";
            File.WriteAllText(filePath, "Line1\nLine2\nLine3");
            var fileInfo = new FileInfo(filePath);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // ACT
                ReadFileHandler.ReadFile(fileInfo, countLines: false, countBytes: true);

                // Assert
                var result = sw.ToString().Trim();
                var expectedByteCount = new FileInfo(filePath).Length;

                Assert.Equal($"File {filePath} has {expectedByteCount} bytes.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_ShouldPrintDoneNothing_WhenAllFlagsAreFalse()
        {
            // Arrange
            var filePath = "testfile.txt";
            File.WriteAllText(filePath, "Line1\nLine2\nLine3");
            var fileInfo = new FileInfo(filePath);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // ACT
                ReadFileHandler.ReadFile(fileInfo);

                // Assert
                var result = sw.ToString().Trim();
                
                Assert.Equal("Done Nothing.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_ShouldReturnCorrectWordCount()
        {
            // Arrange
            var filePath = "testfile.txt";
            File.WriteAllText(filePath, "Hello world! This is a test file.");
            var fileInfo = new FileInfo(filePath);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                ReadFileHandler.ReadFile(fileInfo, countWords: true);

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal($"File {filePath} has 7 words.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_ShouldReturnCorrectCharacterCount()
        {
            // Arrange
            var filePath = "testfile.txt";
            File.WriteAllText(filePath, "Hello world! This is a test file.");
            var fileInfo = new FileInfo(filePath);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                ReadFileHandler.ReadFile(fileInfo, countCharacters: true);

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal($"File {filePath} has 33 characters.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_ShouldPrintAllCounts_WhenAllFlagsAreTrue()
        {
            // Arrange
            var filePath = "testfile.txt";
            File.WriteAllText(filePath, "Hello world!\nThis is a test file.");
            var fileInfo = new FileInfo(filePath);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                ReadFileHandler.ReadFile(fileInfo, countLines: true, countBytes: true, countWords: true, countCharacters: true);

                // Assert
                var result = sw.ToString().Trim().Split('\n');
                Assert.Equal($"File {filePath} has 2 lines.", result[0].Trim());
                Assert.Equal($"File {filePath} has {fileInfo.Length} bytes.", result[1].Trim());
                Assert.Equal($"File {filePath} has 7 words.", result[2].Trim());
                Assert.Equal($"File {filePath} has 33 characters.", result[3].Trim());
            }

            // Cleanup
            File.Delete(filePath);
        }
    }
}
