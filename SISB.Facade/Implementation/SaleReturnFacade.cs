using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class SaleReturnFacade : ISaleReturnFacade
    {
        private readonly ISaleReturnRepository _saleReturnRepository;

        public SaleReturnFacade(ISaleReturnRepository saleReturnRepository)
        {
            _saleReturnRepository = saleReturnRepository;
        }

        public async Task<List<SaleReturn>> GetSaleReturnsAsync()
        {
            return await _saleReturnRepository.GetAllAsync();
        }

        public async Task<SaleReturn?> GetSaleReturnByIdAsync(int id)
        {
            return await _saleReturnRepository.GetByIdAsync(id);
        }

        public async Task AddSaleReturnAsync(SaleReturn saleReturn)
        {
            ArgumentNullException.ThrowIfNull(saleReturn);
            await _saleReturnRepository.AddAsync(saleReturn);
        }

        public async Task<bool> UpdateSaleReturnAsync(SaleReturn saleReturn)
        {
            ArgumentNullException.ThrowIfNull(saleReturn);

            var existing = await _saleReturnRepository.GetByIdAsync(saleReturn.SaleReturnId);
            if (existing == null)
                return false;

            await _saleReturnRepository.UpdateAsync(saleReturn);
            return true;
        }

        public async Task<bool> DeleteSaleReturnAsync(int id)
        {
            var existing = await _saleReturnRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _saleReturnRepository.DeleteAsync(id);
            return true;
        }
    }
}
