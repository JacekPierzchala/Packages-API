using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Infrastructure;

namespace Zadanie2.Application
{
    public class PackageQueries : IPackageQueries
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;
        private readonly IBarCodeService _barCodeService;

        public PackageQueries(IPackageRepository packageRepository, IMapper mapper, IBarCodeService barCodeService)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
            _barCodeService = barCodeService;
        }

        public async Task<bool> Exists(int id)
        {
            return await _packageRepository.Exists(id);
        }

        public async Task<string> GetBarcodePackageById(int id)
        {
            var resultFromDb = (await _packageRepository.GetPackage(id)).PackageIdentifier;
            var barCode= _barCodeService.GenerateBarCode(resultFromDb);
            return barCode;
        }

        public async Task<DetailsPackageDTO> GetPackage(int id)
        {
            var resultFromDb = await _packageRepository.GetPackage(id);
            return _mapper.Map<DetailsPackageDTO>(resultFromDb);
        }

        public async Task<IEnumerable<GetListPackageDTO>> GetPackages(QueryParameters queryParameters)
        {
            if(queryParameters.Status.ToLower()!=Statics.DELIVERED.ToLower())
            {
                queryParameters.Status = string.Empty;
            }
            var resultFromDb= await _packageRepository.GetAll(queryParameters);
            return  _mapper.Map<IEnumerable<GetListPackageDTO>>(resultFromDb);

        }
    }
}
