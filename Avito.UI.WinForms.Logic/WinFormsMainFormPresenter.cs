using System.IO;
using Avito.Search;
using Avito.UI.Interfaces;
using Avito.UI.PresentationLogic;

namespace Avito.UI.WinForms.Logic
{
    public class WinFormsMainFormPresenter : BaseMainFormPresenter, IMainFormPresenter
    {
        private const string DefaultLayoutFileName = "default.layout";

        public WinFormsMainFormPresenter(AvitoSettings settings, IMainForm form) : base(settings, form, new FileSystemFileProvider())
        {
        }

        protected override Stream GetDefaultLayoutStreamRead()
        {
            if (!File.Exists(DefaultLayoutFileName) || new FileInfo(DefaultLayoutFileName).Length == 0)
            {
                return Stream.Null;
            }

            return File.OpenRead(DefaultLayoutFileName);
        }

        protected override Stream GetDefaultLayoutStreamWrite()
        {
            if (File.Exists(DefaultLayoutFileName))
            {
                File.Delete(DefaultLayoutFileName);
            }

            return File.Create(DefaultLayoutFileName);
        }
    }
}