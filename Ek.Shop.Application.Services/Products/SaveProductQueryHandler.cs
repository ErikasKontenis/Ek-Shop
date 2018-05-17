using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.InputForms;
using Ek.Shop.Application.Products;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Data.ClassifierStores;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.Phrases;
using Ek.Shop.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.Products
{
    public class SaveProductQueryHandler : QueryHandler<SaveProductCommand, ProductDto>
    {
        private readonly IQueryHandler<GetInputFormCommand, InputFormDto> _getInputFormQueryHandler;
        private readonly IQueryHandler<GetCategoryByUrlCommand, CategoryDto> _getCategoryByUrlQueryHandler;
        private readonly IRemoteQuery<GetProductCommand, Product> _getProductQuery;
        private readonly IRemoteQuery<ListCharacteristicsCommand, List<Characteristic>> _listCharacteristicsQuery;
        private readonly IRemoteQuery<GetPhraseByValueCommand, Phrase> _getPhraseByValueQuery;
        private readonly IRemoteQuery<SaveProductQueryCommand, Product> _saveProductQuery;
        private readonly IClassifierStoresRepository _classifierStoresRepository;

        private IMapper _mapper => AutoMapperFactory
            .CreateMapper<ProductMapperProfile, ImageMapperProfile>();

        public SaveProductQueryHandler(IQueryHandler<GetInputFormCommand, InputFormDto> getInputFormQueryHandler,
            IQueryHandler<GetCategoryByUrlCommand, CategoryDto> getCategoryByUrlQueryHandler,
            IRemoteQuery<GetProductCommand, Product> getProductQuery,
            IRemoteQuery<ListCharacteristicsCommand, List<Characteristic>> listCharacteristicsQuery,
            IRemoteQuery<GetPhraseByValueCommand, Phrase> getPhraseByValueQuery,
            IRemoteQuery<SaveProductQueryCommand, Product> saveProductQuery,
            IClassifierStoresRepository classifierStoresRepository)
        {
            _getInputFormQueryHandler = getInputFormQueryHandler;
            _getCategoryByUrlQueryHandler = getCategoryByUrlQueryHandler;
            _getProductQuery = getProductQuery;
            _listCharacteristicsQuery = listCharacteristicsQuery;
            _getPhraseByValueQuery = getPhraseByValueQuery;
            _saveProductQuery = saveProductQuery;
            _classifierStoresRepository = classifierStoresRepository;
        }

        public override async Task<ActionResult<ProductDto>> Handle(SaveProductCommand command)
        {
            var saveProductDtoResult = await _getCategoryByUrlQueryHandler.Handle(new GetCategoryByUrlCommand(command.SaveProduct.RouteUrl, command.LanguageId));
            if (saveProductDtoResult.Failure)
            {
                return Error(saveProductDtoResult.ErrorMessages);
            }

            var saveProductDto = saveProductDtoResult.Object;
            var detailErrors = saveProductDto.Fieldsets.MapToFields(command.SaveProduct.Product).ValidateFieldsets();
            if (!detailErrors.IsNullOrEmpty())
            {
                return Error(detailErrors);
            }

            var classifierStore = await _classifierStoresRepository.Get();
            var availableCharacteristics = await _listCharacteristicsQuery.Query(new ListCharacteristicsCommand());
            var product = await _getProductQuery.Query(new GetProductCommand(command.SaveProduct.Product.Id, command.LanguageId)
            {
                IsFromCache = false
            }) ?? new Product();
            var productDto = command.SaveProduct.Product;

            _mapper.Map(productDto, product);

            product.Route.AngularComponentId = classifierStore.AngularComponents.First(o => o.Code == productDto.AngularComponentCode).Id;

            product.Images.MergeImages(availableCharacteristics, productDto.Images);
            product.Characteristics.MergeCharacteristics(availableCharacteristics, productDto.Characteristics);

            product = await BeforeProductSave(product);
            await _saveProductQuery.Query(new SaveProductQueryCommand(product));

            return Ok(productDto);
        }

        private async Task<Product> BeforeProductSave(Product item)
        {
            if (item.Route.InputFormId == 0)
            {
                var commonInputForm = (await _getInputFormQueryHandler.Handle(new GetInputFormCommand(InputFormCodes.CommonInputForm))).Object;
                item.Route.InputFormId = commonInputForm.Id;
            }

            return item;
        }
    }
}
