//@CodeCopy
//MdStart
#if ACCOUNT_ON
using CommonBase.Extensions;
using Microsoft.EntityFrameworkCore;
using SnQTranslator.Logic.Controllers.Persistence.Account;
using SnQTranslator.Logic.Entities.Business.Account;
using SnQTranslator.Logic.Entities.Persistence.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQTranslator.Logic.Controllers.Business.Account
{
    internal partial class AppAccessController
    {
        [Attributes.ControllerManagedProperty]
        private IdentityXRoleController IdentityXRoleController { get; set; }

        protected override async Task LoadDetailsAsync(AppAccess entity, int masterId)
        {
            entity.ClearManyItems();

            var query = await IdentityXRoleController.QueryableSet()
                                                     .Where(p => p.IdentityId == masterId)
                                                     .ToArrayAsync()
                                                     .ConfigureAwait(false);

            foreach (var item in query)
            {
                var role = await ManyEntityController.GetByIdAsync(item.RoleId).ConfigureAwait(false);

                if (role != null)
                {
                    entity.AddManyItem(role);
                }
            }
        }

        internal override async Task<AppAccess> InsertEntityAsync(AppAccess entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.OneItem.CheckArgument(nameof(entity.OneItem));
            entity.ManyItems.CheckArgument(nameof(entity.ManyItems));

            var result = new AppAccess();

            result.OneEntity.CopyProperties(entity.OneItem);
            result.OneEntity = await oneEntityController.InsertEntityAsync(result.OneEntity).ConfigureAwait(false);

            foreach (var item in entity.ManyItems)
            {
                var role = new Role();
                var joinRole = new IdentityXRole()
                {
                    Identity = result.OneEntity,
                };

                if (item.Id == 0)
                {
                    item.Designation = RoleController.ClearRoleDesignation(item.Designation);

                    var qryItem = await manyEntityController.QueryableSet()
                                                            .FirstOrDefaultAsync(e => e.Designation.Equals(item.Designation))
                                                            .ConfigureAwait(false);

                    if (qryItem != null)
                    {
                        role.CopyProperties(qryItem);
                        joinRole.RoleId = role.Id;
                    }
                    else
                    {
                        role.CopyProperties(item);
                        role = await manyEntityController.InsertEntityAsync(role).ConfigureAwait(false);
                        joinRole.Role = role;
                    }
                }
                else
                {
                    var qryItem = await manyEntityController.GetByIdAsync(item.Id).ConfigureAwait(false);

                    if (qryItem != null)
                    {
                        role.CopyProperties(qryItem);
                    }
                    joinRole.RoleId = role.Id;
                }
                await IdentityXRoleController.InsertEntityAsync(joinRole).ConfigureAwait(false);
                result.AddManyItem(role);
            }
            return result;
        }
        internal override async Task<AppAccess> UpdateEntityAsync(AppAccess entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.OneItem.CheckArgument(nameof(entity.OneItem));
            entity.ManyItems.CheckArgument(nameof(entity.ManyItems));

            var accessRoles = new List<Role>();

            foreach (var item in entity.ManyEntities)
            {
                var role = new Role();

                item.Designation = RoleController.ClearRoleDesignation(item.Designation);
                role.CopyProperties(item);
                if (role.Id == 0)
                {
                    var qyrRole = await manyEntityController.QueryableSet()
                                                            .FirstOrDefaultAsync(e => e.Designation.Equals(item.Designation))
                                                            .ConfigureAwait(false);
                    if (qyrRole != null)
                    {
                        role.CopyProperties(qyrRole);
                    }
                }
                accessRoles.Add(role);
            }

            //Delete all costs that are no longer included in the list.
            var identityXRoles = await IdentityXRoleController.QueryableSet()
                                                              .Where(e => e.IdentityId == entity.Id)
                                                              .ToArrayAsync()
                                                              .ConfigureAwait(false);

            foreach (var item in identityXRoles)
            {
                var stillHasTheRole = accessRoles.Any(i => i.Id == item.RoleId);

                if (stillHasTheRole == false)
                {
                    await IdentityXRoleController.DeleteAsync(item.Id).ConfigureAwait(false);
                }
            }

            var result = new AppAccess();
            var firstEntity = await OneEntityController.UpdateAsync(entity.OneItem).ConfigureAwait(false);

            result.OneItem.CopyProperties(firstEntity);
            foreach (var accessRole in accessRoles)
            {
                var role = new Role();
                var joinRole = new IdentityXRole();

                role.Id = accessRole.Id;
                joinRole.IdentityId = firstEntity.Id;
                if (accessRole.Id == 0)
                {
                    role.CopyProperties(accessRole);
                    await manyEntityController.InsertAsync(role).ConfigureAwait(false);
                    joinRole.Role = role;
                }
                else
                {
                    var qryRole = await manyEntityController.GetByIdAsync(role.Id).ConfigureAwait(false);

                    if (qryRole != null)
                    {
                        role.CopyProperties(qryRole);
                        joinRole.RoleId = role.Id;
                    }
                }
                var identityXRole = identityXRoles.SingleOrDefault(e => e.IdentityId == joinRole.IdentityId && e.RoleId == joinRole.RoleId);

                if (identityXRole == null)
                {
                    await IdentityXRoleController.InsertAsync(joinRole).ConfigureAwait(false);
                }
                result.AddManyItem(role);
            }
            return result;
        }
        internal override async Task DeleteEntityAsync(AppAccess entity)
        {
            //Delete all costs that are no longer included in the list.
            var identXRoles = await IdentityXRoleController.QueryableSet()
                                                           .Where(e => e.IdentityId == entity.Id)
                                                           .ToArrayAsync()
                                                           .ConfigureAwait(false);

            foreach (var item in identXRoles)
            {
                await IdentityXRoleController.DeleteAsync(item.Id).ConfigureAwait(false);
            }
            await OneEntityController.DeleteAsync(entity.Id).ConfigureAwait(false);
        }
    }
}
#endif
//MdENd
