namespace RestKami.Core.Interfaces
{
    public interface IStringSeedDataGenerator
    {
        string[] GenerateDefaultStrings(uint count = 100);

        string[] GenerateLongString();

        string[] GenerateEmptyLikeStrings();

        string[] GenerateStringWithEscapeCharacters();
    }
}