using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework1.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework1.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public List<User> userList= new List<User>()
        {
            new User
            {
                Id = 1,
                Username = "alidemir",
                Password = "123456"
            },
            new User
            {
                Id = 2,
                Username = "aysedemir",
                Password = "987655"
            },
            new User
            {
                Id = 3,
                Username = "aliyılmaz",
                Password = "345612"
            },
            new User
            {
                Id = 4,
                Username = "mehmetdemir",
                Password = "234567"
            }
        };

        //Listeleme
        [HttpGet("getall")]
        public List<User> GetAll(){
            var users = userList.ToList();
            return users;
        }

        //Ekleme
        [HttpPost("add")]
        public bool Add([FromBody] User user)
        {
            User newUser = new User();
            newUser.Id = user.Id;
            newUser.Username = user.Username;
            newUser.Password = user.Password;
            userList.Add(newUser);
            return true;
        }

        //Güncelleme
        [HttpPut("update")]
        public bool Put([FromBody] User user,int id)
        {
            var findUser = userList.SingleOrDefault(u => u.Id == id);
            if(findUser == null)
            {
                return false;
            }
            //Gelen değer 0 veya Null ise listedeki değeri kullan 
            findUser.Id = user.Id == 0 ? findUser.Id = findUser.Id : findUser.Id = user.Id;
            findUser.Username = user.Username == null ? findUser.Username = findUser.Username : findUser.Username = user.Username;
            findUser.Password = user.Password == null ? findUser.Password = findUser.Password : findUser.Password = user.Password;
            return true;
        }

        //Silme
        [HttpDelete("remove")]
        public bool Delete(int id)
        {
            var user = userList.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }
            userList.Remove(user);
            return true;

        }
        
    }
}
