using BlazorServerShoppingCart.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _appDbContext;

        public StateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<State> AddState(State newState)
        {
            var state = await _appDbContext.States.AddAsync(newState);
            await _appDbContext.SaveChangesAsync();
            return state.Entity;
        }

        public async Task<State> DeleteState(string stateCode)
        {
            var state = await _appDbContext.States.FirstOrDefaultAsync(s => s.StateCode == stateCode);
            if (state != null)
            {
                _appDbContext.States.Remove(state);
                await _appDbContext.SaveChangesAsync();
                return state;
            }
            return null;
        }

        public async Task<IList<State>> GetAllStates()
        {
            return await _appDbContext.States.ToListAsync();
        }

        public async Task<State> GetState(string stateCode)
        {
            return await _appDbContext.States.FirstOrDefaultAsync(s => s.StateCode == stateCode);
        }

        public async Task<State> UpdateState(State updatedState)
        {
            var state = await _appDbContext.States.FirstOrDefaultAsync(s => s.StateCode == updatedState.StateCode);
            if (state != null)
            {
                state.StateCode = updatedState.StateName;

                await _appDbContext.SaveChangesAsync();
                return state;
            }
            return null;
        }
    }
}
