using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.Images;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Languages;
using Ek.Shop.Domain.Products;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Client
{
    public static class ClientProductSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.ProductComponent).Id,
                    Title = "Bloknotai eskizams AUTHENTIC Brown A5 80 lapų",
                    Url = "bloknotai-eskizams-authentic-brown-a5-80-lapu",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Product = new Product
                    {
                        CategoryId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.NoteBooks).Id,
                        Price = 2.54M,
                        Images = new List<Image>()
                        {
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Small).Id,
                                Url = "bloknotai-eskizams-authentic-brown-a5-80-lapu-1.png"
                            },
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Big).Id,
                                Url = "bloknotai-eskizams-authentic-brown-a5-80-lapu-HD1.png"
                            },
                        },
                        Characteristics = new List<ProductCharacteristic>()
                        {
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Description).Id,
                                Translations = new List<ProductCharacteristicTranslation>()
                                {
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "<P class=MsoNormal style='MARGIN: 0cm 0cm 8pt'><SPAN style='FONT-SIZE: 12pt; BACKGROUND: white; COLOR: #333333; LINE-HEIGHT: 107%; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri; mso-ansi-language: LT'><FONT face=Calibri> <H2>Bloknotas eskizams AUTHENTIC Brown A4 80 lapų</H2></FONT></SPAN> <P></P> <P class=MsoNormal style='MARGIN: 0cm 0cm 8pt'><SPAN style='FONT-SIZE: 12pt; BACKGROUND: white; COLOR: #333333; LINE-HEIGHT: 107%; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri; mso-ansi-language: LT'><FONT face=Calibri>Bloknotas eskizams – nepamainomas pagalbininkas kuriant bet kokį meno kūrinį. Juk eskizuose dažniausiai nugula pačios gražiausios idėjos – pamirškite išmėtytus lapelius ir popierėlius ir griebkitės bloknoto, kuriame darbai niekad nepasimes ir atrodys kur kas tvarkingiau. A4 formatas idealus profesionalams, bet puikiai tiks ir mėgėjams, rimtai žiūrintiems į dailę. Bloknotas įrištas spirale ir turi mikro perforaciją – nė vienas eskizas nebus sugadintas bandant jį išplėšti. Bloknotas apsaugotas kieta nugarėle, tad jį patogu nešiotis, puslapiai nesiglamžo. Bloknotų pakuotė susidaro iš 5 vnt. – patogu perkant mokinių grupėms, meno mokykloms. </FONT></SPAN></P> <P class=MsoNormal style='MARGIN: 0cm 0cm 8pt'><SPAN style='FONT-SIZE: 12pt; BACKGROUND: white; COLOR: #333333; LINE-HEIGHT: 107%; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri; mso-ansi-language: LT'><FONT face=Calibri><STRONG>Trumpa bloknoto&nbsp;specifikacija:<?xml:namespace prefix = 'o' ns = 'urn:schemas-microsoft-com:office:office' /><o:p></o:p></STRONG></FONT></SPAN></P> <P class=MsoListParagraphCxSpFirst style='MARGIN: 0cm 0cm 0pt 36pt; TEXT-INDENT: -18pt; mso-list: l0 level1 lfo1'><SPAN style='FONT-SIZE: 12pt; FONT-FAMILY: Symbol; LINE-HEIGHT: 107%; mso-ansi-language: LT; mso-fareast-font-family: Symbol; mso-bidi-font-family: Symbol'><SPAN style='mso-list: Ignore'>·<SPAN style='FONT: 7pt 'Times New Roman''>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></SPAN></SPAN><FONT face=Calibri><SPAN style='FONT-SIZE: 12pt; BACKGROUND: white; COLOR: #333333; LINE-HEIGHT: 107%; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri; mso-ansi-language: LT'>A4, 135 gsm, 80 lapų (rudo kraftinio popieriaus) </SPAN><SPAN style='FONT-SIZE: 12pt; LINE-HEIGHT: 107%; mso-ansi-language: LT'><o:p></o:p></SPAN></FONT></P> <P class=MsoListParagraphCxSpMiddle style='MARGIN: 0cm 0cm 0pt 36pt; TEXT-INDENT: -18pt; mso-list: l0 level1 lfo1'><SPAN style='FONT-SIZE: 12pt; FONT-FAMILY: Symbol; LINE-HEIGHT: 107%; mso-ansi-language: LT; mso-fareast-font-family: Symbol; mso-bidi-font-family: Symbol'><SPAN style='mso-list: Ignore'>·<SPAN style='FONT: 7pt 'Times New Roman''>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></SPAN></SPAN><FONT face=Calibri><SPAN style='FONT-SIZE: 12pt; BACKGROUND: white; COLOR: #333333; LINE-HEIGHT: 107%; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri; mso-ansi-language: LT'>su mikro perforacija</SPAN><SPAN style='FONT-SIZE: 12pt; LINE-HEIGHT: 107%; mso-ansi-language: LT'><o:p></o:p></SPAN></FONT></P> <P class=MsoListParagraphCxSpLast style='MARGIN: 0cm 0cm 8pt 36pt; TEXT-INDENT: -18pt; mso-list: l0 level1 lfo1'><SPAN style='FONT-SIZE: 12pt; FONT-FAMILY: Symbol; LINE-HEIGHT: 107%; mso-ansi-language: LT; mso-fareast-font-family: Symbol; mso-bidi-font-family: Symbol'><SPAN style='mso-list: Ignore'>·<SPAN style='FONT: 7pt 'Times New Roman''>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN></SPAN></SPAN><SPAN style='FONT-SIZE: 12pt; BACKGROUND: white; COLOR: #333333; LINE-HEIGHT: 107%; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri; mso-ansi-language: LT'><FONT face=Calibri>kieta nugarėlė, trumpa spiralė viršuje</FONT></SPAN><SPAN style='FONT-SIZE: 12pt; LINE-HEIGHT: 107%; mso-ansi-language: LT'><o:p></o:p></SPAN></P>"
                                    }
                                }
                            },
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Translations = new List<ProductCharacteristicTranslation>()
                                {
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "Bloknotai eskizams AUTHENTIC Brown A5 80 lapų"
                                    },
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                        Value = "Notebook AUTHENTIC Brown A5 80 pages"
                                    }
                                }
                            },
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsShowHomePage).Id,
                                Value = "true"
                            },
                        }
                    }
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.ProductComponent).Id,
                    Title = "Bloknotas Kreska A7 50 lapų langeliais",
                    Url = "bloknotas-kreska-a7-50-lapu-langeliais",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Product = new Product
                    {
                        CategoryId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.NoteBooks).Id,
                        Price = 0.58M,
                        Images = new List<Image>()
                        {
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Small).Id,
                                Url = "bloknotas-kreska-a7-50-lapu-langeliais-1.png"
                            },
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Big).Id,
                                Url = "bloknotas-kreska-a7-50-lapu-langeliais-HD1.png"
                            },
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Small).Id,
                                Url = "bloknotas-kreska-a7-50-lapu-langeliais-2.png"
                            },
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Big).Id,
                                Url = "bloknotas-kreska-a7-50-lapu-langeliais-HD2.png"
                            },
                        },
                        ProductDetails = new List<ProductDetail>()
                        {
                            new ProductDetail
                            {
                                ProductDetailTypeId = dbContext.Set<ProductDetailType>().FirstOrDefault(o => o.Code == ProductDetailTypes.ColorId).Id,
                                Value = "#9c6baf",
                                Characteristics = new List<ProductDetailCharacteristic>()
                                {
                                    new ProductDetailCharacteristic
                                    {
                                        CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                        Translations = new List<ProductDetailCharacteristicTranslation>()
                                        {
                                            new ProductDetailCharacteristicTranslation()
                                            {
                                                LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                                Value = "Purpurinis"
                                            },
                                            new ProductDetailCharacteristicTranslation()
                                            {
                                                LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                                Value = "Purple"
                                            }
                                        }
                                    },
                                }
                            },
                            new ProductDetail
                            {
                                ProductDetailTypeId = dbContext.Set<ProductDetailType>().FirstOrDefault(o => o.Code == ProductDetailTypes.ColorId).Id,
                                Value = "#f63294",
                                Characteristics = new List<ProductDetailCharacteristic>()
                                {
                                    new ProductDetailCharacteristic
                                    {
                                        CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                        Translations = new List<ProductDetailCharacteristicTranslation>()
                                        {
                                            new ProductDetailCharacteristicTranslation()
                                            {
                                                LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                                Value = "Rožinis"
                                            },
                                            new ProductDetailCharacteristicTranslation()
                                            {
                                                LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                                Value = "Pink"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        Characteristics = new List<ProductCharacteristic>()
                        {
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Description).Id,
                                Translations = new List<ProductCharacteristicTranslation>()
                                {
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "<P class=MsoNormal style='MARGIN: 0cm 0cm 10pt'> <H2>Bloknotas Kreska A7 50 lapų langeliais</H2> <P></P> <P class=MsoNormal style='MARGIN: 0cm 0cm 10pt'><FONT size=3><FONT face='Times New Roman'>Jeigu turite labai daug minčių arba kiekvieną dieną turite atlikti begalią darbų, kurie dažnai pasimiršta – bloknotas Kreska kiekvieną dieną turėtų būti Jūsų kišenėje! Nesvarbu, ar esate moksleivis, ar studentas, ar samdomas darbuotojas, ar verslininkas – jeigu visos Jūsų mintys bus užrašytos ant lapelio – kur kas lengviau atsiminsite kada ir ką turite padaryti.<?xml:namespace prefix = 'o' ns = 'urn:schemas-microsoft-com:office:office' /><o:p></o:p></FONT></FONT></P> <P class=MsoNormal style='MARGIN: 0cm 0cm 10pt'><FONT size=3 face='Times New Roman'>Bloknotas yra nedidelis, taigi puikiai telpa į kišenę. Įsigijus kartu ir tušinuką – kad ir kur būtumėte galėsite pasižymėti pačias gražiausias, įžvalgiausias ar reikalingiausias mintis. Svarbiausia, kad šio bloknoto kaina yra tikrai nedidelė, taigi tai gali būti ir labai puiki dovana. Jeigu turite nustebinti didelį skaičių žmonių, tačiau finansai yra riboti – padovanokite jiems vietą, kurioje gali rašyti savo puikias mintis.</FONT><o:p></o:p></P>"
                                    }
                                }
                            },
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Translations = new List<ProductCharacteristicTranslation>()
                                {
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "Bloknotas Kreska A7 50 lapų langeliais"
                                    },
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "Notebook Kreska A7 50 pages"
                                    }
                                }
                            },
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsShowHomePage).Id,
                                Value = "true"
                            },
                        }
                    }
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.ProductComponent).Id,
                    Title = "Lipnūs lapeliai 50x75mm NEON 100 lapų Yidoo",
                    Url = "lipnus-lapeliai-50x75mm-neon-100-lapu-yidoo",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Product = new Product
                    {
                        CategoryId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.StickyNotes).Id,
                        Price = 1,
                        Discount = 0.11M,
                        Images = new List<Image>()
                        {
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Small).Id,
                                Url = "lipnus-lapeliai-50x75mm-neon-100-lapu-yidoo-1.png"
                            },
                        },
                        Characteristics = new List<ProductCharacteristic>()
                        {
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Description).Id,
                                Translations = new List<ProductCharacteristicTranslation>()
                                {
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "<H2>Lipnūs lapeliai 50x75mm NEON 100 lapų Yidoo</H2> <P class=MsoNormal style='MARGIN: 0cm 0cm 10pt'><FONT size=3><FONT face='Times New Roman'>XX amžiaus antroje pusėje buvo atrasti greitai limpantys klijai, kurie ant paviršiaus nepalieka jokių žymių. Nieko keisto, kad jie labai greitai išpopuliarėjo ir tuo pačiu buvo panaudojami plačiau. Lipnūs lapeliai šiuo metu daugelio žmonių kasdienybės dalis.<?xml:namespace prefix = 'o' ns = 'urn:schemas-microsoft-com:office:office' /><o:p></o:p></FONT></FONT></P> <P class=MsoNormal style='MARGIN: 0cm 0cm 10pt'><FONT size=3><FONT face='Times New Roman'>S. Silver atrado klijus, kurie daug kartu limpa ir tuo pačiu yra lengvai nuklijuojami nuo bet kokio paviršiaus. Klijų išradėjo bendradarbis pastebėjo, kad klijai labai gelsti tuomet, kai reikia ant paviršiaus priklijuoti kokius nors popieriaus lapus (šiuo atveju tai buvo giesmynai klijuojami ant medinių laikiklių). Štai taip ir buvo sugalvoti lipnūs lapeliai.<o:p></o:p></FONT></FONT></P> <P class=MsoNormal style='MARGIN: 0cm 0cm 10pt'><FONT size=3 face='Times New Roman'>Tokia paprasta atsiradimo istorija ir toks paprastas daiktas, tačiau mes jį naudojame kiekvieną dieną.</FONT><o:p></o:p></P>"
                                    }
                                }
                            },
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Translations = new List<ProductCharacteristicTranslation>()
                                {
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "Lipnūs lapeliai 50x75mm NEON 100 lapų Yidoo"
                                    },
                                    new ProductCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "Sticky notes 50x75mm NEON 100 sheets Yidoo"
                                    }
                                }
                            },
                            new ProductCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsShowHomePage).Id,
                                Value = "true"
                            },
                        }
                    }
                },
            });
        }
    }
}
