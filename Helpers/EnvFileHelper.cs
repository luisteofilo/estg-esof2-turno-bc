using DotNetEnv;

namespace Helpers;

public static class EnvFileHelper
{
    static EnvFileHelper()
    {
        LoadEnvFile();
    }
    
    private static void LoadEnvFile()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var envFilePath = Path.Combine(currentDirectory, ".env");

        if (!File.Exists(envFilePath))
        {
            // Try loading from parent directory
            string? parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            if (parentDirectory != null) envFilePath = Path.Combine(parentDirectory, ".env");

            if (!File.Exists(envFilePath))
            {
                throw new FileNotFoundException("The .env file could not be found in the current or parent directory.");
            }
        }
        
        Console.WriteLine(envFilePath);

        Env.Load(envFilePath);
    }

    public static string GetString(string key)
    {
        return Env.GetString(key);
    }
}