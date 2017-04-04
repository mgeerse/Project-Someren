using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Someren
{
    class SomerenModel
    {
        public class Student
        {
            int Id;
            string naam;

            public void setNaam(string naamStudent)
            {
                naam = naamStudent;
            }

            public void setId(int StudentId)
            {
                Id = StudentId;
            }

            public string getNaam()
            {
                return naam;
            }

            public int getId()
            {
                return Id;
            }
        }
        public class Docent
        {
            int Id;
            string naam;

            public void setNaam(string naamStudent)
            {
                naam = naamStudent;
            }

            public void setId(int StudentId)
            {
                Id = StudentId;
            }

            public string getNaam()
            {
                return naam;
            }

            public int getId()
            {
                return Id;
            }
        }

        public class StudentList
        {
            List<SomerenModel.Student> sl = new List<SomerenModel.Student>();
            
            public void addList(SomerenModel.Student s) {
                sl.Add(s);
            }

            public List<SomerenModel.Student> getList()
            {
                return sl;
            }
        }
        public class DocentList
        {
            List<SomerenModel.Docent> dl = new List<SomerenModel.Docent>();

            public void addList(SomerenModel.Docent d)
            {
                dl.Add(d);
            }

            public List<SomerenModel.Docent> getList()
            {
                return dl;
            }
        }

    }
}
