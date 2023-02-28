using AutoMapper;
using BackEndAPI.Models;
using BackEndAPI.Views;

namespace BackEndAPI.Mapper
{
    public class DomainProfile: Profile
    {
        public DomainProfile() 
        {
        CreateMap<Case,CasesVM>();
        CreateMap<CasesVM, Case>();
        CreateMap<CasePayment,CasePaymentVM>();
        CreateMap<CasePaymentVM, CasePayment>();
        CreateMap<UserVM, User>();
        CreateMap<User, UserVM>();
        CreateMap<UserType, UserTypeVM>();
        CreateMap<UserTypeVM, UserType>();
        CreateMap<Charity, CharityVM>();
        CreateMap<CharityVM, Charity>();


        }
    }
}
