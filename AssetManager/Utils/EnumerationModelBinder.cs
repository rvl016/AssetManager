
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AssetManager.Utils {

    public class EnumerationModelBinder<T> : IModelBinder where T : Enumeration {

        public Task BindModelAsync(ModelBindingContext bindingContext) {
            
            if (bindingContext is null)
                throw new ArgumentNullException(nameof(bindingContext));

            var modelName = bindingContext.ModelName;
            var providerResult = bindingContext.ValueProvider.GetValue(modelName);

            if (providerResult == ValueProviderResult.None)
                return Task.CompletedTask;

            bindingContext.ModelState.SetModelValue(modelName, providerResult);

            var stringValue = providerResult.FirstValue;
            if (string.IsNullOrEmpty(stringValue))
                return Task.CompletedTask;

            var value = Enumeration.FromLabelOrDefault<T>(stringValue);
            if (value is null) {
                bindingContext.ModelState.TryAddModelError(modelName, "Invalid Value");
                return Task.CompletedTask;
            }
            bindingContext.Result = ModelBindingResult.Success(value);
            return Task.CompletedTask;
        }
    }

}