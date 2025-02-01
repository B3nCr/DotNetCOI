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
                ReadFileHandler.ReadFile(fileInfo, line: true);

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
                ReadFileHandler.ReadFile(fileInfo, line: false);

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
                ReadFileHandler.ReadFile(fileInfo, line: false, byteFlag: true);

                // Assert
                var result = sw.ToString().Trim();
                var expectedByteCount = new FileInfo(filePath).Length;

                Assert.Equal($"File {filePath} has {expectedByteCount} bytes.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_ShouldPrintDoneNothing_WhenByteFlagIsFalse()
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
                ReadFileHandler.ReadFile(fileInfo, line: false, byteFlag: false);

                // Assert
                var result = sw.ToString().Trim();
                
                Assert.Equal("Done Nothing.", result);
            }

            // Cleanup
            File.Delete(filePath);
        }
    }
}
