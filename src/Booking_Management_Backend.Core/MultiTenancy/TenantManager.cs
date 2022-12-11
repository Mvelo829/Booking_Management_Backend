using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Booking_Management_Backend.Authorization.Users;
using Booking_Management_Backend.Editions;

namespace Booking_Management_Backend.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
