namespace DTest.Services;


public class PackageService : IPackageService
{
    public string CheckPackage(string name, string version)
    {
        return "This was run through the service";
    }
}
