using System;
using System.Linq;

using RestKami.Core.Interfaces;

namespace RestKami.Core
{
    public sealed class StringSeedDataGenerator : IStringSeedDataGenerator
    {
        private const int MaxDefaultStringCount = 1000;

        private const int LongStringStartLength = 50;

        private const int LongStringStep = 50;

        public string[] GenerateDefaultStrings(uint count = 100)
        {
            if (count > MaxDefaultStringCount)
            {
                throw new ArgumentException(nameof(count));
            }

            var result = new string[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = this.GenerateDefaultStringInternal();
            }

            return result;
        }

        public string[] GenerateLongString()
        {
            char generatedChar = (char)97;

            var result = new string[100];

            int currentLength = LongStringStartLength;
            for (int i = 0; i < 100; i++)
            {
                currentLength = currentLength + LongStringStep;
                result[i] = new string(generatedChar, currentLength);
            }

            return result;
        }

        public string[] GenerateEmptyLikeStrings()
        {
            return new[]
            {
                "null",
                "NULL",
                this.GenerateDefaultStringInternal() + " ",
                " " + this.GenerateDefaultStringInternal()
            };
        }

        public string[] GenerateStringWithEscapeCharacters()
        {
            var chars = new char[256];
            for (int i = 0; i < 256; i++)
            {
                chars[i] = (char)i;
            }

            return chars
                .Where(a => !char.IsControl(a))
                .Select(a => this.GenerateDefaultStringInternal() + a)
                .ToArray();
        }

        private string GenerateDefaultStringInternal()
        {
            var random = new Random();
            int skipCount = random.Next(1, 21);
            int takeCount = random.Next(skipCount, 63);

            var chars = new char[62];
            int j = 0;

            for (int i = 97; i <= 122; i++)
            {
                chars[j++] = (char)i;
            }

            for (int i = 65; i <= 90; i++)
            {
                chars[j++] = (char)i;
            }

            for (int i = 48; i <= 57; i++)
            {
                chars[j++] = (char)i;
            }

            var defaultCharsArray = chars.Skip(skipCount).Take(takeCount).ToArray();
            string result = new string(defaultCharsArray);

            return result;
        }
    }
}