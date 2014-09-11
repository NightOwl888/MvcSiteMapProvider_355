using System;
using System.Collections.Generic;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Security;
using MvcSiteMapProvider.Web.Mvc;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace MvcSiteMapProvider_355.VisibilityProviders
{
    public class AclModuleVisibilityProvider
        : SiteMapNodeVisibilityProviderBase
    {
        public AclModuleVisibilityProvider(
            IAclModule aclModule
            )
        {
            if (aclModule == null)
                throw new ArgumentNullException("aclModule");

            this.aclModule = aclModule;
        }
        private readonly IAclModule aclModule;

        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            return this.aclModule.IsAccessibleToUser(node.SiteMap, node);
        }
    }
}