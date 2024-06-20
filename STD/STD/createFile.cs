using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace STD
{
    public struct indexingInfo
    {
        public string num1;
        public string num2;
        public string fio;
        public string serial;
        public string number;
        public string date;
        public string issuedBy;
        public string registrAddress;
        public string salary;
        public string rate;
        public string mainDate;
    }
    internal class createFile
    {
        private FileInfo fileInfo;
        private string indexingPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "indexingTemplayte.docx"); // replace
        private string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string indexingDirectName = "Индексация";

        public bool createIndexing(indexingInfo value)
        {
            try
            {
                if (File.Exists(indexingPath))
                    fileInfo = new FileInfo(indexingPath);
                else
                    return false;

                string folderPath = Path.Combine(desktopPath, indexingDirectName);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                Dictionary<string, string> items = new Dictionary<string, string>
            {
                { "<num1>", value.num1 },
                { "<num2>", value.num2 },
                { "<date_main>", value.mainDate },
                { "<FIO>", value.fio },
                { "<serial>", value.serial },
                { "<number>", value.number },
                { "<date>", value.date },
                { "<kem_vidan>", value.issuedBy },
                { "<addres_reg>", value.registrAddress },
                { "<zp>", value.salary },
                { "<stavka>", value.rate }
            };

                Word.Application app = new Word.Application();
                Object file = fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);

                foreach (var i in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = i.Key;
                    find.Replacement.Text = i.Value;
                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;
                    find.Execute
                    (
                        FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace
                    );
                }

                Object newFileName = folderPath + "\\document.doc";
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                app.Quit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}
