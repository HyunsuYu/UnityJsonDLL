using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace UnityJsonDll
{
    public static class CustomUnityJsonuUtility
    {
        public static void SaveToJson(in string filePath, in string fileName, in object jsonClassData)
        {
            FileStream fileStream = new FileStream(string.Format("{0}/{1}", filePath, fileName), FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(UnityEngine.JsonUtility.ToJson(jsonClassData));

            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }
        public static T LoadjsonFile<T>(in string filePath, in string fileName)
        {
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", filePath, fileName), FileMode.Open);
            byte[] data = new byte[fileStream.Length];

            fileStream.Read(data, 0, data.Length);
            fileStream.Close();
            string jsonData = Encoding.UTF8.GetString(data);

            return JsonUtility.FromJson<T>(jsonData);
        }

        public static void writeStringToFile(string str, string filename)
        {
#if !WEB_BUILD
            string path = pathForDocumentsFile(filename);
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(str);

            sw.Close();
            file.Close();
#endif 
        }
        public static string readStringFromFile(string filename)
        {
#if !WEB_BUILD
            string path = pathForDocumentsFile(filename);

            if (File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                string str = null;
                str = sr.ReadLine();

                sr.Close();
                file.Close();

                return str;
            }
            else
            {
                return null;
            }
#else
        return null;
#endif
        }
        public static string pathForDocumentsFile(string filename)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(Path.Combine(path, "Documents"), filename);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                string path = Application.persistentDataPath;
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(path, filename);
            }
            else
            {
                string path = Application.dataPath;
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(path, filename);
            }
        }
        public static string pathForDocumentsFile(string filename, string folderpath)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(Path.Combine(Path.Combine(path, "Documents"), folderpath), filename);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                string path = Application.persistentDataPath;
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(Path.Combine(path, folderpath), filename);
            }
            else
            {
                string path = Application.dataPath;
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(Path.Combine(path, folderpath), filename);
            }
        }
        public static string pathForDocumentsFolder(string folderPath)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(Path.Combine(path, "Documents"), folderPath);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                string path = Application.persistentDataPath;
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(path, folderPath);
            }
            else
            {
                string path = Application.dataPath;
                path = path.Substring(0, path.LastIndexOf('/'));
                return Path.Combine(path, folderPath);
            }
        }
    }
}
