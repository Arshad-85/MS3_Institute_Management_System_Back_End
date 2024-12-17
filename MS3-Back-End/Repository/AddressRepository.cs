﻿using Microsoft.EntityFrameworkCore;
using MS3_Back_End.Controllers;
using MS3_Back_End.DBContext;
using MS3_Back_End.Entities;
using MS3_Back_End.IRepository;
using System.Runtime.InteropServices;

namespace MS3_Back_End.Repository
{
    public class AddressRepository: IAddressRepository
    {
        private readonly AppDBContext _dbContext;

        public AddressRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Address> AddAddress(Address address) 
        {
            var Address =await _dbContext.Addresses.SingleOrDefaultAsync(f=>f.StudentId == address.StudentId);
            if (Address == null)
            {
                var data = await _dbContext.Addresses.AddAsync(address);
                await _dbContext.SaveChangesAsync();
                return data.Entity;

            }
            else 
            {
                throw new Exception("Address Already Added");
            }
        }
        public async Task<Address> GetAddressByID(Guid id)
        {
            var Address = await _dbContext.Addresses.SingleOrDefaultAsync(f => f.Id == id);
            return Address!;
        }
        public async Task<Address> DeleteAddress(Address address)
        {
            var data=  _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var data=  _dbContext.Addresses.Update(address);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }
    }
}
