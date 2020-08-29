using System.IO;
using System.Windows.Forms;
using Avito.UI.Interfaces;
using Shared.Utils.Lib.Entities.String;

namespace Avito.UI.WinForms.Logic
{
    public class FileSystemFileProvider : IFileProvider
    {
        public Stream OpenFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return Stream.Null;
                }

                return File.OpenRead(dialog.FileName);
            }
        }

        public Stream CreateFile()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return Stream.Null;
                }

                string fileName = dialog.FileName;
                if (new IsEmptyString(Path.GetExtension(fileName)))
                {
                    fileName += ".layout";
                }

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                return File.Create(fileName);
            }
        }
    }
}