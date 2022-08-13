using AutoMapper;
using Origin.API.DTO;
using Origin.API.Entities;

namespace Origin.API.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Card, ResponseBalanceDTO>().AfterMap<CardResponseBalanceDTO>(); //fuente - destino

            CreateMap<Operation, ResponseWithdrawDTO>().AfterMap<OperationResponseWithdrawDTO>();
        }
    }
}
