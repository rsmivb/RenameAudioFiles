using System;
using System.Globalization;

namespace FileNameHandler
{
    public class StringHandler
    {
        private TextInfo _textInfo;

        public StringHandler(TextInfo info)
        {
            _textInfo = info;
        }

        public string AddEmptySpace(string inputName, char separator)
        {
            var splitted = inputName.Split(separator);
            return string.Join($" {separator} ", splitted);
        }

        public string ToTitleCase(string inputStr)
        {
            return _textInfo.ToTitleCase(inputStr);
            throw new NotImplementedException();
        }
    }
}
