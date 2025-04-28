using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using ClosedXML.Excel; // נשתמש בזה לקרוא את האקסל

namespace RaffleSite
{
    public partial class Default : System.Web.UI.Page
    {
        private static List<Student> students = new List<Student>();
        private static List<string> classes = new List<string> { "ט' - 1", "ט' - 2", "י' - 1", "י' - 2", "יא'' - 1", "יא'' - 2", "יב'' - 1", "יב'' - 2" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
                ddlClasses.DataSource = classes;
                ddlClasses.DataBind();
            }
        }

        private void LoadStudents()
        {
            try
            {
                var path = Server.MapPath("~/תלמידים.xlsx");
                using (var workbook = new XLWorkbook(path))
                {
                    var worksheet = workbook.Worksheet(1);
                    var table = worksheet.RangeUsed().AsTable();

                    students = table.DataRange.Rows()
                        .Select(r => new Student
                        {
                            ClassName = r.Field("כיתת אם").GetString().Trim(),
                            Name = r.Field("שם תלמיד").GetString().Trim()
                        })
                        .Where(s => !string.IsNullOrEmpty(s.ClassName) && !string.IsNullOrEmpty(s.Name))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                result.InnerText = "שגיאה בטעינת הקובץ: " + ex.Message;
            }
        }

        protected void btnRaffleClass_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string selectedClass = classes[rnd.Next(classes.Count)];
            result.InnerText = $"הכיתה שנבחרה: {selectedClass}";
        }

        protected void btnRaffleStudent_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string selectedStudent = students[rnd.Next(students.Count)].Name;
            result.InnerText = $"התלמידה שנבחרה: {selectedStudent}";
        }

        protected void btnRaffleStudentFromClass_Click(object sender, EventArgs e)
        {
            string selectedClass = ddlClasses.SelectedValue;
            var studentsInClass = students.Where(s => s.ClassName == selectedClass).ToList();

            if (studentsInClass.Any())
            {
                Random rnd = new Random();
                var selectedStudent = studentsInClass[rnd.Next(studentsInClass.Count)].Name;
                result.InnerText = $"מהכיתה {selectedClass}: {selectedStudent}";
            }
            else
            {
                result.InnerText = "אין תלמידות בכיתה זו.";
            }
        }

        public class Student
        {
            public string Name { get; set; }
            public string ClassName { get; set; }
        }
    }
}
