using System.IO;

namespace Avito.UI.Interfaces
{
    public interface IFileProvider
    {
        Stream OpenFile();
        Stream CreateFile();
    }
}