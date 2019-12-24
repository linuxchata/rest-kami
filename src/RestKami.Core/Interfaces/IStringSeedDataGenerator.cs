namespace RestKami.Core.Interfaces
{
    public interface IStringSeedDataGenerator
    {
        string[] GenerateDefaultString(uint count = 100);

        string[] GenerateLongString();

        string[] GenerateEmptyLikeStrings();

        string[] GenerateStringWithEscapeCharacters();
    }
}