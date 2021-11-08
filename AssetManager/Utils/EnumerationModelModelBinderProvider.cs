
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AssetManager.Utils {

    public class EnumerationBinderProvider : IModelBinderProvider {

        public IModelBinder GetBinder(ModelBinderProviderContext context) {

            if (context is null)
                throw new ArgumentNullException(nameof(context));

            var modelType = context.Metadata.ModelType;
            if (modelType.IsSubclassOf(typeof(Enumeration))) {
                // TODO: Find an alternative to a reflection based solution
                var binder = typeof(EnumerationModelBinder<>).MakeGenericType(
                    new [] { modelType }
                );
                return (IModelBinder) Activator.CreateInstance(binder);
            }

            return null;
        }

    }

}