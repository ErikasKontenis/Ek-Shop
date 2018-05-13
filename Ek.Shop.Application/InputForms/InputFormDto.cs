using Ek.Shop.Application.Abstractions;
using Ek.Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ek.Shop.Application.InputForms
{
    public class InputFormDto
    {
        public InputFormDto()
        {
            InputFormOptions = new List<OptionDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<OptionDto> InputFormOptions { get; set; }

        public T GetOptionValue<T>(Option<T> option, T defaultValue)
        {
            var optionDto = GetOption(option.Name);

            return optionDto != null ? typeof(T).GetTypeInfo().IsEnum
                    ? (T)Enum.Parse(typeof(T), optionDto.Value, true)
                    : (T)Convert.ChangeType(optionDto.Value, typeof(T))
                : defaultValue;
        }

        public T GetOptionValue<T>(Option<T> option)
        {
            var optionDto = GetOption(option.Name);

            return optionDto != null
                ? typeof(T).GetTypeInfo().IsEnum
                    ? (T)Enum.Parse(typeof(T), optionDto.Value, true)
                    : (T)Convert.ChangeType(optionDto.Value, typeof(T))
                : default(T);
        }

        public OptionDto GetOption(string optionName)
        {
            return InputFormOptions.FirstOrDefault(o => o.Name == optionName);
        }
    }
}
