﻿using Employee_Management_Api.Data;
using Employee_Management_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Api.Repositories
{
    public class EmpolyeeRepository : IEmpolyeeRepository
    {
        private readonly AppDbContext _context;
        public EmpolyeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteEmployeeAsync(int id)
        {
          var employeeInDb=await _context.Employees.FindAsync(id);
            if (employeeInDb == null) {
                throw new KeyNotFoundException($"Employee with id {id} was not found. ");
            }
            _context.Employees.Remove(employeeInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

        }
    }
}
