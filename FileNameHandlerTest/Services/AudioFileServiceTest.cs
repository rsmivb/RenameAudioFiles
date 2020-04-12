using FileNameHandler.Services;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace RenameFileNamesTest
{
    public class AudioFileServiceTest
    {
        private readonly TextInfo textInfo;
        private readonly IAudioFileService service;

        public AudioFileServiceTest()
        {
            textInfo = new CultureInfo("en-US", false).TextInfo;
            service = new AudioFileService(textInfo);
        }
        [Theory]
        [Trait("Service", "Audio File")]
        [MemberData(nameof(FileNames))]
        public void TransformInputInAudioFileTest(string input, string expected)
        {
            var current = service.ConvertTo(input);

            Assert.True(expected.Equals(current.ToString()), $"expected: {expected} || current:{current}");
        }
        public static IEnumerable<object[]> FileNames =>
            new List<object[]>
            {
                new object[] { "05 - die mutter die ihr kinder verlor", "05 - Die Mutter Die Ihr Kinder Verlor" },
                new object[] { "01-Filename", "01 - Filename" },
                new object[] { "01. Holding On", "01 - Holding On" },
                new object[] { "01.Holding On", "01 - Holding On" },
                new object[] { "Holding On", "00 - Holding On" },
                new object[] { "holding on", "00 - Holding On" },
                new object[] { "01 FILEname the nAME", "01 - Filename The Name" },
                new object[] { "01 THIS IS ONLY THE BEGINNING", "01 - This Is Only The Beginning" },
                new object[] { "10 oUtro Teste em pOrtuguês com cÇedilha", "10 - Outro Teste Em Português Com Cçedilha" },
                new object[] { "06-Süßer Die Glocken Nie Klingen","06 - Süßer Die Glocken Nie Klingen" },
                new object[] { "Süßer Die Glocken Nie Klingen","00 - Süßer Die Glocken Nie Klingen" },
            };
    }
}
