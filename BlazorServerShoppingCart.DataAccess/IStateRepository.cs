using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public interface IStateRepository
    {
        Task<IList<State>> GetAllStates();
        Task<State> GetState(string stateCode);
        Task<State> AddState(State newState);
        Task<State> UpdateState(State updatedState);
        Task<State> DeleteState(string stateCode);
    }
}
