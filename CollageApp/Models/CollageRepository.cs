namespace CollageApp.Models
{
    public class CollageRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>(){
                new Student
                {
                    Id = 1,
                    StudentName = "Student 1",
                    Email = "studentemail@gmail.com",
                    Address = "Hyd, India"
                },
                new Student
                {
                    Id = 2,
                    StudentName = "Student 2",
                    Email = "studentemail2@gmail.com",
                    Address = "Hyd, BD"
                },
            };
    }
}
