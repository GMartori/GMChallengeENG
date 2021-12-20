using GMChallengeENG.Contexts;
using GMChallengeENG.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GMChallengeENG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public static Object IsActive()
        {
            bool isActive = false;

            string output = isActive ? "User Active" : "User NOT Active";

            return output;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            //return context.Users.ToList();
            var usersActive = context.Users.Where(u => u.Active == true).ToList();
            return usersActive;
        }

        //https://localhost:44391/api/Users
        //Get Users Active
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        //https://localhost:44391/api/Users
        //Insert new Users
        #region "Json Raw Body"
        //{
        //    "name": "Maria Gazia Andrada",
        //    "birthDate": "1989-03-23",
        //    "active": true
        //}
        #endregion
        [HttpPost]
        public ActionResult Post([FromBody] Users users)
        {
            try
            {
                context.Users.Add(users);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //https://localhost:44391/api/Users/2
        //Update Users
        #region "Json Raw Body"
        //{
        //    "id": 2,
        //    "name": "Beto Martori",
        //    "birthDate": "2017-10-05T00:00:00",
        //    "active": true
        //}
        #endregion 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Users users)
        {
            try
            {
                if (users.Id == id)
                {
                    context.Entry(users).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //https://localhost:44391/api/Users/2
        //Update Active field 
        #region "Json Raw Body"
        //[
        //    {
        //        "op": "replace",
        //        "path": "Active",
        //        "value": "true"
        //    }
        //]
        #endregion
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<Users> users)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);

                if (user != null)
                {
                    users.ApplyTo(user, ModelState);
                    context.SaveChanges();
                    return Ok();
                }
                else
                    return BadRequest();

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        //https://localhost:44391/api/Users/2
        //Delete User
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);

                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
