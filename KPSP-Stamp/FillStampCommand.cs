using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace KPSP_Stamp
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class FillStampCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            string str = "";
            try
            {
                StampForm myForm = new StampForm();
                var vs = doc.ActiveView as ViewSheet;
                ParameterSet ps = vs.Parameters;
                foreach (Parameter p in ps)
                {
                    #region Должность
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 1 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox11.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 2 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox12.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 3 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox13.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 4 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox14.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 5 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox15.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 6 должность")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox16.Text = p.AsString();
                        }
                    }
                    #endregion
                    #region Фамилии
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 1 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox21.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 2 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox22.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 3 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox23.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 4 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox24.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 5 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox25.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп строка 6 фамилия")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox26.Text = p.AsString();
                        }
                    }
                    #endregion
                    #region Даты
                    if (p.Definition.Name.ToLower() == "мск_штамп дата 1")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox41.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп дата 2")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox42.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп дата 3")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox43.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп дата 4")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox44.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп дата 5")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox45.Text = p.AsString();
                        }
                    }
                    if (p.Definition.Name.ToLower() == "мск_штамп дата 6")
                    {
                        if (p.StorageType == StorageType.String)
                        {
                            myForm.tBox46.Text = p.AsString();
                        }
                    }
                    #endregion
                }
                myForm.Show();
            }
            catch (Exception e)
            {
                TaskDialog.Show("!", "Это не Лист, тут нечего делать...\n");
            }
            
            
            //myForm.tBox11.Text = str;
            //myForm.tBox21.Text = "Фамилие";
            //myForm.tBox31.Text = "Подпись";
            //myForm.tBox41.Text = "Дата";
            //TaskDialog.Show("Warning", str);
            return Result.Succeeded;
        }
    }
}
