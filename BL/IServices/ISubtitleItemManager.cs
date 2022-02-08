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
    public interface ISubtitleItemManager : IService<SubtitleItemCreateDto,SubtitleItemUpdateDto,SubtitleItemListDto,ObjSubtitleItem>
    {
        Task<IResponse<List<SubtitleItemListDto>>> GetActiveAsync();
    }
}
