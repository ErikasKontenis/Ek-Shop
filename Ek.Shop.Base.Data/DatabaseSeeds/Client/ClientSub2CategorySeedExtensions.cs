using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.Images;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Client
{
    public static class ClientSub2CategorySeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.SubCategoryComponent).Id,
                    Title = "Popieriaus produktai",
                    Url = "popieriaus-produktai",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Parameter = DatabaseSeedCodes.PaperProducts,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Product).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Stationary).Id,
                        Images = new List<Image>()
                        {
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Small).Id,
                                Url = "popierius_ir_popieriaus_gaminiai.png"
                            },
                        },
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Popieriaus produktai",
                            },
                        }
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.TextCategoryComponent).Id,
                    Title = "Apie Mus",
                    Url = "apie-mus",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category =
                    new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Top).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Info).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Description).Id,
                                Value = "<div class='col-md-6' style='margin-left: -15px;'> <h3>Apie mus - Kanceliarinių prekių parduotuvė</h3> <img src='/Content/Uploads/Web/kanceliarineparduotuve.jpg' style='margin-bottom: 15px;' /> </div> <div class='col-md-6' style='margin-top: 15px;'> <p> <b>IĮ „Margaspalvis drugelis“</b> – kanceliarinių ir dailės prekių parduotuvė, jau 11 metų siūlanti platų prekių pasirinkimą ir geriausią kokybės bei kainos santykį. Parduotuvę įsikūrusią Mažeikiuose jau spėję pamilti klientai nuo šiol gali apsipirkti ir neišeidami iš namų – visas prekes rasite internetinėje parduotuvėje adresu <a href='/'>https://kanceliarineparduotuve.lt</a> – prekės pristatomos visoje Lietuvoje, o lojaliems klientams taikoma lanksti kainų sistema. Siekiantiems apie mus sužinoti daugiau - kviečiame paskaityti mūsų tinklaraštyje: <a href='/blog/2016/07/13/kanceliarineparduotuve-lt-kas-mes-ir-ka-mes-darome/' target='_self'>KANCELIARINEPARDUOTUVE.LT – KAS MES IR KĄ MES DAROME?</a> </p> <p> <b>Viskas ko jums gali prireikti mokykloje, biure ar dailėje – tik pas mus!</b> </p> <p> Apsilankykite parduotuvėje Mažeikiuose, Naftininkų g. 28 arba apsipirkite internetu čia: <a href='/'>internetinė kanceliarinių prekių parduotuvė</a> </p> </div>",
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Apie Mus",
                            },
                        }
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.TextCategoryComponent).Id,
                    Title = "Kontaktai",
                    Url = "kontaktai",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Top).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Info).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Kontaktai",
                            },
                        }
                    },
                },
            });
        }
    }
}
