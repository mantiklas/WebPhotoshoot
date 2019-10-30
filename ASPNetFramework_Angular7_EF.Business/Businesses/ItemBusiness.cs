using ASPNetFramework_Angular7_EF.Business.Core;
using ASPNetFramework_Angular7_EF.Business.Dtos;
using ASPNetFramework_Angular7_EF.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetFramework_Angular7_EF.Business.Businesses
{
    public class ItemBusiness : IItemBusiness
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork unitOfWork;

        public ItemBusiness(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this._itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
        }

        public void DeleteItem(int id)
        {
            var item = this._itemRepository.Get(id);
            this._itemRepository.Remove(item);
            this.unitOfWork.Complete();
        }

        public IEnumerable<ItemDto> GetAllItems()
        {
           return AutoMapper.Mapper.Map<IEnumerable<ItemDto>>(this._itemRepository.GetAll());
        }
    }
}
