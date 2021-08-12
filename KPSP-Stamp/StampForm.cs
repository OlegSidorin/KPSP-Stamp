using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form = System.Windows.Forms.Form;

namespace KPSP_Stamp
{
    public partial class StampForm : Form
    {
        public SaveButtonExternalEvent saveButtonExternalEvent;
        public ExternalEvent externalEvent;
        public StampForm()
        {
            InitializeComponent();
            saveButtonExternalEvent = new SaveButtonExternalEvent();
            externalEvent = ExternalEvent.Create(saveButtonExternalEvent);
        }

        private void CancelStampButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveStampButton_Click(object sender, EventArgs e)
        {

            SaveButtonExternalEvent.dol1 = tBox11.Text;
            SaveButtonExternalEvent.dol2 = tBox12.Text;
            SaveButtonExternalEvent.dol3 = tBox13.Text;
            SaveButtonExternalEvent.dol4 = tBox14.Text;
            SaveButtonExternalEvent.dol5 = tBox15.Text;
            SaveButtonExternalEvent.dol6 = tBox16.Text;
            SaveButtonExternalEvent.fam1 = tBox21.Text;
            SaveButtonExternalEvent.fam2 = tBox22.Text;
            SaveButtonExternalEvent.fam3 = tBox23.Text;
            SaveButtonExternalEvent.fam4 = tBox24.Text;
            SaveButtonExternalEvent.fam5 = tBox25.Text;
            SaveButtonExternalEvent.fam6 = tBox26.Text;
            SaveButtonExternalEvent.allSheets = cBox.Checked;
            externalEvent.Raise();
            Close();
        }
    }
    public class SaveButtonExternalEvent : IExternalEventHandler
    {
        public static string dol1 = "";
        public static string dol2 = "";
        public static string dol3 = "";
        public static string dol4 = "";
        public static string dol5 = "";
        public static string dol6 = "";
        public static string fam1 = "";
        public static string fam2 = "";
        public static string fam3 = "";
        public static string fam4 = "";
        public static string fam5 = "";
        public static string fam6 = "";
        public static bool allSheets = false; 
        public static ElementId EID = null;

        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = uidoc.Document;
            var vsSet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).ToElements().Cast<ViewSheet>().ToList();
            var avs = doc.ActiveView as ViewSheet;
            if (!allSheets)
            {
                vsSet.Clear();
                vsSet.Add(avs);
            }

            ElementId eId = new ElementId(3078372);

            var allAST = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericAnnotation).ToElements().Where(n => n.Name.ToString().Contains("Адам")).ToList();
            foreach (var ast in allAST)
            {
                eId = ast.Id;
            }
            var allTitleBlocksInView = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TitleBlocks).ToElements().ToList();
            foreach (var tb in allTitleBlocksInView)
            {
                ParameterSet ps = tb.Parameters;
                foreach (Parameter p in ps)
                {
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 1 подпись")
                    {
                        using (Transaction tr = new Transaction(doc, "010"))
                        {
                            tr.Start();
                            try
                            {
                                bool bb = p.Set(eId);    //("КПСП_Подписи: Проценко Роман Геннадьевич");
                            }
                            catch (Exception e)
                            {
                                TaskDialog.Show("1", e.ToString());
                            }
                            tr.Commit();
                        }
                    }
                }
            }
            
            foreach (var vs in vsSet)
            {
                ParameterSet ps = vs.Parameters;
                foreach (Parameter p in ps)
                {
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 1 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "011"))
                            {
                                tr.Start();
                                p.Set(dol1);
                                tr.Commit();
                            }

                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 2 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "012"))
                            {
                                tr.Start();
                                p.Set(dol2);
                                tr.Commit();
                            }

                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 3 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "013"))
                            {
                                tr.Start();
                                p.Set(dol3);
                                tr.Commit();
                            }

                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 4 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "014"))
                            {
                                tr.Start();
                                p.Set(dol4);
                                tr.Commit();
                            }

                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 5 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "015"))
                            {
                                tr.Start();
                                p.Set(dol5);
                                tr.Commit();
                            }

                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 6 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "016"))
                            {
                                tr.Start();
                                p.Set(dol6);
                                tr.Commit();
                            }

                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 1 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "021"))
                            {
                                tr.Start();
                                p.Set(fam1);
                                tr.Commit();
                            }
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 2 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "022"))
                            {
                                tr.Start();
                                p.Set(fam2);
                                tr.Commit();
                            }
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 3 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "023"))
                            {
                                tr.Start();
                                p.Set(fam3);
                                tr.Commit();
                            }
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 4 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "024"))
                            {
                                tr.Start();
                                p.Set(fam4);
                                tr.Commit();
                            }
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 5 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "025"))
                            {
                                tr.Start();
                                p.Set(fam5);
                                tr.Commit();
                            }
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 6 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            using (Transaction tr = new Transaction(doc, "026"))
                            {
                                tr.Start();
                                p.Set(fam6);
                                tr.Commit();
                            }
                        }
                    }

                }
            }

            return;
        }

        public string GetName()
        {
            return "External Event On Save Button";
        }
    }
}
