using Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Fast_Teste.Util
{
    public class Validation<TEntity> where TEntity : class
    {

        public static void CopyValidation(ModelStateDictionary modelState, GenericServices<TEntity> service)
        {
            modelState.Clear();
            if (service.ValidationDictionary != null && !service.ValidationDictionary.isValid)
            {
                foreach (var item in service.ValidationDictionary.Errors)
                {
                    foreach (var message in service.ValidationDictionary.Errors[item.Key])
                    {
                        modelState.AddModelError(item.Key, message);
                    }
                }
            }
        }

        internal static void CopyValidation(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState, EntregadorServices entregadorServices)
        {
            throw new NotImplementedException();
        }
    }
}
