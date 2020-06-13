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
    }
}
