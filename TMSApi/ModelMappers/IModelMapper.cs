using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.ApiModels;

namespace TMSApi.ModelMappers
{
    public interface IModelMapper<T, U> where T : class, IEntity where U : class, IApiModel
    {
        U ConvertToApiModel(T Model);
        T ConverToDbModel(U ApiModel);
    }
}
