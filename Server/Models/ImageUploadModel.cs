namespace Server.Models;

public class ImageUploadModel
{
    public IFormFile Image { get; set; }
    public string Description { get; set; }
}
