using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class SaleFacade : ISaleFacade
    {
        private readonly ISaleRepository _saleRepository;

        public SaleFacade(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> GetSalesAsync()
        {
            return await _saleRepository.GetAllAsync();
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetByIdAsync(id);
        }

        public async Task AddSaleAsync(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);
            await _saleRepository.AddAsync(sale);
        }

        public async Task<bool> UpdateSaleAsync(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);

            var existing = await _saleRepository.GetByIdAsync(sale.SaleId);
            if (existing == null)
                return false;

            await _saleRepository.UpdateAsync(sale);
            return true;
        }

        public async Task<bool> DeleteSaleAsync(int id)
        {
            var existing = await _saleRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _saleRepository.DeleteAsync(id);
            return true;
        }
    }
}
