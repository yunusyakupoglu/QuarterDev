using Common;
using DTOs;
using Microsoft.AspNetCore.Http;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.IServices
{
	public interface IProjectManager : IService<ProjectCreateDto,ProjectUpdateDto,ProjectListDto,ObjProject>
	{
		Task<IResponse<List<ProjectListDto>>> GetActiveAsync();
		string UploadImage(IFormFile formFile);
		string DeleteImage(string filename);
	}
}
