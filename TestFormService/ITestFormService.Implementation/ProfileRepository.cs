using System.Collections.Generic;
using System.IO;
using System;
using Newtonsoft.Json;
using TestFormService.Contract;

namespace TestFormService.Implementation
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly List<Profile> _repository;
        private readonly string _filePath;
        public ProfileRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            _filePath = filePath;
            _repository = new List<Profile>();
        }

        public void Save(Profile profile)
        {
            if (!File.Exists(_fileName)) { File.CreateText(_filePath).Close(); };

            _repository.Add(profile);
            System.IO.File.WriteAllText(_filePath, JsonConvert.SerializeObject(_repository));
        }
    }
}
