using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace KPSP_Stamp
{
    class Methods
    {
        public ElementId getElementId(Document doc, string inputstring)
        {
            //var allTitleBlocksInView = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TitleBlocks).ToElements().ToList();
            ElementId eId = null;
            string[] names = inputstring.Split(' ');
            string familia = names[0];
            var allAST = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericAnnotation).WhereElementIsElementType().ToElements().ToList();
            foreach (var ast in allAST)
            {
                if (ast.Name == "Пустышка")
                    eId = ast.Id;
            }
            foreach (var ast in allAST)
            {
                if ((ast.Name.Contains(familia)) && !(familia.Count() == 0))
                    eId = ast.Id;
            }
            return eId;
        }
    }
}
