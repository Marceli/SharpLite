// Type: SharpLite.Web.Mvc.ModelBinder.SharpModelBinder
// Assembly: SharpLite.Web, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f2f64e823dfaf078
// Assembly location: C:\dev\tools\Sharp-Lite\Example\MyStore\lib\SharpLite.Web.dll

using System.ComponentModel;
using System.Web.Mvc;

namespace SharpLite.Web.Mvc.ModelBinder
{
    public class SharpModelBinder : DefaultModelBinder
    {
        public static object IEntityWithTypedId { get; set; }

        protected override object GetPropertyValue(ControllerContext controllerContext,
                                                   ModelBindingContext bindingContext,
                                                   PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder);

        protected override bool OnModelUpdating(ControllerContext controllerContext, ModelBindingContext bindingContext);

        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                            PropertyDescriptor propertyDescriptor, object value);
    }
}
