﻿using MS3_Back_End.DTOs.RequestDTOs.Address;
using MS3_Back_End.DTOs.ResponseDTOs.Address;
using MS3_Back_End.Entities;
using MS3_Back_End.IRepository;
using MS3_Back_End.IService;

namespace MS3_Back_End.Service
{
    public class AddressServise: IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressServise(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressResponseDTO> AddAddress(AddressRequestDTO address)
        {
            var Address=new Address()
            {
                AddressLine1=address.AddressLine1,
                AddressLine2=address.AddressLine2,
                City=address.City,
                PostalCode=address.PostalCode,
                Country=address.Country,
                StudentId=address.StudentId,
            };
           
            var data=await _addressRepository.AddAddress(Address);

            var Returndata = new AddressResponseDTO()
            {
                StudentId = address.StudentId,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                PostalCode = address.PostalCode,
                Country = address.Country,
            };

            return Returndata;

        }

        public async Task<AddressResponseDTO> UpdateAddress(Guid id,AddressUpdateRequestDTO Updateaddress)
        {
            var address= await _addressRepository.GetAddressByID(id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }
            address.AddressLine1 = Updateaddress.AddressLine1;
            address.AddressLine2 = Updateaddress.AddressLine2;
            address.City = Updateaddress.City;
            address.Country = Updateaddress.Country;
            address.PostalCode = Updateaddress.PostalCode;

            var data = await _addressRepository.UpdateAddress(address);
            var returndata = new AddressResponseDTO()
            {
                AddressLine1 = data.AddressLine1,
                AddressLine2 = data.AddressLine2,
                City = data.City,
                PostalCode = data.PostalCode,
                Country = data.Country,
                StudentId = data.StudentId,
            };

            return returndata;
        }

        public async Task<AddressResponseDTO> DeleteAddress(Guid id)
        {
            var address = await _addressRepository.GetAddressByID(id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }

            var data = await _addressRepository.DeleteAddress(address);
            var Returndata = new AddressResponseDTO()
            {
                AddressLine1 = data.AddressLine1,
                AddressLine2 = data.AddressLine2,
                City = data.City,
                PostalCode = data.PostalCode,
                Country = data.Country,
                StudentId = data.StudentId,
            };
            return Returndata;

        }
    }
}
