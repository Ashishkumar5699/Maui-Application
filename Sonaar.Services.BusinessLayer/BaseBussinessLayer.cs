using System;
using AutoMapper;

namespace Sonaar.Services.BusinessLayer;

public abstract class BaseBussinessLayer
{
    protected readonly IMapper _mapper;

    public BaseBussinessLayer(IMapper mapper)
    {
        _mapper = mapper;
    }
}
