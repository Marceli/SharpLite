using System;
using System.Web.Mvc;
using MyStore.Domain;

namespace MyStore.Web.Binders
{
    /// <summary>
    /// Custom binder for binding input to Money object
    /// </summary>
    public class DateBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            ValueProviderResult yearresult= bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".Year");
            string yearValue = yearresult.AttemptedValue;
            int year;
            int.TryParse(yearValue, out year);

            return new DateTime(year, 1, 1);
        }
    }
}
