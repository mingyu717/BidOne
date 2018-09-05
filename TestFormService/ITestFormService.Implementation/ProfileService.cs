using System;
using TestFormService.Contract;

namespace TestFormService.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
        }

        public void Save(Profile profile)
        {
            if (profile == null) throw new ArgumentNullException(nameof(profile));
            _profileRepository.Save(profile);
        }
    }
}
