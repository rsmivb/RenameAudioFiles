using FileNameHandler;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace RenameFileNamesTest
{
    public class StringHandlerTest
    {
        private TextInfo textInfo;
        private StringHandler stringHandler;

        public StringHandlerTest()
        {
            textInfo = new CultureInfo("en-US", false).TextInfo;
            stringHandler = new StringHandler(textInfo);
        }
        [Fact]
        [Trait("String Handler", "Manipulation")]
        public void AddSpacesBetweenHiphenFoundTest()
        {
            var audioFileName = "01-Filename";
            var expectedFileName = "01 - Filename";
            char separator = '-';

            var currentAudioName = stringHandler.AddEmptySpace(audioFileName, separator);

            Assert.Equal(expectedFileName, currentAudioName);
        }
        [Theory]
        [Trait("String Handler", "Manipulation")]
        [MemberData(nameof(DataTest))]
        public void ChangeStringToTitleCaseTest(string inputValue, string expected)
        {
            var current = stringHandler.ToTitleCase(inputValue);
            Assert.Equal(expected, current);
        }

        public static IEnumerable<object[]> DataTest =>
            new List<object[]>
            {
                        new object[] { "01 - filename the name", "01 - Filename The Name" },
                        new object[] { "99 - fiLeName the naMe", "99 - Filename The Name" },
                        new object[] { "01 - FILEname the nAME", "01 - Filename The Name" },
            };
    }
}
