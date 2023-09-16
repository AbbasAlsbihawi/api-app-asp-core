 
using api_app.Data;
using api_app.Logging;
using api_app.models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace api_app.Controllers
{
    //[Route("api/user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly ILogger<UserController> _logger;

        //public UserController(ILogger<UserController> logger)
        //{
        //    _logger = logger;
        //}
        //private readonly ILogging _logger;

        //public UserController(ILogging logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _db;

        public UserController (ApplicationDbContext db) {
            _db = db;
        }
 
 

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
		public ActionResult< IEnumerable<UserDTO>> GetUsers(int page, int pageSize)
		{
            //_logger.log("Get User Data", "info");
            //_logger.LogInformation("Get User Data");
            
            return Ok(_db.user
                .OrderBy(c => c.Id)
                .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToList());
		}
        //[ProducesResponseType(200, Type = typeof(UserDTO))] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}",Name = "GetUserByID")]
        public ActionResult<UserDTO> GetUserBy(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user= UserStore.listUser.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            //_logger.LogInformation("Get User By Id");
            //_logger.log("Get User Data : "+id, "info");
            return Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (UserStore.listUser.FirstOrDefault(item => item.UserName.ToLower() == userDTO.UserName.ToLower()) != null)
            {
                ModelState.AddModelError("custem error", "user ready Exists!");
                return BadRequest(ModelState);
            }
            if (userDTO == null)
                return BadRequest(userDTO);
            if (userDTO.Id > 0) 
                return StatusCode(StatusCodes.Status500InternalServerError);
            userDTO.Id = UserStore.listUser.OrderByDescending(item => item.Id).FirstOrDefault().Id + 1;
            UserStore.listUser.Add(userDTO);
            return CreatedAtRoute("GetUserByID", new {id=userDTO.Id}, userDTO);

        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "deleteUserByID")]
        public IActionResult DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = UserStore.listUser.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateUserByID")]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            if (userDTO == null || id!=userDTO.Id)
                return BadRequest(userDTO);
            var user = UserStore.listUser.FirstOrDefault(u => u.Id == id);
            user.UserName = userDTO.UserName;
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "updatePartilUserByID")]
        public IActionResult UpdatePartilUser(int id, JsonPatchDocument<UserDTO> patchDTO)
        {
            if (patchDTO == null || id ==0)  return BadRequest();
            var user = UserStore.listUser.FirstOrDefault(u => u.Id == id);
            if(user==null) return BadRequest();

            patchDTO.ApplyTo(user, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            return NoContent();
        }

    }
}

