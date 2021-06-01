using KLoveCoding.Enums;
using KLoveCoding.Extensions;
using KLoveCoding.Service.Dtos;
using KLoveCoding.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KLoveCoding.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        public async Task<IActionResult> Index()
        {
            List<FavoriteDto> favoriteDtoList = await _favoriteService.GetAll();

            return View(favoriteDtoList);
        }

        [HttpPost]
        public async Task<JsonResult> Create(string imageLink, string verseText, string verseApiId)
        {
            FavoriteActionDto favoriteActionDto = new FavoriteActionDto();

            favoriteActionDto.IsActive = true;
            favoriteActionDto.ImageLink = imageLink;
            favoriteActionDto.VerseText = verseText;
            favoriteActionDto.VerseApiId = verseApiId;
                        
            var errors = await _favoriteService.Validate(favoriteActionDto, true, null);
            ModelStateDictionaryExtension.Merge(ModelState, errors);

            if (ModelState.IsValid)
            {
                try
                {
                    await _favoriteService.Create(favoriteActionDto);
                    var result = new { Status = HttpCustomStatusCode.SUCCESS.ToString(), Message = "" };
                    return Json(result);
                }
                catch (Exception e)
                {
                    var result = new { Status = HttpCustomStatusCode.ERROR.ToString(), Message = e.Message };
                    return Json(result);
                    //return GetExceptionErrorForJsonReturn(e);
                }
            }
            else
            {
                return Json(new { Status = HttpCustomStatusCode.ERROR, Success = "False", responseText = "AHHHH" });
            }
        }
    }
}
