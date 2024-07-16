


using System.IO;

class Program
{
    public static void Main()
    {
        string folder = @"C:\Users\tjs_u\Here There Be Files\";
        string fileName = "test.txt";

        // Check if the file exists, this will return a boolean
        // value, if the file exists then the boolean will be true
        // if the file does not exist then the boolean will be false
        bool fileExists = CheckFileExists(folder + fileName);
        // if this is the first time running this application
        // then fileExists boolean will be false

        // Creating a file with the existing filename and folder
        // set as variables, this will use the CreateAFile method
        // with File.WriteAllText to create the file with the text
        CreateAFile(folder + fileName);

        // Creating a file with a different filename and the set folder
        // this will use the CreateAFile method with StreamWriter method 
        CreateAFile(folder, "A different File.txt");

        // The methods enclosed in this if statement will only run if the
        // fileExists boolean is true, this will check if the file exists
        if (fileExists)
        {
            // Appending text to the file 
            AppendToFile(folder + fileName);

            // Reading the file that already exists
            ReadAFile(folder + fileName);

            // Creating a folder with the folder variable
            CreateFolder(folder);

            // Deleting a folder with the folder variable
            //DeleteFolder(folder);
            
            // Getting file information
            GetFileInfo(folder + fileName);
        }
    }

    private static void GetFileInfo(string filePath)
    {
        Console.WriteLine();
        Console.WriteLine($"Getting File Info for {filePath}");
        Console.WriteLine("### Using File Class ###");

        Console.WriteLine($"File Type: {File.GetAttributes(filePath)}");
        Console.WriteLine($"Creation Time: {File.GetCreationTime(filePath)}");
        Console.WriteLine($"File Last Accessed: {File.GetLastAccessTime(filePath)}");
        Console.WriteLine($"File Last Written to: {File.GetLastWriteTime(filePath)}");
        Console.WriteLine();

        // Creating a new instance of the FileInfo class using the filePath variable
        FileInfo fileInfo = new FileInfo(filePath);

        Console.WriteLine("### Using FileInfo Class ###");
        Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
        Console.WriteLine($"File Extension: {fileInfo.Extension}");
        Console.WriteLine($"File Size: {fileInfo.Length} bytes");
        Console.WriteLine($"Directory: {fileInfo.DirectoryName}");
        Console.WriteLine($"Full Path: {fileInfo.FullName}");
    }

    private static void DeleteFolder(string folder)
    {
        if (Directory.Exists(folder))
        {
            Directory.Delete(folder);
            Console.WriteLine("Folder Deleted!");
        }
        else
        {
            Console.WriteLine("Folder does not exist!");
        }
    }

    private static bool CheckFileExists(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist!");
            return false;
        }
        else
        {
            Console.WriteLine("File Exists!");
            return true;
        }
    }

    private static void CreateFolder(string folder)
    {
        // Check if directory exists
        if (Directory.Exists(folder))
        {
            Console.WriteLine("Folder already exists!");
            return;
        }
        else
        {
            // Create the directory
            Directory.CreateDirectory(folder);
        }
    }

    private static void AppendToFile(string filePath)
    {
        string text = """
            Here is some information that I am going to append to the file
            and this will appear on the next line
            with this on the bottom line
            """;
        File.AppendAllText(filePath, text);
    }

    private static void ReadAFile(string filePath)
    {
        // Ideally you would want to check if the file exists
        // but this is done prior to calling this method
        string readText = File.ReadAllText(filePath);
        Console.WriteLine(readText);
    }

    private static void CreateAFile(string filePath)
    {
        // This will create a file with the text below using the File.WriteAllText method
        string text = $"Hi there, I will now appear inside the file {filePath}";
        File.WriteAllText(filePath, text);
    }

    private static void CreateAFile(string folder, string fileName)
    {
        // This will create a file with the text below using the StreamWriter method
        using (StreamWriter sw = File.CreateText(folder + fileName))
        {
            sw.WriteLine("File text here!");
            Console.WriteLine($"""
                File: {fileName} successfully added to 
                Folder: {folder}
                """);
        }
    }
}
