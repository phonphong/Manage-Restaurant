using System.Collections.Generic;
using System.Threading.Tasks;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service
{
    public interface ITableService
    {
        Task<List<Table>> GetAllTablesAsync(); 
        Task<Table> GetTableByIdAsync(int id); 
        Task<Table> CreateTableAsync(Table table); 
        Task<Table> UpdateTableAsync(Table table); 
        Task<bool> DeleteTableAsync(int id);
    }
}
