namespace IUWeb.Helpers
{
    public class FileUploads
    {
        public static string Upload(IFormFile file)
        {
            string Extension = Path.GetExtension(file.FileName);
            if(Extension == ".jpg" ||  Extension == ".png" || Extension == ".jpeg")
            {
                string NewFileName = Guid.NewGuid() + Extension;
                string UploadPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images", NewFileName);
                using(var stream = new FileStream(UploadPath, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }
                return NewFileName;
            }
            else
            {
                return "0";
            }
        }
    }
}
