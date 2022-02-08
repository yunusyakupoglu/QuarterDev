using Common;
using DTOs;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.IServices
{
    public interface IQuarterCategoryTitleManager : IService<QuarterCategoryTitleCreateDto, QuarterCategoryTitleUpdateDto, QuarterCategoryTitleListDto, ObjQuarterCategoryTitle>
    {
        Task<IResponse<List<QuarterCategoryTitleListDto>>> GetActiveAsync();
    }
}
