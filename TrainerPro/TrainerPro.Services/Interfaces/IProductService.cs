using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;

namespace TrainerPro.Services.Interfaces
{
    public interface IProductService
    {
        Task<AddProductDTO> AddProductAsync(AddProductDTO model);
        Task<IEnumerable<GetProductDTO>> GetProductsAsync();
        Task<AddProductDTO> GetProductByIdAsync(int id);
        Task<AddProductDTO> UpdateProductAsync(AddProductDTO model);
        Task DeleteProductByIdAsync(int id);
    }
}
