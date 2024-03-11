using System;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Ask for file path
        Console.WriteLine("Enter the path to the image folder:");
        string folderPath = Console.ReadLine();

        // Ask for file name
        Console.WriteLine("Enter the image file name:");
        string fileName = Console.ReadLine();

        // Ask for file type (extension)
        Console.WriteLine("Enter the image file type (e.g., jpg, png):");
        string fileType = Console.ReadLine();

        // Concatenate to form the full file path
        string filePath = System.IO.Path.Combine(folderPath, $"{fileName}.{fileType}");
        Console.WriteLine($"Looking for image at: {filePath}");

        try
        {
            using (Image image = Image.FromFile(filePath))
            {
                // Access the property items (metadata)
                PropertyItem[] propItems = image.PropertyItems;

                if (propItems.Length == 0)
                {
                    Console.WriteLine("No metadata found.");
                }
                else
                {
                    foreach (PropertyItem propItem in propItems)
                    {
                        Console.WriteLine($"ID: {propItem.Id}, Type: {propItem.Type}, Length: {propItem.Len}");
                    }
                }
                Console.WriteLine("Metadata processing completed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Keep the console window open and provide feedback
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
