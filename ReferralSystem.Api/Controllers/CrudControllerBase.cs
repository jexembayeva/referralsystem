using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Database.Repositories.Base;
using Utils.Interfaces;

namespace ReferralSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudControllerBase<T> : ControllerBase
        where T : class, IBaseModel
    {
        private readonly IRepository<T> _repository;

        public CrudControllerBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<T> GetByIdAsync([FromRoute] long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync(T entity)
        {
            await _repository.InsertAsync(entity);
            return Ok();
        }

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}