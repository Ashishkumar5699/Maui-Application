using System;
using AutoMapper;

namespace Sonaar.Services.BusinessLayer;

public class BaseBussinessLayer
{
    private readonly IMapper _mapper;

    public BaseBussinessLayer(IMapper mapper)
    {
        _mapper = mapper;
    }
}
