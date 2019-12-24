using System.Threading.Tasks;

namespace RestKami.Core.Interfaces
{
    public interface IRouteParameterVerifier
    {
        Task Verify(TestCase testCase);
    }
}