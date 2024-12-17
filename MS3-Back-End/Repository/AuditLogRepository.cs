﻿using Microsoft.EntityFrameworkCore;
using MS3_Back_End.DBContext;
using MS3_Back_End.Entities;
using MS3_Back_End.IRepository;

namespace MS3_Back_End.Repository
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AppDBContext _dbContext;

        public AuditLogRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<AuditLog> AddAuditLog(AuditLog auditLog)
        {
            var data = await _dbContext.AuditLogs.AddAsync(auditLog);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }   
        public async Task<ICollection<AuditLog>> GetAllAuditlogs()
        {
            var data= await _dbContext.AuditLogs.Include(a => a.Admin).ToListAsync();
            return data;
        }
        public async Task<ICollection<AuditLog>> GetAuditLogsbyAdminId(Guid id)
        {
            var data= await _dbContext.AuditLogs.Include(a => a.Admin).Where(a=>a.AdminId == id).ToListAsync();
            return data;
        }

        public async Task<AuditLog> GetAuditLogByID(Guid id)
        {
            var data=await _dbContext.AuditLogs.Include(a => a.Admin).SingleOrDefaultAsync(a=> a.Id == id);
            return data!;
        }
    }
}
