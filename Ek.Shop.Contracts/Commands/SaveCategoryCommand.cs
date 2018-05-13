using Ek.Shop.Application.Classifiers;
using Ek.Shop.Domain.Categories;

namespace Ek.Shop.Contracts.Commands
{
    public class SaveCategoryCommand : ICommand
    {
        public SaveCategoryCommand()
        { }

        public SaveCategoryCommand(SaveCategoryDto saveCategory, int languageId)
        {
            SaveCategory = saveCategory;
            LanguageId = languageId;
        }

        public int LanguageId { get; set; }

        public SaveCategoryDto SaveCategory { get; set; }
    }

    public class SaveCategoryQueryCommand : ICommand
    {
        public SaveCategoryQueryCommand()
        { }

        public SaveCategoryQueryCommand(Category saveCategory)
        {
            Category = saveCategory;
        }

        public Category Category { get; set; }
    }
}
