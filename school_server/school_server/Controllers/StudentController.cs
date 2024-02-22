using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace school_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<Student> Students = new List<Student>
        {
            new Student{id=1,firstName="Yudit",familyName="Ashlag",adress="Nachum 14",phone="0583261142",active=true,marksAvg=100,profession = 1, birthDate=DateTime.Now,year=1},
            new Student{id=2,firstName="Rutti",familyName="Abeles",adress="kibuts-galuyot 5",phone="0504106914",active=false,marksAvg=100,profession=1,birthDate=DateTime.Now,year=2},
            new Student{id=3,firstName="esty",familyName="Ashlag",adress="Zabotinsky 116",phone="0527641832",active=true,marksAvg=07,profession=1,birthDate=DateTime.Now,year=1},
            new Student{id=4,firstName="yaffi",familyName="Ashlag",adress="Razovsky 7",phone="9533109206",active=true,marksAvg=89,profession=1,birthDate=DateTime.Now,year=1},
            new Student{id=5,firstName="gili",familyName="Ashlag",adress="Hashomer 41",phone="0527153268",active=false,marksAvg=99,profession=1,birthDate=DateTime.Now,year=1},
            new Student{id=6,firstName="malki",familyName="Ashlag",adress="Kahanman 67",phone="0556776345",active=true,marksAvg=90,profession=1,birthDate=DateTime.Now,year=1},
            new Student{id=7,firstName="noaa",familyName="Ashlag",adress="Ezra 12",phone="0504100577",active=false,marksAvg=78,profession=1,birthDate=DateTime.Now,year=1}
        };

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return Students;
        }

        // GET api/<StudentController>/active
        [HttpGet("active={active}")]
        public IEnumerable<Student> Get(bool active)
        {
            if (active)
                return Students.Where(student => student.active);
            return Students;
        }

        [HttpGet("name={name}")]
        public IEnumerable<Student> Get(string name)
        {
            return Students.Where(s => s.firstName.Contains(name) || s.familyName.Contains(name));
        }


        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student )
        {
            Students.Add(student);
             return Ok(true);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student s )
        {
            Student student = Students.Find(s => s.id == id);
            if (student != null)
            {
                student.phone = s.phone;
                student.active = s.active;
                student.year = s.year;
                student.profession = s.profession;
                student.adress = s.adress;
                student.birthDate= s.birthDate;
                student.familyName = s.familyName;
                student.firstName = s.firstName;
                return Ok(true);
            }
            return Ok(false);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var student = Students.Find(s => s.id == id);
            Students.Remove(student);
            if (!Students.Contains(student))
                return true;
            return false;
        }
    }
}
