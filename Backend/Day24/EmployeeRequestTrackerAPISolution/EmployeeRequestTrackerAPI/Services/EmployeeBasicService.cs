﻿using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeBasicService : IEmployeeService
    {

        private readonly IRepository<int, Employee> _repository;

        public EmployeeBasicService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoSuchEmployeeException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoEmployeeFoundException();
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new NoSuchEmployeeException();
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;

        }

    }
}
