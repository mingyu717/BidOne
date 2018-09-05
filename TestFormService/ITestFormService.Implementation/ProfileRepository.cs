using System.Collections.Generic;
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
            _filePath = filePath;
            _repository = new List<Profile>();
        }

        public void Save(Profile profile)
        {
            _repository.Add(profile);
            System.IO.File.WriteAllText(_filePath, JsonConvert.SerializeObject(_repository));
        }
    }
}
