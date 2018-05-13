using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Products;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Products
{
    public class EditProductQueryHandler : QueryHandler<EditProductCommand, EditProductDataDto>
    {
        private readonly IQueryHandler<GetProductCommand, ProductDto> _getProductQueryHandler;
        private readonly IQueryHandler<ListCategoriesCommand, PagedList<CategoryDto>> _listCategoriesQueryHandler;
        private readonly IQueryHandler<ListAngularComponentsCommand, List<AngularComponentDto>> _listAngularComponentsQueryHandler;

        public EditProductQueryHandler(IQueryHandler<GetProductCommand, ProductDto> getProductQueryHandler,
            IQueryHandler<ListCategoriesCommand, PagedList<CategoryDto>> listCategoriesQueryHandler,
            IQueryHandler<ListAngularComponentsCommand, List<AngularComponentDto>> listAngularComponentsQueryHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _listCategoriesQueryHandler = listCategoriesQueryHandler;
            _listAngularComponentsQueryHandler = listAngularComponentsQueryHandler;
        }

        public override async Task<ActionResult<EditProductDataDto>> Handle(EditProductCommand command)
        {
            var productDtoResult = await _getProductQueryHandler.Handle(new GetProductCommand(command.ProductId, command.LanguageId));
            if (productDtoResult.Failure && command.ProductId > 0)
            {
                return Error(productDtoResult.ErrorMessages);
            }

            var pagedCategoriesDtoResult = await _listCategoriesQueryHandler.Handle(new ListCategoriesCommand(2, command.LanguageId, true));
            if (pagedCategoriesDtoResult.Failure)
            {
                return Error(pagedCategoriesDtoResult.ErrorMessages);
            }

            var angularComponentsDtoResult = await _listAngularComponentsQueryHandler.Handle(new ListAngularComponentsCommand());
            if (angularComponentsDtoResult.Failure)
            {
                return Error(angularComponentsDtoResult.ErrorMessages);
            }

            var productDto = productDtoResult.Object ?? new ProductDto();
            var categoriesDto = pagedCategoriesDtoResult.Object;
            var angularComponentsDto = angularComponentsDtoResult.Object;

            var editProductDataDto = new EditProductDataDto();
            editProductDataDto.Product = productDto;
            editProductDataDto.AngularComponents = angularComponentsDto;
            editProductDataDto.Categories = categoriesDto.Items.Select(o => new CategoryClassifierDto()
            {
                Text = o.Characteristics.GetValue(CharacteristicCodes.Name),
                Value = o.Id
            }).ToList();

            return Ok(editProductDataDto);
        }
    }
}
