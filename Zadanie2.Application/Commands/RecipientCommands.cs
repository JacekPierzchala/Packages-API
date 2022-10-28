using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;
using Zadanie2.Infrastructure;

namespace Zadanie2.Application
{
    public class RecipientCommands : IRecipientCommands
    {
        private readonly IRecipientRepository _recipientRepository;
        private readonly IMapper _mapper;

        public RecipientCommands(IRecipientRepository recipientRepository, IMapper mapper)
        {
            _recipientRepository = recipientRepository;
            _mapper = mapper;
        }

        public async Task AddRecipientCommand(AddRecipientDTO addRecipientDTO)
        {
           var entityToBeAdded = _mapper.Map<Recipient>(addRecipientDTO);
           await _recipientRepository.AddAsync(entityToBeAdded);
        }

        public async Task EditRecipientCommand(EditRecipientDTO editRecipientDTO)
        {
            var entityToBeUpdated = _mapper.Map<Recipient>(editRecipientDTO);
            await _recipientRepository.UpdateRecipientAsync(entityToBeUpdated);
        }
    }
   

}
