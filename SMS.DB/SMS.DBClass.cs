using SMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DB
{
    public class Operations
    {
        public int AddData(StudentModel student)
        {
            using(var dbContext=new StudentEntities())
            {
                Students studentObj = new Students()
                {
                    name = student.name,
                    f_name = student.f_name,
                    address = student.address,
                    className = student.className
                };
                dbContext.Students.Add(studentObj);
                dbContext.SaveChanges();
                return studentObj.id;
            }
        }
        public int AddUser(Users user)
        {
            using (var dbContext = new StudentEntities())
            {
                Users userObj = new Users()
                {
                   username= user.username,
                   password= user.password
                };
                dbContext.Users.Add(userObj);
                dbContext.SaveChanges();
                return userObj.id;
            }
        }
        public bool ValidateUser(Users users) 
        {
            using (var dbContext = new StudentEntities())
            {
                bool isValid=dbContext.Users.Any(u => u.username == users.username && u.password == users.password);
                return isValid;
            }
        }
        public List<Users> getAllUsers()
        {
            using (var dbContext = new StudentEntities())
            {
                var usersData = dbContext.Users.ToList();
                return usersData;
            }
        }
        public List<Students> getAllData()
        {
            using(var dbContext=new StudentEntities())
            {
                var studentData=dbContext.Students.ToList();
                return studentData;
            }
        }
        public Students getStudentData(int id)
        {
            using (var dbContext = new StudentEntities())
            {
                var studentData = dbContext.Students.Where(x=>x.id==id).FirstOrDefault();
                return studentData;
            }
        }
        public bool deleteStudentData(int id)
        {
            using (var dbContext = new StudentEntities())
            {
                var student = new Students()
                {
                    id = id
                };
                dbContext.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
                //var studentData = dbContext.Students.Where(x => x.id == id).FirstOrDefault();
                //if (studentData != null)
                //{
                //    dbContext.Students.Remove(studentData);
                //    dbContext.SaveChanges();
                //    return true;
                //}
                return true;
            }
        }
        public bool updateStudentData(StudentModel model, int id)
        {
            using (var dbContext = new StudentEntities())
            {
                var student = new Students()
                {
                    id = id,
                    name = model.name,
                    f_name = model.f_name,
                    address = model.address,
                    className = model.className
                };
                dbContext.Entry(student).State=System.Data.Entity.EntityState.Modified; 
                dbContext.SaveChanges();
                return true;
                //var studentData = dbContext.Students.Where(x => x.id == id).FirstOrDefault();
                //if (studentData != null)
                //{
                //    studentData.name= model.name;
                //    studentData.address=model.address;
                //    studentData.f_name= model.f_name;
                //    studentData.className= model.className;
                //    dbContext.SaveChanges();
                //    return true;
                //}
                //return false;
            }
        }
    }
}
