using System.Text.Json;

namespace NetflixMVC.ViewModel
{
    public class ErrorVM
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
