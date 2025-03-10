using Raylib_cs;
using System.Runtime.InteropServices;
using System.Text;

namespace RayGUI_cs
{
    /// <summary>Container component of the library.</summary>
    public class DropZone : Component
    {
        private readonly List<string> Files;

        /// <summary>The abosulte file path for the output directory.</summary>
        public string OutputFilePath;

        /// <summary>Acceptable file types when file is dropped.</summary>
        public string[] Extensions;

        /// <summary>Last dropped file.</summary>
        public string LastFile;

        /// <summary>Returns the number of files contained inside of the output directory.</summary>
        public int FileCount { get { return Files.Count; } }

        /// <summary>Initializes a new instance of <see cref="Container"/>.</summary>
        /// <param name="x">X Position of the container</param>
        /// <param name="y">Y Position of the container</param>
        /// <param name="width">Width of the container</param>
        /// <param name="height">Height of the container</param>
        public DropZone(int x, int y, int width, int height) : base(x, y, width, height)
        {
            Extensions = []; // Accept any file by default
            OutputFilePath = Directory.GetCurrentDirectory(); // Working directory by default
            Files = [..Directory.GetFiles(OutputFilePath)]; // Retrieve already present files
            LastFile = "";
        }

        /// <summary>Adds a file to the list of the container.</summary>
        /// <param name="file">File to add</param>
        public void AddFile(string file)
        {
            Files.Add(file);
        }

        /// <summary>Deletes a file from the list of the container.</summary>
        /// <param name="index">File to remove</param>
        public void DeleteFile(int index)
        {
            Files.RemoveAt(index);  
        }

        /// <summary>Returns a file from the list of the container.</summary>
        /// <param name="index">Index of the file.</param>
        /// <returns>The requested file.</returns>
        public string GetFile(int index)
        {
            return Files[index];
        }

        /// <summary>Returns the latest file added to the list of the container.</summary>
        /// <returns>The requested file.</returns>
        public string GetLastFile()
        {
            return Files.Last();
        }

        /// <summary>Clears the list of files of the container.</summary>
        public void ClearFiles()
        {
            Files.Clear();
            Files.Add("");
        }

        /// <summary>Checks if a file exists in the list of the container.</summary>
        /// <param name="file">File to search for</param>
        /// <returns>Returns <see langword="true"/> if the file exists. <see langword="false"/> otherwise.</returns>
        public bool Contains(string file)
        {
            return Files.Contains(file);
        }

        /// <param name="c">Corresponding container</param>
        internal static DropZone ImportFiles(DropZone c)
        {
            FilePathList filePathList = Raylib.LoadDroppedFiles();
            string path = ConvertFilePathList(filePathList)[0];
            string[] pathArray = path.Split('.');
            string[] pathArryBySlash = path.Split('\\');
            string fileName = pathArryBySlash.Last();

            // Copy file to output directory of the container
            if (c.Extensions.Contains(pathArray.Last()) || c.Extensions.Length == 0)
            {
                try
                {
                    File.Copy(path, c.OutputFilePath + "\\" + fileName, true);
                    c.AddFile(c.OutputFilePath + "\\" + fileName);
                    // Add file path to the container
                    Debugger.Send($"File {fileName} received successfully", ConsoleColor.Green);
                }
                catch
                {
                    Debugger.Send($"File could not be received, either wrong destination ({c.OutputFilePath}) or unsuitable source file ({path}))", ConsoleColor.Yellow);
                }
            }
            else
            {
                string err = "File could not be received, required extension(s):";
                for (int i = 0; i < c.Extensions.Length; i++) err += $" .{c.Extensions[i]}";
                Debugger.Send(err, ConsoleColor.Yellow);
            }
            Raylib.UnloadDroppedFiles(filePathList);

            // Return modified container
            return c;
        }

        /// <summary>Converts a <see cref="FilePathList"/> to UTF-8 strings.</summary>
        /// <param name="files">Received files.</param>
        /// <returns>UTF-8 strings.</returns>
        private static unsafe string[] ConvertFilePathList(FilePathList files)
        {
            string[] paths = new string[files.Count];

            for (int i = 0; i < paths.Length; i++)
            {
                IntPtr pathPtr = Marshal.ReadIntPtr((IntPtr)files.Paths, i * IntPtr.Size);
                byte[] rawBytes = GetUtf8Bytes(pathPtr);
                paths[i] = Encoding.UTF8.GetString(rawBytes);
            }

            return paths;
        }

        /// <summary>Returns UTF-8 bytes from an Integer Pointer.</summary>
        /// <param name="ptr">Pointer.</param>
        /// <returns>UTF-8 Bytes.</returns>
        private static byte[] GetUtf8Bytes(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero) return Array.Empty<byte>();

            // Trouver la longueur de la chaîne (NULL-terminated)
            int length = 0;
            while (Marshal.ReadByte(ptr, length) != 0) length++;

            // Lire les bytes en UTF-8
            byte[] bytes = new byte[length];
            Marshal.Copy(ptr, bytes, 0, length);
            return bytes;
        }
    }
}