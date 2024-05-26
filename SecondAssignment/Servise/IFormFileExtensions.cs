namespace SecondAssignment.Servise;
using System.Net.Http.Headers;
public static class IFormFileExtensions
{
    public static string GetFilename(this IFormFile file)
    {
        return ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
    }
}