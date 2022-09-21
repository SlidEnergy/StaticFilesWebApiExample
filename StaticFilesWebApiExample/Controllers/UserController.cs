using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace StaticFilesWebApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("avatar")]
        public async Task<IActionResult> SaveAvatar(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {

                    byte[] data = null;
                    using (var fs1 = file.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        data = ms1.ToArray();
                    }

                    var name = Guid.NewGuid().ToString().Replace("-", "");

                    var fileExtension = GetFileExtension(file.FileName);

                    var fileName = $"{name}.{fileExtension}";

                    await System.IO.File.WriteAllBytesAsync(fileName, data);

                    new UserRepository().SaveAvatar(fileName);
                }
            }

            return NoContent();
        }

        [HttpGet]
        public ActionResult<UserDto> GetUser()
        {
            var user =  new UserRepository().GetUser();

            var repository = new FilesRepository();

            var file = repository.FindFileByFileName(user.AvatarFileName);

            if (file == null)
            {
                file = repository.SaveFile(user.AvatarFileName);
            }

            return new UserDto(user.Id, user.Name, file.Token);
        }

        private string GetFileExtension(string fileName)
        {
            return "png";
        }
    }
}