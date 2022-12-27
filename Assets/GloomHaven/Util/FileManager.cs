using System;
using System.IO;
using UnityEngine;

namespace GloomHaven.Util
{
    public class FileManager
    {
        public static bool WriteToFile(string fileName, string contents)
        {
            var fullPath = Path.Combine(Application.persistentDataPath, fileName);
            try
            {
                File.WriteAllText(fullPath, contents);
                Debug.Log($"Saved to {fullPath}");
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to write {fullPath} with exception {e}");
            }

            return false;
        }

        public static bool ReadFromFile(string fileName, out string result)
        {
            var fullPath = Path.Combine(Application.persistentDataPath, fileName);

            if (File.Exists(fullPath))
                try
                {
                    result = File.ReadAllText(fullPath);
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to write {fullPath} with exception {e}");
                }

            result = "";
            return false;
        }
    }
}