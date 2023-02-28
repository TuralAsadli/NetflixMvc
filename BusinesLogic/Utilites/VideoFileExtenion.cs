using Microsoft.AspNetCore.Http;

using System.IO;
using System.IO.Pipelines;
using NReco.VideoInfo;

namespace BusinesLogic.Utilites
{
    public static class VideoFileExtenion
    {
        public static bool CheckVideoSize(this IFormFile file)
        {
            return true;
        }

        public static bool CheckVideoFileType(this IFormFile file)
        {
            return file.ContentType.Contains("video");
        }

        public static string ChangeVideoFileName(this IFormFile file)
        {
            return Guid.NewGuid().ToString() + file.FileName;
        }

        public static void CreateVideoFile(this IFormFile file, string path)
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


        public static void DeleteVideoFile(string path)
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

        public static TimeSpan GetVideoDuration(string filePath)
        {
            //var file = ShellFile.FromFilePath(filePath);
            //var duration = (ulong?)file.Properties.System.Media.Duration.Value;
            //var durationSeconds = duration / 10000000;
            //var durationTimeSpan = TimeSpan.FromSeconds(durationSeconds.GetValueOrDefault());
            //return durationTimeSpan;
            var ffProbe = new FFProbe();
            var info = ffProbe.GetMediaInfo(filePath);
            var duration = TimeSpan.FromSeconds(info.Duration.TotalSeconds);
            return duration;
        }

        public static string ConvertTimeSpan (this TimeSpan time)
        {
             // 4 hours and 33 minutes
            string formattedTimeSpan = string.Format("{0:%h}hr {0:%m}min", time);
            return formattedTimeSpan; // Output: "4hr 33min"
        }


    }
}
