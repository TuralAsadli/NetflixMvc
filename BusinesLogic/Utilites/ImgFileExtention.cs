using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Utilites
{
    public static class ImgFileExtention
    {
        public static bool CheckImgSize(this IFormFile file)
        {
            return true;
        }

        public static bool CheckImgFileType(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static string ChangeImgFileName(this IFormFile file)
        {
            return Guid.NewGuid().ToString() + file.FileName;
        }

        public static void CreateImgFile(this IFormFile file, string path)
        {
            if (file == null)
            {
                return;
            }

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }
        }


        public static void DeleteImgFile(string path)
        {
            if (path == null)
            {
                return;
            }
            if (!File.Exists(path))
            {
                return;
            }


            File.Delete(path);
        }
    }
}
