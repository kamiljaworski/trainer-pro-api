using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Core.Entities;
using TrainerPro.DAL;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly TrainerProContext _dbContext;

        public ProductService(TrainerProContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddProductDTO> AddProductAsync(AddProductDTO model)
        {
            var productExists = await _dbContext.Products.AnyAsync(c => c.Name == model.Name);
            if (productExists)
                throw new InvalidOperationException("This product already exist.");

            if(isGramCorrect(model.CarbsPer100g, model.FatPer100g, model.ProteinPer100g))
            {
                var newProduct = new Product
                {
                    Name = model.Name,
                    CarbsPer100g = model.CarbsPer100g,
                    FatPer100g = model.FatPer100g,
                    ProteinPer100g = model.ProteinPer100g,
                    KcalPer100g = totalKcal(model.CarbsPer100g, model.FatPer100g, model.ProteinPer100g)
                };

                _dbContext.Products.Add(newProduct);
                await _dbContext.SaveChangesAsync();

                return GetProductDTOFromProductEntity(newProduct);
            }

            throw new InvalidOperationException("Total amount of macros not equals 100");
        }

        public async Task<IEnumerable<GetProductDTO>> GetProductsAsync()
        {
            var products = await _dbContext.Products
                .Select(p => new GetProductDTO
                {
                    Id = p.ProductId,
                    Name = p.Name,
                    CarbsPer100g = p.CarbsPer100g,
                    FatPer100g = p.FatPer100g,
                    ProteinPer100g = p.ProteinPer100g,
                    KcalPer100g = p.KcalPer100g
                }).ToListAsync();

            return products;
        }

        public async Task<AddProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                throw new InvalidOperationException("This product doesn't exist.");

            return GetProductDTOFromProductEntity(product);
        }

        public async Task<AddProductDTO> UpdateProductAsync(AddProductDTO model)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(c => c.Name == model.Name);

            if (product == null)
                throw new InvalidOperationException("This product doesn't exist.");

            if(isGramCorrect(model.CarbsPer100g, model.FatPer100g, model.ProteinPer100g))
            {
                product.Name = model.Name;
                product.CarbsPer100g = model.CarbsPer100g;
                product.FatPer100g = model.FatPer100g;
                product.ProteinPer100g = model.ProteinPer100g;
                product.KcalPer100g = totalKcal(model.CarbsPer100g, model.FatPer100g, model.ProteinPer100g);

                await _dbContext.SaveChangesAsync();

                return GetProductDTOFromProductEntity(product);
            }

            throw new InvalidOperationException("Total amount of macros not equals 100");
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(c => c.ProductId == id);

            if (product == null)
                throw new InvalidOperationException("This product doesn't exist.");

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        private AddProductDTO GetProductDTOFromProductEntity(Product product)
        {
            return new AddProductDTO
            {
                Name = product.Name,
                CarbsPer100g = product.CarbsPer100g,
                FatPer100g = product.FatPer100g,
                ProteinPer100g = product.ProteinPer100g,
                KcalPer100g = product.KcalPer100g
            };
        }

        public bool isGramCorrect(double carbs, double fat, double protein)
        {
            if(carbs + fat + protein == 100)
            return true;

            return false;
        }

        public double totalKcal(double carbs, double fat, double protein)
        {
            var totalKcal = (carbs * 4) + (fat + 9) + (protein * 4);

            return totalKcal;
        }
    }
}
