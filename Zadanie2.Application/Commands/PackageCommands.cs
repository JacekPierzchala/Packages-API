using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;
using Zadanie2.Infrastructure;

namespace Zadanie2.Application
{
    public class PackageCommands : IPackageCommands
    {
        private readonly IMapper _mapper;
        private readonly IPackageRepository _packageRepository;

        public PackageCommands(IMapper mapper, IPackageRepository packageRepository)
        {
            _mapper = mapper;
            _packageRepository = packageRepository;
        }
        public async Task AddPackageCommand(AddPackageDTO addPackageDTO)
        {
            var entityToBeAdded = _mapper.Map<Package>(addPackageDTO);
            entityToBeAdded.Status = Statics.RECEIVED;
            entityToBeAdded.LastUpdated=DateTime.Now;
            entityToBeAdded.PackageIdentifier=Guid.NewGuid().ToString();
            await _packageRepository.AddAsync(entityToBeAdded);
        }

        public async Task EditPackageCommand(EditPackageDTO editPackageDTO)
        {
            var entityToBeUpdated = _mapper.Map<Package>(editPackageDTO);
            entityToBeUpdated.LastUpdated = DateTime.Now;
            await _packageRepository.UpdatePackageAsync(entityToBeUpdated);
        }
    }
}
