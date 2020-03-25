using MediatR;
using Shared;
using System.Collections.Generic;
using VentilatorRegistry.API.QueryExecutors.Results;

namespace VentilatorRegistry.API.Queries
{
    public class GetHospitalOrganizationsQuery : IQuery, IRequest<IEnumerable<GetHospitalOrganizationsQueryResult>>
    {
    }
}
