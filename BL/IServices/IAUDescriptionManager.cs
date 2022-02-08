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
    public interface IAUDescriptionManager : IService<AUDescriptionCreateDto, AUDescriptionUpdateDto, AUDescriptionListDto, ObjAUDescription>
    {
        Task<IResponse<List<AUDescriptionListDto>>> GetActiveAsync();
        //Task<IResponse<AUDescriptionCreateDto>> CreateWithAboutUsAsync(AUDescriptionCreateDto dto, int aboutUsId);
    }
}
