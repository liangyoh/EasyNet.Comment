using EasyNet.Comment.Context;
using EasyNet.Comment.Serializing;

namespace EasyNet.Comment.JsonNet
{
    public static class IocContainerContextExtensions
    {
        public static IocContainerContext UserJsonNet(this IocContainerContext iocContainerContext)
        {
            iocContainerContext.Register<IJsonSerializer, NewtonsoftJsonSerializer>(new NewtonsoftJsonSerializer());
            return iocContainerContext;
        }
        
    }
}
