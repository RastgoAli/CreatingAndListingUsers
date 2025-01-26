using CreatingAndListingUsers.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace InfraStructure.Services
{
    public class FileService
    {
        private readonly string _directoryPath;
        private readonly string _fileName;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public FileService(string directoryPath = "Data", string fileName = "list.json")
        {
            _directoryPath = directoryPath;
            _fileName = Path.Combine(_directoryPath, fileName);
            _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        }

        public void SaveListToFile(List<UserEntity> list)
        {
            try
            {
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }
                var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
                File.WriteAllText(_fileName, json);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        
        public List<UserEntity> GetAllUsers()
        {
            try
            {
                if (!File.Exists(_fileName))
                {
                    return [];
                }
                var json = File.ReadAllText(_fileName);
                var list = JsonSerializer.Deserialize<List<UserEntity>>(json, _jsonSerializerOptions);
                return list ?? [];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return [];
            }
        }
        
    }

}
