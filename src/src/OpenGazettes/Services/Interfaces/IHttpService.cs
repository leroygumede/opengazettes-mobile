using System.Net.Http;
using System.Threading.Tasks;

namespace OpenGazettes.Services.Interfaces
{
    public interface IHttpService
    {
        HttpClient Client { get; }
    }
}